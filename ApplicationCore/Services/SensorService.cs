using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
	public class SensorService : ISensorService
	{
		private readonly IJwtService jwtService;
		private readonly IMapper mapper;
		private readonly IRepository<Notification> notificationsRepo;
		private readonly IRepository<Room> roomsRepo;
		private readonly IRepository<Sensor> sensorsRepo;
		private readonly IRepository<SensorSetting> sensorSettingsRepo;
		private readonly IRepository<SensorType> sensorTypesRepo;
		private readonly IRepository<Setting> settingsRepo;
		private readonly IRepository<State> statesRepo;

        public SensorService(IJwtService jwtService,
							IMapper mapper,
							IRepository<Notification> notificationsRepo,
							IRepository<Room> roomsRepo,
							IRepository<Sensor> sensorsRepo,
							IRepository<SensorSetting> sensorSettingsRepo,
							IRepository<SensorType> sensorTypesRepo,
							IRepository<Setting> settingsRepo,
							IRepository<State> statesRepo)
        {
			this.jwtService = jwtService;
			this.mapper = mapper;
            this.notificationsRepo = notificationsRepo;
			this.roomsRepo = roomsRepo;
			this.sensorsRepo = sensorsRepo;
			this.sensorSettingsRepo = sensorSettingsRepo;
			this.sensorTypesRepo = sensorTypesRepo;
			this.settingsRepo = settingsRepo;
			this.statesRepo = statesRepo;
        }

		public void AddRoom(RoomDto room)
		{
			var entity = mapper.Map<Room>(room);
			roomsRepo.Insert(entity);
			roomsRepo.Save();
		}

		public SensorDto RegisterSensor(RegisterSensorModel registerSensorModel)
		{
			var entity = mapper.Map<Sensor>(registerSensorModel);
			sensorsRepo.Insert(entity);
			sensorsRepo.Save();

			return mapper.Map<SensorDto>(entity);
		}
		public LoginSensorResponseModel LoginSensor(SensorDto sensor)
		{
			return new LoginSensorResponseModel() { Token = jwtService.CreateToken(jwtService.GetClaims(sensor)) };
		}

		public void AddSensorSetting(SensorSettingDto sensorSetting)
		{
			var entity = mapper.Map<SensorSetting>(sensorSetting);
			sensorSettingsRepo.Insert(entity);
			sensorSettingsRepo.Save();
		}

		public void AddSensorType(SensorTypeDto sensorType)
		{
			var entity = mapper.Map<SensorType>(sensorType);
			sensorTypesRepo.Insert(entity);
			sensorTypesRepo.Save();
		}

		public void AddSetting(SettingDto setting)
		{
			var entity = mapper.Map<Setting>(setting);
			settingsRepo.Insert(entity);
			settingsRepo.Save();
		}

		public void AddState(StateDto state)
		{
			var entity = mapper.Map<State>(state);
			statesRepo.Insert(entity);
			statesRepo.Save();
		}

		public IEnumerable<RoomDto> GetAllRooms()
		{
			var rooms = roomsRepo.Get();
			return mapper.Map<IEnumerable<RoomDto>>(rooms);
		}

		public IEnumerable<SensorDto> GetAllSensors()
		{
			var sensors = sensorsRepo.Get();
			return mapper.Map<IEnumerable<SensorDto>>(sensors);
		}

		public IEnumerable<SensorSettingDto> GetAllSensorSettings()
		{
			var sensorSettings = sensorSettingsRepo.Get();
			return mapper.Map<IEnumerable<SensorSettingDto>>(sensorSettings);
		}

		public IEnumerable<SensorTypeDto> GetAllSensorTypes()
		{
			var sensorTypes = sensorTypesRepo.Get();
			return mapper.Map<IEnumerable<SensorTypeDto>>(sensorTypes);
		}

		public IEnumerable<SettingDto> GetAllSettings()
		{
			var settings = settingsRepo.Get();
			return mapper.Map<IEnumerable<SettingDto>>(settings);
		}

		public IEnumerable<StateDto> GetAllStates()
		{
			var states = statesRepo.Get();
			return mapper.Map<IEnumerable<StateDto>>(states);
		}

		public RoomDto GetRoomById(int roomId)
		{
			var room = roomsRepo.GetByID(roomId);
			return mapper.Map<RoomDto>(room);
		}

		public SensorDto GetSensorById(int sensorId)
		{
			var sensor = sensorsRepo.GetByID(sensorId);
			return mapper.Map<SensorDto>(sensor);
		}
		public SensorDto GetSensorByIP(string ipAddress)
		{
			// Filter for getting sensor by IP
			Expression<Func<Sensor, bool>> filter = sensor => sensor.SensorIP == ipAddress;
			// Invoke method with filter
			IEnumerable<Sensor> sensors = sensorsRepo.Get(filter);
			Sensor sensorWithIP = sensors.FirstOrDefault();
			return mapper.Map<SensorDto>(sensorWithIP);
		}

		public SensorSettingDto GetSensorSettingById(int sensorSettingId)
		{
			var sensorSetting = sensorSettingsRepo.GetByID(sensorSettingId);
			return mapper.Map<SensorSettingDto>(sensorSetting);
		}

		public IEnumerable<SensorSettingDto> GetSensorSettingsBySensorId(int sensorId)
		{
			var sensorSettings = sensorSettingsRepo.Get(s => s.SensorId == sensorId);
			return mapper.Map<IEnumerable<SensorSettingDto>>(sensorSettings);
		}

		public SensorTypeDto GetSensorTypeById(int sensorTypeId)
		{
			var sensorType = sensorTypesRepo.GetByID(sensorTypeId);
			return mapper.Map<SensorTypeDto>(sensorType);
		}

		public SettingDto GetSettingById(int settingId)
		{
			var setting = settingsRepo.GetByID(settingId);
			return mapper.Map<SettingDto>(setting);
		}

		public StateDto GetStateById(int stateId)
		{
			var state = statesRepo.GetByID(stateId);
			return mapper.Map<StateDto>(state);
		}

		public void InsertNotification(NotificationDto notificationDto)
		{
			var notification = mapper.Map<Notification>(notificationDto);
			notificationsRepo.Insert(notification);
			notificationsRepo.Save();
		}

		public void RemoveRoom(int roomId)
		{
			var room = roomsRepo.GetByID(roomId);
			if (room != null)
			{
				roomsRepo.Delete(roomId);
				roomsRepo.Save();
			}
		}

		public void RemoveSensor(int sensorId)
		{
			var sensor = sensorsRepo.GetByID(sensorId);
			if (sensor != null)
			{
				sensorsRepo.Delete(sensorId);
				sensorsRepo.Save();
			}
		}

		public void RemoveSensorSetting(int sensorSettingId)
		{
			var sensorSetting = sensorSettingsRepo.GetByID(sensorSettingId);
			if (sensorSetting != null)
			{
				sensorSettingsRepo.Delete(sensorSettingId);
				sensorSettingsRepo.Save();
			}
		}

		public void RemoveSensorSettingsBySensor(int sensorId)
		{
			var sensorSettings = sensorSettingsRepo.Get(s => s.SensorId == sensorId);
			foreach (var setting in sensorSettings)
			{
				sensorSettingsRepo.Delete(setting);
			}
			sensorSettingsRepo.Save();
		}

		public void RemoveSensorType(int sensorTypeId)
		{
			var sensorType = sensorTypesRepo.GetByID(sensorTypeId);
			if (sensorType != null)
			{
				sensorTypesRepo.Delete(sensorTypeId);
				sensorTypesRepo.Save();
			}
		}

		public void RemoveSetting(int settingId)
		{
			var setting = settingsRepo.GetByID(settingId);
			if (setting != null)
			{
				settingsRepo.Delete(settingId);
				settingsRepo.Save();
			}
		}

		public void RemoveState(int stateId)
		{
			var state = statesRepo.GetByID(stateId);
			if (state != null)
			{
				statesRepo.Delete(stateId);
				statesRepo.Save();
			}
		}

		public void UpdateRoom(int roomId, RoomDto room)
		{
			var existingRoom = roomsRepo.GetByID(roomId);
			if (existingRoom != null)
			{
				mapper.Map(room, existingRoom);
				roomsRepo.Update(existingRoom);
				roomsRepo.Save();
			}
		}

		public void UpdateSensorType(int sensorTypeId, SensorTypeDto sensorType)
		{
			var existingSensorType = sensorTypesRepo.GetByID(sensorTypeId);
			if (existingSensorType != null)
			{
				mapper.Map(sensorType, existingSensorType);
				sensorTypesRepo.Update(existingSensorType);
				sensorTypesRepo.Save();
			}
		}

		public void UpdateSetting(int settingId, SettingDto setting)
		{
			var existingSetting = settingsRepo.GetByID(settingId);
			if (existingSetting != null)
			{
				mapper.Map(setting, existingSetting);
				settingsRepo.Update(existingSetting);
				settingsRepo.Save();
			}
		}

		public void UpdateState(int stateId, StateDto state)
		{
			var existingState = statesRepo.GetByID(stateId);
			if (existingState != null)
			{
				mapper.Map(state, existingState);
				statesRepo.Update(existingState);
				statesRepo.Save();
			}
		}

		public void UpdateSensor(int sensorId, SensorDto sensor)
		{
			var existingSensor = sensorsRepo.GetByID(sensorId);
			if (existingSensor != null)
			{
				// TODO Send new data to sensor
				mapper.Map(sensor, existingSensor);
				sensorsRepo.Update(existingSensor);
				sensorsRepo.Save();
			}
		}

		public void UpdateSensorSetting(int sensorSettingId, SensorSettingDto sensorSetting)
		{
			var existingSensorSetting = sensorSettingsRepo.GetByID(sensorSettingId);
			if (existingSensorSetting != null)
			{
				// TODO Send new settings to sensor
				mapper.Map(sensorSetting, existingSensorSetting);
				sensorSettingsRepo.Update(existingSensorSetting);
				sensorSettingsRepo.Save();
			}
		}

		public IEnumerable<NotificationDto> UpdateNotifications(int sensorId)
		{
			// Implement logic to update notifications for a given sensor ID
			throw new NotImplementedException();
		}

		public IEnumerable<NotificationDto> GetLastNotifications(int sensorId)
		{
			// Implement logic to retrieve last notifications for a given sensor ID
			throw new NotImplementedException();
		}

		public SensorDto GetSensorByMac(string macAddress)
		{
			// Filter for getting sensor by IP
			Expression<Func<Sensor, bool>> filter = sensor => sensor.MacAddress == macAddress;
			// Invoke method with filter
			IEnumerable<Sensor> sensors = sensorsRepo.Get(filter);
			Sensor sensorWithMac = sensors.FirstOrDefault();
			return mapper.Map<SensorDto>(sensorWithMac);
		}
	}
}
