using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.Services
{
	internal class AccountsService : IAccountsService
	{
		private readonly UserManager<IdentityUser> userManager;
		//private readonly SignInManager<User> signInManager;
		private readonly IMapper mapper;
		//private readonly IValidator<RegisterModel> registerValidator;
		private readonly IJwtService jwtService;

		public AccountsService(UserManager<IdentityUser> userManager,
								//SignInManager<User> signInManager,
								IMapper mapper,
								//IValidator<RegisterModel> registerValidator,
								IJwtService jwtService)
		{
			this.userManager = userManager;
			//this.signInManager = signInManager;
			this.mapper = mapper;
			//this.registerValidator = registerValidator;
			this.jwtService = jwtService;
		}

		public async Task Register(RegisterModel model)
		{
			//registerValidator.ValidateAndThrow(model);

			//if (await userManager.FindByEmailAsync(model.Email) != null)
			//	throw new HttpException("Email is already exists.", HttpStatusCode.BadRequest);

			var user = mapper.Map<IdentityUser>(model);

			var result = await userManager.CreateAsync(user, model.Password);

			//if (!result.Succeeded)
			//	throw new HttpException(string.Join(" ", result.Errors.Select(x => x.Description)), HttpStatusCode.BadRequest);
		}

		public async Task<LoginResponseModel> Login(LoginModel model)
		{
			var user = await userManager.FindByEmailAsync(model.Email);

			//if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
			//	throw new HttpException("Invalid login or password.", HttpStatusCode.BadRequest);

			//await signInManager.SignInAsync(user, true);
			
			if (user == null || user.Email == null || !await userManager.CheckPasswordAsync(user, model.Password))
				throw new Exception("Invalid login or password.");

			return  new LoginResponseModel()
			{
				Username = user.Email,
				Token = jwtService.CreateToken(jwtService.GetClaims(user))
			};
		}
		// TODO Implement reset password
		public Task<ResetPasswordResponse> ResetPasswordRequest(string email)
		{
			throw new NotImplementedException();
		}

		public Task ResetPassword(ResetPasswordModel model)
		{
			throw new NotImplementedException();
		}

		//public async Task Logout()
		//{
		//	await signInManager.SignOutAsync();
		//}
	}
}
