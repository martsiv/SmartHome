using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Interfaces;
using ApplicationCore.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using AutoMapper;
using Web.Helpers;

namespace Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SensorController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly ISensorService _sensorService;
		private readonly IMapper _mapper;

		public SensorController(IConfiguration configuration, ISensorService sensorService, IMapper mapper)
		{
			this._configuration = configuration;
			this._sensorService = sensorService;
			this._mapper = mapper;
		}

		[HttpPost("AddRoom")]
		public IActionResult AddRoom(RoomDto room) => ExecuteServiceAction(() => _sensorService.AddRoom(room));

		[HttpPost("RegisterSensor")]
		public IActionResult ConnectSensor([FromBody]RegisterSensorModel sensor)
		{
			string registerKey = _configuration["RegisterKey"];
			if (registerKey != sensor.RegisterKey)
				return Unauthorized();
			// Розбити логіку на виявлення сенсора, якщо немає то сервіс - регістер, а далі просто сервіс - логін
			if (_sensorService?.GetSensorByMacAsync(sensor.MacAddress) == null)
			{
				SensorDto sensorDto = _sensorService.RegisterSensor(sensor);
				return Ok(_sensorService.LoginSensor(sensorDto));
			}
			else
				return Ok(_sensorService.LoginSensor(_mapper.Map<SensorDto>(sensor)));
		}

		[HttpPost("AddSensorSetting")]
		public IActionResult AddSensorSetting(SensorSettingDto sensorSetting) => ExecuteServiceAction(() => _sensorService.AddSensorSetting(sensorSetting));

		[HttpPost("AddSensorType")]
		public IActionResult AddSensorType(SensorTypeDto sensorType) => ExecuteServiceAction(() => _sensorService.AddSensorType(sensorType));

		[HttpPost("AddSetting")]
		public IActionResult AddSetting(SettingDto setting) => ExecuteServiceAction(() => _sensorService.AddSetting(setting));

		[HttpPost("AddState")]
		public IActionResult AddState(StateDto state) => ExecuteServiceAction(() => _sensorService.AddState(state));

		[HttpGet("GetAllRooms")]
		public IActionResult GetAllRooms() => Ok(_sensorService.GetAllRooms());

		[HttpGet("GetAllSensors")]
		public IActionResult GetAllSensors() => Ok(_sensorService.GetAllSensors());

		[HttpGet("GetAllSensorSettings")]
		public IActionResult GetAllSensorSettings() => Ok(_sensorService.GetAllSensorSettings());

		[HttpGet("GetAllSensorTypes")]
		public IActionResult GetAllSensorTypes() => Ok(_sensorService.GetAllSensorTypes());

		[HttpGet("GetAllSettings")]
		public IActionResult GetAllSettings() => Ok(_sensorService.GetAllSettings());
		//[Authorize]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Microcontroller)]
		[HttpGet("GetAllStates")]
		public IActionResult GetAllStates() => Ok(_sensorService.GetAllStates());

		[HttpGet("GetRoomById/{roomId}")]
		public IActionResult GetRoomById(int roomId) => Ok(_sensorService.GetRoomById(roomId));

		[HttpGet("GetSensorById/{sensorId}")]
		public IActionResult GetSensorById(int sensorId) => Ok(_sensorService.GetSensorById(sensorId));

		[HttpGet("GetSensorSettingById/{sensorSettingId}")]
		public IActionResult GetSensorSettingById(int sensorSettingId) => Ok(_sensorService.GetSensorSettingById(sensorSettingId));

		[HttpGet("GetSensorSettingsBySensorIdAsync/{sensorId}")]
		public async Task<IActionResult> GetSensorSettingsBySensorId(int sensorId) => Ok(await _sensorService.GetSensorSettingsBySensorIdAsync(sensorId));

		[HttpGet("GetSensorTypeById/{sensorTypeId}")]
		public IActionResult GetSensorTypeById(int sensorTypeId) => Ok(_sensorService.GetSensorTypeById(sensorTypeId));

		[HttpGet("GetSettingById/{settingId}")]
		public IActionResult GetSettingById(int settingId) => Ok(_sensorService.GetSettingById(settingId));

		[HttpGet("GetStateById/{stateId}")]
		public IActionResult GetStateById(int stateId) => Ok(_sensorService.GetStateById(stateId));

		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpPost("InsertNotification")]
		public async Task<IActionResult> InsertNotification([FromBody]NewNotificationModel newNotificationModel)
		{
			var sensorId = (await _sensorService.GetSensorByMacAsync(newNotificationModel.SensorMacAddress))?.Id;

			if (sensorId != null)
			{
				NotificationDto notificationDto = new NotificationDto()
				{
					Name = newNotificationModel.Name,
					SensorId = (int)sensorId,
					Data = newNotificationModel.Data,
					Date = DateTime.UtcNow
				};
				return ExecuteServiceAction(() => _sensorService.InsertNotification(notificationDto));
			}

			return BadRequest();
		}

		[HttpDelete("RemoveRoom/{roomId}")]
		public IActionResult RemoveRoom(int roomId) => ExecuteServiceAction(() => _sensorService.RemoveRoom(roomId));

		[HttpDelete("RemoveSensor/{sensorId}")]
		public IActionResult RemoveSensor(int sensorId) => ExecuteServiceAction(() => _sensorService.RemoveSensor(sensorId));

		[HttpDelete("RemoveSensorSetting/{sensorSettingId}")]
		public IActionResult RemoveSensorSetting(int sensorSettingId) => ExecuteServiceAction(() => _sensorService.RemoveSensorSetting(sensorSettingId));

		[HttpDelete("RemoveSensorSettingsBySensorAsync/{sensorId}")]
		public async Task<IActionResult> RemoveSensorSettingsBySensor(int sensorId) {
			return ExecuteServiceAction(async () => await _sensorService.RemoveSensorSettingsBySensorAsync(sensorId));
		}

		[HttpDelete("RemoveSensorType/{sensorTypeId}")]
		public IActionResult RemoveSensorType(int sensorTypeId) => ExecuteServiceAction(() => _sensorService.RemoveSensorType(sensorTypeId));

		[HttpDelete("RemoveSetting/{settingId}")]
		public IActionResult RemoveSetting(int settingId) => ExecuteServiceAction(() => _sensorService.RemoveSetting(settingId));

		[HttpDelete("RemoveState/{stateId}")]
		public IActionResult RemoveState(int stateId) => ExecuteServiceAction(() => _sensorService.RemoveState(stateId));

		[HttpPut("UpdateRoom/{roomId}")]
		public IActionResult UpdateRoom(int roomId, RoomDto room) => ExecuteServiceAction(() => _sensorService.UpdateRoom(roomId, room));

		[HttpPut("UpdateSensorType/{sensorTypeId}")]
		public IActionResult UpdateSensorType(int sensorTypeId, SensorTypeDto sensorType) => ExecuteServiceAction(() => _sensorService.UpdateSensorType(sensorTypeId, sensorType));

		[HttpPut("UpdateSetting/{settingId}")]
		public IActionResult UpdateSetting(int settingId, SettingDto setting) => ExecuteServiceAction(() => _sensorService.UpdateSetting(settingId, setting));

		[HttpPut("UpdateState/{stateId}")]
		public IActionResult UpdateState(int stateId, StateDto state) => ExecuteServiceAction(() => _sensorService.UpdateState(stateId, state));

		[HttpPut("UpdateSensor/{sensorId}")]
		public IActionResult UpdateSensor(int sensorId, SensorDto sensor) => ExecuteServiceAction(() => _sensorService.UpdateSensor(sensorId, sensor));

		[HttpPut("UpdateSensorSetting/{sensorSettingId}")]
		public IActionResult UpdateSensorSetting(int sensorSettingId, SensorSettingDto sensorSetting) => ExecuteServiceAction(() => _sensorService.UpdateSensorSetting(sensorSettingId, sensorSetting));

		[HttpGet("UpdateNotifications/{sensorId}")]
		public IActionResult UpdateNotifications(int sensorId) => Ok(_sensorService.UpdateNotifications(sensorId));

		[HttpGet("GetLastNotifications/{sensorId}")]
		public IActionResult GetLastNotifications(int sensorId) => Ok(_sensorService.GetLastNotifications(sensorId));

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

