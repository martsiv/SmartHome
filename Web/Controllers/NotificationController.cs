using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Helpers;

namespace Web.Controllers
{
	[Route("api/[controller]")]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly ISensorService _sensorService;
		private readonly INotificationTypeService _notificationTypeService;
		private readonly INotificationService _notificationService;
		private readonly IMapper _mapper;

		public NotificationController(IConfiguration configuration,
								INotificationService notificationService,
								INotificationTypeService notificationTypeService,
								ISensorService sensorService,
								IMapper mapper)
		{
			this._configuration = configuration;
			this._sensorService = sensorService;
			this._notificationTypeService = notificationTypeService;
			this._notificationService = notificationService;
			this._mapper = mapper;
		}
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Microcontroller)]
		[HttpPost("InsertNotification")]
		public async Task<IActionResult> InsertNotification([FromBody] NewNotificationModel newNotificationModel)
		{
			int? sensorId = _sensorService.GetSensorByMac(newNotificationModel.SensorMacAddress)?.Id;
			var notificationType = _notificationTypeService.GetNotificationTypeByLevel(newNotificationModel.PriorityLevel);
			if (sensorId != null && notificationType != null)
			{
				NotificationDto notificationDto = new NotificationDto()
				{
					SensorId = sensorId.Value,
					Message = newNotificationModel.Message,
					NotificationTypeId = notificationType.Id,
					Date = DateTime.UtcNow
				};
				return ExecuteServiceAction(() => _notificationService.InsertNotification(notificationDto));
			}

			return BadRequest();
		}

		[HttpGet("GetLastNotifications/{sensorId}")]
		public async Task<IActionResult> GetLastNotifications(int sensorId) => Ok(await _notificationService.GetLastNotificationsAsync(sensorId));

		private IActionResult ExecuteServiceAction(Action action)
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
