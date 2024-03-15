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
	public class SubscriptionController : ControllerBase
	{
		private readonly ISubscriptionService _subscriptionService;
		private readonly IMapper _mapper;

		public SubscriptionController(ISubscriptionService subscriptionService,
									IMapper mapper)
		{
			this._subscriptionService = subscriptionService;
			this._mapper = mapper;
		}
        [HttpPost("AddSubscription")]
		public async Task<IActionResult> AddSubscriptionAcyns([FromBody] SubscriptionDto subscription)
		{
			return await ExecuteServiceActionAsync(() =>
							_subscriptionService.AddSubscriptionAsync(subscription));
		}
		[HttpGet("GetAllSubscriptions")]
		public async Task<IActionResult> GetAllSubscriptionsAsync()
		{
			return Ok(await _subscriptionService.GetAllSubscriptionsAsync());
		}
		[HttpGet("GetAllSubscriptionsBySensor/{sensorId}")]
		public async Task<IActionResult> GetAllSubscriptionsBySensorAsync(int sensorId)
		{
			return Ok(await _subscriptionService.GetSubscriptionsBySensorAsync(sensorId));
		}
		[HttpGet("GetAllSubscriptionsByChat/{telegramChatId}")]
		public async Task<IActionResult> GetAllSubscriptionsByChatAsync(int telegramChatId)
		{
			return Ok(await _subscriptionService.GetSubscriptionsByTelegramChatIdAsync(telegramChatId));
		}
		[HttpPost("RemoveSubscription")]
		public async Task<IActionResult> RemoveSubscriptionAsync(int subscriptionId)
		{
			return await ExecuteServiceActionAsync(async () => await _subscriptionService.RemoveSubscriptionAsync(subscriptionId));
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
