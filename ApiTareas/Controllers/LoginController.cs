using ApiTareas.Data.Repositories;
using ApiTareas.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTareas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login(Credenciales credenciales)
        {
            if (credenciales == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var login = await _loginRepository.login(credenciales);

            if (login == null) {
                return Unauthorized();
            }

            return Ok(login);
        }
    }
}
