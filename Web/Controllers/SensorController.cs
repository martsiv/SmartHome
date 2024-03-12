using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.Helpers;

namespace Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SensorController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly ISensorService _sensorService;
		private readonly ISensorSettingService _sensorSettingService;
		private readonly ISensorTypeService _sensorTypeService;
		private readonly IStateService _stateService;
		private readonly IMapper _mapper;

		public SensorController(IConfiguration configuration, 
								ISensorService sensorService, 
								IMapper mapper,
								ISensorSettingService sensorSettingService,
								ISensorTypeService sensorTypeService,
								IStateService stateService)
		{
			this._configuration = configuration;
			this._sensorService = sensorService;
			this._mapper = mapper;
			this._sensorSettingService = sensorSettingService;
			this._sensorTypeService = sensorTypeService;
			this._stateService = stateService;
		}
		
		[HttpPost("RegisterSensorAsync")]
		public async Task<IActionResult> ConnectSensorAsync([FromBody]RegisterSensorModel sensor)
		{
			string registerKey = _configuration["RegisterKey"];
			if (registerKey != sensor.RegisterKey)
				return Unauthorized();
			// Розбити логіку на виявлення сенсора, якщо немає то сервіс - регістер, а далі просто сервіс - логін
			if (await _sensorService.GetSensorByMacAsync(sensor.MacAddress) == null)
			{
				SensorDto sensorDto = await _sensorService.RegisterSensorAsync(sensor);
				return Ok(_sensorService.LoginSensor(sensorDto));
			}
			else
				return Ok(_sensorService.LoginSensor(_mapper.Map<SensorDto>(sensor)));
		}

		[HttpPost("AddSensorTypeAsync")]
		public async Task<IActionResult> AddSensorTypeAsync(SensorTypeDto sensorType)
		{
			return await ExecuteServiceActionAsync(() => 
				_sensorTypeService.AddSensorTypeAsync(sensorType));
		}

		[HttpPost("AddSensorSettingAsync")]
		public async Task<IActionResult> AddSensorSettingAsync(SensorSettingDto sensorSetting)
		{
			return await ExecuteServiceActionAsync(() => 
				_sensorSettingService.AddSensorSettingAsync(sensorSetting));
		}

		[HttpPost("AddStateAsync")]
		public async Task<IActionResult> AddStateAsync(StateDto state)
		{
			return await ExecuteServiceActionAsync(() => 
				_stateService.AddStateAsync(state));
		}

		[HttpGet("GetAllSensorsAsync")]
		public async Task<IActionResult> GetAllSensorsAsync()
		{
			return Ok(await _sensorService.GetAllSensorsAsync());
		}

		[HttpGet("GetAllSensorSettingsAsync")]
		public async Task<IActionResult> GetAllSensorSettings()
		{
			return Ok(await _sensorSettingService.GetAllSensorSettingsAsync());
		}

		[HttpGet("GetAllSensorTypesAsync")]
		public async Task<IActionResult> GetAllSensorTypesAsync()
		{
			return Ok(await _sensorTypeService.GetAllSensorTypesAsync());
		}

		//[Authorize]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Microcontroller)]
		[HttpGet("GetAllStatesAsync")]
		public async Task<IActionResult> GetAllStatesAsync()
		{
			return Ok(await _stateService.GetAllStatesAsync());
		}

		[HttpGet("GetSensorByIdAsync/{sensorId}")]
		public async Task<IActionResult> GetSensorByIdAsync(int sensorId) => Ok(await _sensorService.GetSensorByIdAsync(sensorId));

		[HttpGet("GetSensorSettingByIdAsync/{sensorSettingId}")]
		public async Task<IActionResult> GetSensorSettingByIdAsync(int sensorSettingId) => Ok(await _sensorSettingService.GetSensorSettingByIdAsync(sensorSettingId));

		[HttpGet("GetSensorSettingsBySensorIdAsync/{sensorId}")]
		public async Task<IActionResult> GetSensorSettingsBySensorIdAsync(int sensorId) => Ok(await _sensorSettingService.GetSensorSettingsBySensorIdAsync(sensorId));

		[HttpGet("GetSensorTypeByIdAsync/{sensorTypeId}")]
		public async Task<IActionResult> GetSensorTypeByIdAsync(int sensorTypeId) => Ok(await _sensorTypeService.GetSensorTypeByIdAsync(sensorTypeId));

		[HttpGet("GetStateByIdAsync/{stateId}")]
		public async Task<IActionResult> GetStateByIdAsync(int stateId) => Ok(await _stateService.GetStateByIdAsync(stateId));

		[HttpDelete("RemoveSensorAsync/{sensorId}")]
		public async Task<IActionResult> RemoveSensorAsync(int sensorId) => await ExecuteServiceActionAsync(() => _sensorService.RemoveSensorAsync(sensorId));

		[HttpDelete("RemoveSensorSettingAsync/{sensorSettingId}")]
		public async Task<IActionResult> RemoveSensorSettingAsync(int sensorSettingId) => await ExecuteServiceActionAsync(() => _sensorSettingService.RemoveSensorSettingAsync(sensorSettingId));

		[HttpDelete("RemoveSensorSettingsBySensorAsync/{sensorId}")]
		public async Task<IActionResult> RemoveSensorSettingsBySensorAsync(int sensorId) {
			return await ExecuteServiceActionAsync(async () => await _sensorSettingService.RemoveSensorSettingsBySensorAsync(sensorId));
		}
		[HttpDelete("RemoveSensorTypeAsync/{sensorTypeId}")]
		public async Task<IActionResult> RemoveSensorTypeAsync(int sensorTypeId) => await ExecuteServiceActionAsync(() => _sensorTypeService.RemoveSensorTypeAsync(sensorTypeId));

		[HttpDelete("RemoveStateAsync/{stateId}")]
		public async Task<IActionResult> RemoveStateAsync(int stateId) => await ExecuteServiceActionAsync(() => _stateService.RemoveStateAsync(stateId));
	
		[HttpPut("UpdateSensorTypeAsync/{sensorTypeId}")]
		public async Task<IActionResult> UpdateSensorTypeAsync(int sensorTypeId, SensorTypeDto sensorType) => await ExecuteServiceActionAsync(() => _sensorTypeService.UpdateSensorTypeAsync(sensorTypeId, sensorType));
	
		[HttpPut("UpdateStateAsync/{stateId}")]
		public async Task<IActionResult> UpdateStateAsync(int stateId, StateDto state) => await ExecuteServiceActionAsync(() => _stateService.UpdateStateAsync(stateId, state));

		[HttpPut("UpdateSensorAsync/{sensorId}")]
		public async Task<IActionResult> UpdateSensorAsync(int sensorId, SensorDto sensor) => await ExecuteServiceActionAsync(() => _sensorService.UpdateSensorAsync(sensorId, sensor));

		[HttpPut("UpdateSensorSettingAsync/{sensorSettingId}")]
		public async Task<IActionResult> UpdateSensorSettingAsync(int sensorSettingId, SensorSettingDto sensorSetting) => await ExecuteServiceActionAsync(() => _sensorSettingService.UpdateSensorSettingAsync(sensorSettingId, sensorSetting));
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

