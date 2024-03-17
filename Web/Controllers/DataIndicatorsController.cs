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
	[ApiController]
	public class DataIndicatorsController : ControllerBase
	{
		private readonly IIndicatorService _indicatorService;
		private readonly ISensorDataStampService _sensorDataStampService;
		private readonly ISensorDataIndicatorService _sensorDataIndicatorService;
		private readonly IDataStampService _dataStampService;
		private readonly IMapper _mapper;

		public DataIndicatorsController(IIndicatorService indicatorService,
									ISensorDataStampService sensorDataStampService,
									ISensorDataIndicatorService sensorDataIndicatorService,
									IDataStampService dataStampService,
									IMapper mapper)
		{
			this._indicatorService = indicatorService;
			this._sensorDataStampService = sensorDataStampService;
			this._sensorDataIndicatorService = sensorDataIndicatorService;
			this._dataStampService = dataStampService;
			this._mapper = mapper;
		}
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpPost("AddIndicator")]
		public IActionResult AddIndicator([FromBody] IndicatorDto indicatorDto)
		{
			return ExecuteServiceAction(() =>
							_indicatorService.AddIndicator(indicatorDto));
		}
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Microcontroller)]
		[HttpPost("AddDataStamp")]
		public IActionResult AddDataStamp([FromBody] CreateDataStampModel dataStamp)
		{
			return ExecuteServiceAction(() =>
							_dataStampService.AddDataStamp(dataStamp));
		}
		[HttpPost("AddSensorDataStamp")]
		public IActionResult AddSensorDataStamp([FromBody] SensorDataStampDto dataStamp)
		{
			return ExecuteServiceAction(() =>
							_sensorDataStampService.AddSensorDataStamp(dataStamp));
		}
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpGet("GetAllIndicators")]
		public IActionResult GetAllIndicators()
		{
			return Ok(_indicatorService.GetAllIndicators());
		}
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpGet("GetAllDataStamps")]
		public IActionResult GetAllDataStamps()
		{
			return Ok(_dataStampService.GetAllDataStamps());
		}
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpGet("GetAllDataStampsBySensor")]
		public IActionResult GetAllDataStampsBySensor(int sensorId)
		{
			return Ok(_dataStampService.GetAllDataStampsBySensor(sensorId));
		}
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpGet("GettDataStampsById")]
		public IActionResult GettDataStampsById(int id)
		{
			return Ok(_dataStampService.GetDataStampById(id));
		}

		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpGet("GetLastDataStampsByDate")]
		public IActionResult GetLastDataStampsByDate(DateTime dateTime)
		{
			return Ok(_dataStampService.GetLastDataStampByDate(dateTime));
		}
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpGet("GetAllDataStampsByDate")]
		public IActionResult GetAllDataStampsByDate(DateTime dateTime)
		{
			return Ok(_dataStampService.GetAllDataStampsByDate(dateTime));
		}
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpPost("RemoveIndicator")]
		public IActionResult RemoveIndicator(int indicator)
		{
			return ExecuteServiceAction(() => _indicatorService.RemoveIndicator(indicator));
		}
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpPost("RemoveDataStamp")]
		public IActionResult RemoveDataStampAsync(int sensorDataStamp)
		{
			return ExecuteServiceAction(() => _sensorDataStampService.RemoveSensorDataStamp(sensorDataStamp));
		}
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
