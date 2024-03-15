using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	[Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[ApiController]
	public class SettingController : ControllerBase
	{
		private readonly ISettingService _settingService;
		private readonly IMapper _mapper;

		public SettingController(ISettingService settingService,
								 IMapper mapper)
		{
			this._settingService = settingService;
			this._mapper = mapper;
		}
		[HttpPost("AddSettingAsync")]
		public async Task<IActionResult> AddSetting(SettingDto setting) => await ExecuteServiceActionAsync(() => _settingService.AddSettingAsync(setting));
		[HttpGet("GetAllSettingsAsync")]
		public async Task<IActionResult> GetAllSettings() => Ok(await _settingService.GetAllSettingsAsync());
		[HttpGet("GetSettingByIdAsync/{settingId}")]
		public async Task<IActionResult> GetSettingById(int settingId) => Ok(await _settingService.GetSettingByIdAsync(settingId));
		[HttpDelete("RemoveSettingAsync/{settingId}")]
		public async Task<IActionResult> RemoveSetting(int settingId) => await ExecuteServiceActionAsync(() => _settingService.RemoveSettingAsync(settingId));
		[HttpPut("UpdateSettingAsync/{settingId}")]
		public async Task<IActionResult> UpdateSetting(int settingId, SettingDto setting) => await ExecuteServiceActionAsync(() => _settingService.UpdateSettingAsync(settingId, setting));
		private async Task<IActionResult> ExecuteServiceActionAsync(Action action)
		{
			try
			{
				action();
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
	}
}
