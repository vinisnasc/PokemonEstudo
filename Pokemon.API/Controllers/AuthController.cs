using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PocketMonster.Model.DTOs.Auth;
using System.Threading.Tasks;

namespace PocketMonster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(RegisterUserViewModel vm)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var user = new IdentityUser
            {
                UserName = vm.Email,
                Email = vm.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, vm.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("entrar")]
        public async Task<ActionResult> Login(LoginUserViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _signInManager.PasswordSignInAsync(vm.Email, vm.Password, false, true);

            if (result.Succeeded)
                return Ok();

            if (result.IsLockedOut)
                return BadRequest("Usuario bloquado por tentativas invalidas");

            return BadRequest("Usuario ou senha incorreta");
        }
    }
}