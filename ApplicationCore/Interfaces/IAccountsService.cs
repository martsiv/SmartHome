﻿using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface IAccountsService
	{
		Task Register(RegisterModel model);
		Task<LoginResponseModel> Login(LoginModel model);
		//Task Logout();
		Task<ResetPasswordResponse> ResetPasswordRequest(string email);
		Task ResetPassword(ResetPasswordModel model);
	}
	public class ResetPasswordResponse
	{
		public string Token { get; set; }
	}
	public class ResetPasswordModel
	{
		public string Email { get; set; }
		public string Token { get; set; }
	}
}
