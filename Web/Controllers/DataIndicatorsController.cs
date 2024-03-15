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
		[HttpPost("AddIndicator")]
		public async Task<IActionResult> AddIndicatorAsync([FromBody] IndicatorDto indicatorDto)
		{
			return await ExecuteServiceActionAsync(() =>
							_indicatorService.AddIndicatorAsync(indicatorDto));
		}
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.Microcontroller)]
		[HttpPost("AddDataStamp")]
		public async Task<IActionResult> AddDataStampAsync([FromBody] CreateDataStampModel dataStamp)
		{
			return await ExecuteServiceActionAsync(() =>
							_dataStampService.AddDataStampAsync(dataStamp));
		}
		[HttpGet("GetAllIndicators")]
		public async Task<IActionResult> GetAllIndicatorsAsync()
		{
			return Ok(await _indicatorService.GetAllIndicatorsAsync());
		}
		[HttpGet("GetAllDataStamps")]
		public async Task<IActionResult> GetAllDataStampsAsync()
		{
			return Ok(await _dataStampService.GetAllDataStampsAsync());
		}
		[HttpGet("GetAllDataStampsBySensor")]
		public async Task<IActionResult> GetAllDataStampsBySensorAsync(int sensorId)
		{
			return Ok(await _dataStampService.GetAllDataStampsBySensorAsync(sensorId));
		}
		[HttpGet("GetAllDataStampsByDate")]
		public async Task<IActionResult> GetAllDataStampsByDateAsync(DateTime dateTime)
		{
			return Ok(await _dataStampService.GetAllDataStampsByDateAsync(dateTime));
		}
		[HttpPost("RemoveIndicator")]
		public async Task<IActionResult> RemoveIndicatorAsync(int indicator)
		{
			return await ExecuteServiceActionAsync(async () => await _indicatorService.RemoveIndicatorAsync(indicator));
		}
		[HttpPost("RemoveDataStamp")]
		public async Task<IActionResult> RemoveDataStampAsync(int sensorDataStamp)
		{
			return await ExecuteServiceActionAsync(async () => await _sensorDataStampService.RemoveSensorDataStampAsync(sensorDataStamp));
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
