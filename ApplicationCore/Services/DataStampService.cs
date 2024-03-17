using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using AutoMapper;
using System;
using static ApplicationCore.Specifications.SensorSettingsSpecs;

namespace ApplicationCore.Services
{
	internal class DataStampService : IDataStampService
	{
		private readonly ISensorDataIndicatorService sensorDataIndicatorsService;
		private readonly IIndicatorService indicatorService;
		private readonly ISensorDataStampService sensorDataStampService;
		private readonly ISensorService sensorService;
		private readonly IMapper mapper;
		public DataStampService(ISensorDataIndicatorService sensorDataIndicatorsService,
								IIndicatorService indicatorService,
								ISensorDataStampService sensorDataStampService,
								ISensorService sensorService,
								IMapper mapper)
		{
			this.sensorDataIndicatorsService = sensorDataIndicatorsService;
			this.indicatorService = indicatorService;
			this.sensorDataStampService = sensorDataStampService;
			this.sensorService = sensorService;
			this.mapper = mapper;
		}
		public async Task AddDataStampAsync(CreateDataStampModel createDataStamp)
		{
			var sensor = await sensorService.GetSensorByMacAsync(createDataStamp.SensorMacAddress);
			var sensorDataStamp = new SensorDataStampDto() { Date = DateTime.UtcNow, SensorId = sensor.Id };
			await sensorDataStampService.AddSensorDataStampAsync(sensorDataStamp);
			int? sensorDataStampEntityId = (await sensorDataStampService.GetLastSensorDataStampByDateAsync(sensorDataStamp.Date))?.Id;
			if (sensorDataStampEntityId == null) throw new Exception("Cant find Sensor data stamp ID");
			foreach (var sensorDataIndicator in createDataStamp.DataIndicators)
			{
				var indicator = await indicatorService.GetIndicatorByNameAsync(sensorDataIndicator.Key);
				await sensorDataIndicatorsService.AddSensorDataIndicatorAsync(new()
				{
					IndicatorId = indicator.Id,
					SensorDataId = sensorDataStampEntityId.Value,
					Value = sensorDataIndicator.Value
				});
			}
		}

		public void AddDataStamp(CreateDataStampModel createDataStamp)
		{
			var sensor = sensorService.GetSensorByMac(createDataStamp.SensorMacAddress);
			var sensorDataStamp = new SensorDataStampDto() { Date = DateTime.UtcNow, SensorId = sensor.Id };
			sensorDataStampService.AddSensorDataStamp(sensorDataStamp);
			int? sensorDataStampEntityId = sensorDataStampService.GetLastSensorDataStampByDate(sensorDataStamp.Date)?.Id;
			if (sensorDataStampEntityId == null) throw new Exception("Cant find Sensor data stamp ID");
			foreach (var sensorDataIndicator in createDataStamp.DataIndicators)
			{
				var indicator = indicatorService.GetIndicatorByName(sensorDataIndicator.Key);
				sensorDataIndicatorsService.AddSensorDataIndicator(new()
				{
					IndicatorId = indicator.Id,
					SensorDataId = sensorDataStampEntityId.Value,
					Value = sensorDataIndicator.Value
				});
			}
		}

		public IEnumerable<GetDataStampModel> GetAllDataStamps()
		{
			var sensorDataStamps = sensorDataStampService.GetAllSensorDataStamps();
			List<GetDataStampModel> result = new List<GetDataStampModel>();
			foreach (var sensorDataStamp in sensorDataStamps)
			{
				var sensorDataIndicators = sensorDataIndicatorsService.GetAllSensorDataIndicatorsByDataStampId(sensorDataStamp.Id);
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

		public IEnumerable<GetDataStampModel> GetAllDataStampsByDate(DateTime dateTime)
		{
			var sensorDataStamps = sensorDataStampService.GetAllSensorDataStampsByDate(dateTime);
			List<GetDataStampModel> result = new List<GetDataStampModel>();
			foreach (var sensorDataStamp in sensorDataStamps)
			{
				var sensorDataIndicators = sensorDataIndicatorsService.GetAllSensorDataIndicatorsByDataStampId(sensorDataStamp.Id);
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

		public IEnumerable<GetDataStampModel> GetAllDataStampsBySensor(int sensorId)
		{
			var sensorDataStamps = sensorDataStampService.GetAllSensorDataStampsBySensor(sensorId);
			List<GetDataStampModel> result = new List<GetDataStampModel>();
			foreach (var sensorDataStamp in sensorDataStamps)
			{
				var sensorDataIndicators = sensorDataIndicatorsService.GetAllSensorDataIndicatorsByDataStampId(sensorDataStamp.Id);
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

		public GetDataStampModel? GetDataStampById(int id)
		{
			GetDataStampModel sensorDataStampModel = mapper.Map<GetDataStampModel>(sensorDataStampService.GetSensorDataStampById(id));
			if (sensorDataStampModel == null) return null;
			sensorDataStampModel.GetSensorDataIndicators = sensorDataIndicatorsService.GetAllSensorDataIndicatorsByDataStampId(sensorDataStampModel.Id).ToList();
			return sensorDataStampModel;
		}

		public async Task<GetDataStampModel?> GetDataStampByIdAsync(int id)
		{
			GetDataStampModel sensorDataStampModel = mapper.Map<GetDataStampModel>(await sensorDataStampService.GetSensorDataStampByIdAsync(id));
			if (sensorDataStampModel == null) return null;
			sensorDataStampModel.GetSensorDataIndicators = (await sensorDataIndicatorsService.GetAllSensorDataIndicatorsByDataStampIdAsync(sensorDataStampModel.Id)).ToList();
			return sensorDataStampModel;
		}

		public GetDataStampModel? GetLastDataStampByDate(DateTime dateTime)
		{
			GetDataStampModel sensorDataStampModel = mapper.Map<GetDataStampModel>(sensorDataStampService.GetLastSensorDataStampByDate(dateTime));
			if (sensorDataStampModel == null) return null;
			sensorDataStampModel.GetSensorDataIndicators = sensorDataIndicatorsService.GetAllSensorDataIndicatorsByDataStampId(sensorDataStampModel.Id).ToList();
			return sensorDataStampModel;
		}

		public async Task<GetDataStampModel?> GetLastDataStampByDateAsync(DateTime dateTime)
		{
			GetDataStampModel sensorDataStampModel = mapper.Map<GetDataStampModel>(await sensorDataStampService.GetLastSensorDataStampByDateAsync(dateTime));
			if (sensorDataStampModel == null) return null;
			sensorDataStampModel.GetSensorDataIndicators = (await sensorDataIndicatorsService.GetAllSensorDataIndicatorsByDataStampIdAsync(sensorDataStampModel.Id)).ToList();
			return sensorDataStampModel;
		}
	}
}
