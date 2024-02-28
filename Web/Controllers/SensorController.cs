using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Interfaces;
using ApplicationCore.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SensorController : ControllerBase
	{
		private readonly ISensorService _sensorService;

		public SensorController(ISensorService sensorService)
		{
			_sensorService = sensorService;
		}

		[HttpPost("AddRoom")]
		public IActionResult AddRoom(RoomDto room) => ExecuteServiceAction(() => _sensorService.AddRoom(room));

		[HttpPost("AddSensor")]
		public IActionResult AddSensor(SensorDto sensor) => ExecuteServiceAction(() => _sensorService.AddSensor(sensor));

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
		[Authorize]
		[HttpGet("GetAllStates")]
		public IActionResult GetAllStates() => Ok(_sensorService.GetAllStates());

		[HttpGet("GetRoomById/{roomId}")]
		public IActionResult GetRoomById(int roomId) => Ok(_sensorService.GetRoomById(roomId));

		[HttpGet("GetSensorById/{sensorId}")]
		public IActionResult GetSensorById(int sensorId) => Ok(_sensorService.GetSensorById(sensorId));

		[HttpGet("GetSensorSettingById/{sensorSettingId}")]
		public IActionResult GetSensorSettingById(int sensorSettingId) => Ok(_sensorService.GetSensorSettingById(sensorSettingId));

		[HttpGet("GetSensorSettingsBySensorId/{sensorId}")]
		public IActionResult GetSensorSettingsBySensorId(int sensorId) => Ok(_sensorService.GetSensorSettingsBySensorId(sensorId));

		[HttpGet("GetSensorTypeById/{sensorTypeId}")]
		public IActionResult GetSensorTypeById(int sensorTypeId) => Ok(_sensorService.GetSensorTypeById(sensorTypeId));

		[HttpGet("GetSettingById/{settingId}")]
		public IActionResult GetSettingById(int settingId) => Ok(_sensorService.GetSettingById(settingId));

		[HttpGet("GetStateById/{stateId}")]
		public IActionResult GetStateById(int stateId) => Ok(_sensorService.GetStateById(stateId));

		[HttpPost("InsertNotification")]
		public IActionResult InsertNotification(NotificationDto notificationDto) => ExecuteServiceAction(() => _sensorService.InsertNotification(notificationDto));

		[HttpDelete("RemoveRoom/{roomId}")]
		public IActionResult RemoveRoom(int roomId) => ExecuteServiceAction(() => _sensorService.RemoveRoom(roomId));

		[HttpDelete("RemoveSensor/{sensorId}")]
		public IActionResult RemoveSensor(int sensorId) => ExecuteServiceAction(() => _sensorService.RemoveSensor(sensorId));

		[HttpDelete("RemoveSensorSetting/{sensorSettingId}")]
		public IActionResult RemoveSensorSetting(int sensorSettingId) => ExecuteServiceAction(() => _sensorService.RemoveSensorSetting(sensorSettingId));

		[HttpDelete("RemoveSensorSettingsBySensor/{sensorId}")]
		public IActionResult RemoveSensorSettingsBySensor(int sensorId) => ExecuteServiceAction(() => _sensorService.RemoveSensorSettingsBySensor(sensorId));

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

