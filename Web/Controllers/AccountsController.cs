using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountsController : ControllerBase
	{
		private readonly IAccountsService accountsService;

		public AccountsController(IAccountsService accountsService)
		{
			this.accountsService = accountsService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterModel model)
		{
			await accountsService.Register(model);
			return Ok();
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginModel model)
		{
			return Ok(await accountsService.Login(model));
		}

		[HttpPost("logout")]
		public async Task<IActionResult> Logout()
		{
			await accountsService.Logout();
			return Ok();
		}
	}
}
