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
	public class TelergamChatController : ControllerBase
	{
		private readonly ITelegramChatService _telegramChatService;
		private readonly IMapper _mapper;

		public TelergamChatController(ITelegramChatService telegramChatService,
									IMapper mapper)
		{
			this._telegramChatService = telegramChatService;
			this._mapper = mapper;
		}
		[HttpPost("AddTelergamChat")]
		public async Task<IActionResult> AddTelergamChat([FromBody] TelegramChatDto telegramChatDto)
		{
			return await ExecuteServiceActionAsync(() =>
							_telegramChatService.AddTelegramChatAsync(telegramChatDto));
		}
		[HttpGet("GetAllTelergamChats")]
		public async Task<IActionResult> GetAllTelergamChatsAsync()
		{
			return Ok(await _telegramChatService.GetAllTelegramChatsAsync());
		}
		[HttpPost("RemoveTelergamChat")]
		public async Task<IActionResult> RemoveTelergamChatAsync(int telegramChatEntityId)
		{
			return await ExecuteServiceActionAsync(async () => await _telegramChatService.RemoveTelegramChatAsync(telegramChatEntityId));
		}
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
