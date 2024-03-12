using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using AutoMapper;

namespace ApplicationCore.Services
{
	public class SensorService : ISensorService
	{
		private readonly IJwtService jwtService;
		private readonly IMapper mapper;
		private readonly IRepository<Sensor> sensorsRepo;

        public SensorService(IJwtService jwtService,
							IMapper mapper,
							IRepository<Sensor> sensorsRepo)
        {
			this.jwtService = jwtService;
			this.mapper = mapper;
			this.sensorsRepo = sensorsRepo;
        }
		public async Task<SensorDto> RegisterSensorAsync(RegisterSensorModel registerSensorModel)
		{
			var entity = mapper.Map<Sensor>(registerSensorModel);
			await sensorsRepo.InsertAsync(entity);
			await sensorsRepo.SaveAsync();

			return mapper.Map<SensorDto>(entity);
		}
		public LoginSensorResponseModel LoginSensor(SensorDto sensor)
		{
			return new LoginSensorResponseModel() { Token = jwtService.CreateToken(jwtService.GetClaims(sensor)) };
		}
		public async Task<IEnumerable<SensorDto>> GetAllSensorsAsync()
		{
			var sensors = await sensorsRepo.GetAllAsync();
			return mapper.Map<IEnumerable<SensorDto>>(sensors);
		}
		public async Task<SensorDto> GetSensorByIdAsync(int sensorId)
		{
			var sensor = await sensorsRepo.GetByIDAsync(sensorId);
			return mapper.Map<SensorDto>(sensor);
		}
		public async Task<SensorDto> GetSensorByIPAsync(string ipAddress)
		{
			Sensor? sensorWithIP = await sensorsRepo.GetItemBySpecAsync(new SensorSpecs.ByIp(ipAddress));
			if (sensorWithIP == null)
				throw new Exception("Not found sensor by IP");
			return mapper.Map<SensorDto>(sensorWithIP);
		}
		public async Task RemoveSensorAsync(int sensorId)
		{
			var sensor = await sensorsRepo.GetByIDAsync(sensorId);
			if (sensor != null)
			{
				await sensorsRepo.DeleteAsync(sensorId);
				await sensorsRepo.SaveAsync();
			}
		}
		public async Task UpdateSensorAsync(int sensorId, SensorDto sensor)
		{
			var existingSensor = await sensorsRepo.GetByIDAsync(sensorId);
			if (existingSensor != null)
			{
				// TODO Send new data to sensor
				mapper.Map(sensor, existingSensor);
				sensorsRepo.Update(existingSensor);
				await sensorsRepo.SaveAsync();
			}
		}
		public async Task<SensorDto> GetSensorByMacAsync(string macAddress)
		{
			Sensor? sensorWithMac = await sensorsRepo.GetItemBySpecAsync(new SensorSpecs.ByMac(macAddress));
			if (sensorWithMac == null)
				throw new Exception("Not found sensor by MAC-Address");
			return mapper.Map<SensorDto>(sensorWithMac);
		}
		public async Task<HttpResponseMessage> GetNewDataStamsAsync(SensorDto sensor)
		{
			using (var client = new HttpClient())
			{
				string url = $"http://{sensor.SensorIP}/getNewValues";

				HttpResponseMessage response = await client.GetAsync(url);

				return response;
			}
		}
	}
}
