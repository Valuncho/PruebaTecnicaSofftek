using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaSofftek.DTOs;
using PruebaTecnicaSofftek.Helpers;
using PruebaTecnicaSofftek.Infrastructure;
using PruebaTecnicaSofftek.Services;

namespace PruebaTecnicaSofftek.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        //Token para realizar las operaciones de la API
        private TokenJwtHelper _tokenJwtHelper;
        private readonly IUnitOfWork _unitOfWork;
        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            // instancia un nuevo token
            _tokenJwtHelper = new TokenJwtHelper(configuration);
        }
        /// <summary>
        /// Realiza la autenticacion de un usuario y genera un token de acceso.
        /// </summary>
        /// <param name="dto">Los datos de autenticación proporcionados por el usuario.</param>
        /// <returns>Una respuesta HTTP que indica el resultado de la autenticación y en caso de exito, un token de acceso.</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiSuccessResponse<LoginDto>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 401)]
        public async Task<IActionResult> Login(AutenticacionDto dto)
        {
            // Realiza la autenticacion del usuario utilizando los datos proporcionados en el objeto dto
            var userCredentials = await _unitOfWork.CustomerRepository.AuthenticateCredentials(dto);
            // Si la authenticacion no existe devuelve un Unauthorized
            if (userCredentials is null) return Unauthorized();
            // Genera un token de acceso para el usuario autenticado
            var token = _tokenJwtHelper.GenerateToken(userCredentials);
            // Crea un objeto LoginDto que contiene informacion sobre el usuario autenticado y el token generado.
            var user = new LoginDto()
            {
                Email = userCredentials.Email,
                Name = userCredentials.CustomerName,
                Token = token
            };
            // Devuelve un objeto user
            return ResponseFactory.CreateSuccessResponse(200, user);
        }
    }
}
