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
            _tokenJwtHelper = new TokenJwtHelper(configuration);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiSuccessResponse<LoginDto>), 200)]
        [ProducesResponseType(typeof(ApiErrorResponse), 401)]
        public async Task<IActionResult> Login(AutenticacionDto dto)
        {
            var userCredentials = await _unitOfWork.CustomerRepository.AuthenticateCredentials(dto);

            if (userCredentials is null) return Unauthorized();

            var token = _tokenJwtHelper.GenerateToken(userCredentials);

            var user = new LoginDto()
            {
                Email = userCredentials.Email,
                Name = userCredentials.CustomerName,
                Token = token
            };

            return ResponseFactory.CreateSuccessResponse(200, user);

        }
    }
}
