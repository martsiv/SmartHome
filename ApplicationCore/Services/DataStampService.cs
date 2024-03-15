using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using System;

namespace ApplicationCore.Services
{
	internal class DataStampService : IDataStampService
	{
		private readonly ISensorDataIndicatorService sensorDataIndicatorsService;
		private readonly IIndicatorService indicatorService;
		private readonly ISensorDataStampService sensorDataStampService;
		private readonly ISensorService sensorService;
		public DataStampService(ISensorDataIndicatorService sensorDataIndicatorsService,
								IIndicatorService indicatorService,
								ISensorDataStampService sensorDataStampService,
								ISensorService sensorService)
		{
			this.sensorDataIndicatorsService = sensorDataIndicatorsService;
			this.indicatorService = indicatorService;
			this.sensorService = sensorService;
		}
		public async Task AddDataStampAsync(CreateDataStampModel createDataStamp)
		{
			var sensor = await sensorService.GetSensorByMacAsync(createDataStamp.SensorMacAddress);
			var sensorDataStamp = new SensorDataStampDto() { Date =  DateTime.UtcNow, SensorId = sensor.Id };
			await sensorDataStampService.AddSensorDataStampAsync(sensorDataStamp);
			foreach (var sensorDataIndicator in createDataStamp.DataIndicators)
			{
				var indicator = await indicatorService.GetIndicatorByNameAsync(sensorDataIndicator.Key);
				await sensorDataIndicatorsService.AddSensorDataIndicatorAsync(new() 
				{ 
					IndicatorId = indicator.Id, 
					SensorDataId = sensorDataStamp.Id, 
					Value = sensorDataIndicator.Value 
				});
			}
		}

		public async Task<IEnumerable<GetDataStampModel>> GetAllDataStampsAsync()
		{
			var sensorDataStamps = await sensorDataStampService.GetAllSensorDataStampsAsync();
			List<GetDataStampModel> result = new List<GetDataStampModel>();
			foreach (var sensorDataStamp in sensorDataStamps)
			{
				var sensorDataIndicators = await sensorDataIndicatorsService.GetAllSensorDataIndicatorsByDataStampIdAsync(sensorDataStamp.Id);
				result.Add(new GetDataStampModel() 
				{  
					Id = sensorDataStamp.Id, 
					SensorId = sensorDataStamp.SensorId, 
					Date = sensorDataStamp.Date, 
					GetSensorDataIndicators = sensorDataIndicators.ToList() 
				});
			}
			return result;
		}

		public async Task<IEnumerable<GetDataStampModel>> GetAllDataStampsByDateAsync(DateTime dateTime)
		{
			var sensorDataStamps = await sensorDataStampService.GetAllSensorDataStampsByDateAsync(dateTime);
			List<GetDataStampModel> result = new List<GetDataStampModel>();
			foreach (var sensorDataStamp in sensorDataStamps)
			{
				var sensorDataIndicators = await sensorDataIndicatorsService.GetAllSensorDataIndicatorsByDataStampIdAsync(sensorDataStamp.Id);
				result.Add(new GetDataStampModel()
				{
					Id = sensorDataStamp.Id,
					SensorId = sensorDataStamp.SensorId,
					Date = sensorDataStamp.Date,
					GetSensorDataIndicators = sensorDataIndicators.ToList()
				});
			}
			return result;
		}

		public async Task<IEnumerable<GetDataStampModel>> GetAllDataStampsBySensorAsync(int sensorId)
		{
			var sensorDataStamps = await sensorDataStampService.GetAllSensorDataStampsBySensorAsync(sensorId);
			List<GetDataStampModel> result = new List<GetDataStampModel>();
			foreach (var sensorDataStamp in sensorDataStamps)
			{
				var sensorDataIndicators = await sensorDataIndicatorsService.GetAllSensorDataIndicatorsByDataStampIdAsync(sensorDataStamp.Id);
				result.Add(new GetDataStampModel()
				{
					Id = sensorDataStamp.Id,
					SensorId = sensorDataStamp.SensorId,
					Date = sensorDataStamp.Date,
					GetSensorDataIndicators = sensorDataIndicators.ToList()
				});
			}
			return result;
		}
	}
}
