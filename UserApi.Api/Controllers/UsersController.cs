using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserApi.Application.DTOs;
using UserApi.Application.Features.User.Commands;
using UserApi.Application.Features.User.Queries;
using UserApi.Domain.Entities;

namespace UserApi.API
{
    [ApiController]
    [Route("api/users")]
    public class UsersController(IMediator mediator, ILogger<UsersController> logger) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger<UsersController> _logger = logger;

        //private readonly IUserService _userService = userService;

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            // Envoi de la commande au handler via MediatR
            var userId = await _mediator.Send(command);

            // Retourner un code de statut 201 avec l'ID de l'utilisateur créé
            return CreatedAtAction(nameof(GetUserById), new { id = userId }, userId);
        }

        // Endpoint pour obtenir un utilisateur par ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            _logger.LogInformation("Récupération d'utilisateurs par id {0}",id); 
            var query = new GetUserByIdQuery { Id = id };

            // Envoi de la requête au handler via MediatR
            var user = await _mediator.Send(query);

            if (user == null)
            {
                _logger.LogWarning("Échec de la récupération, utilisateur ID: {Id} introuvable", id);
                return NotFound();
            }
            _logger.LogInformation("Utilisateur ID: {Id} récupéré avec succès", id);
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            _logger.LogInformation("Récupération de tout les utilisateurs");

            var users = await _mediator.Send(new GetAllUsersQuery());

            if (users == null)
            {
                _logger.LogWarning("Échec de récupération!");
                return NotFound();
            }
            _logger.LogInformation("Utilisateurs récupérés avec succès");
            return Ok(users);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDto userDto)
        {
            _logger.LogInformation("Mise à jour de l'utilisateur ID: {Id}", id);

            var command = new UpdateUserCommand(id, userDto);
            var result = await _mediator.Send(command);

            if (!result)
            {
                _logger.LogWarning("Échec de la mise à jour, utilisateur ID: {Id} introuvable", id);
                return NotFound("Utilisateur non trouvé");
            }

            _logger.LogInformation("Utilisateur ID: {Id} mis à jour avec succès", id);
            return NoContent(); // 204 No Content
        }
    }
}
