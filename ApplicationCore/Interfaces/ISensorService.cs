﻿using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface ISensorService
	{
		IEnumerable<NotificationDto> UpdateNotifications(int sensorId);
		IEnumerable<NotificationDto> GetLastNotifications(int sensorId);
		Task<HttpResponseMessage> GetNewDataStams(SensorDto sensor);

		void InsertNotification(NotificationDto notificationDto);

		SensorDto RegisterSensor(RegisterSensorModel registerSensorModel);
		LoginSensorResponseModel LoginSensor(SensorDto sensor);
		void RemoveSensor(int sensorId);
		void UpdateSensor(int sensorId, SensorDto sensor);
		IEnumerable<SensorDto> GetAllSensors();
		SensorDto GetSensorById(int sensorId);
		Task<SensorDto> GetSensorByIPAsync(string ipAddress);
		Task<SensorDto> GetSensorByMacAsync(string macAddress);

		void AddRoom(RoomDto room);
		void RemoveRoom(int roomId);
		void UpdateRoom(int roomId, RoomDto room);
		IEnumerable<RoomDto> GetAllRooms();
		RoomDto GetRoomById(int roomId);

		void AddSensorType(SensorTypeDto sensorType);
		void RemoveSensorType(int sensorTypeId);
		void UpdateSensorType(int sensorTypeId, SensorTypeDto sensorType);
		IEnumerable<SensorTypeDto> GetAllSensorTypes();
		SensorTypeDto GetSensorTypeById(int sensorTypeId);

		void AddState(StateDto state);
		void RemoveState(int stateId);
		void UpdateState(int stateId, StateDto state);
		IEnumerable<StateDto> GetAllStates();
		StateDto GetStateById(int stateId);

		void AddSetting(SettingDto setting);
		void RemoveSetting(int settingId);
		void UpdateSetting(int settingId, SettingDto setting);
		IEnumerable<SettingDto> GetAllSettings();
		SettingDto GetSettingById(int settingId);

		void AddSensorSetting(SensorSettingDto sensorSetting);
		void RemoveSensorSetting(int sensorSettingId);
		Task RemoveSensorSettingsBySensorAsync(int sensorId);
		void UpdateSensorSetting(int sensorSettingId, SensorSettingDto sensorSetting);
		IEnumerable<SensorSettingDto> GetAllSensorSettings();
		SensorSettingDto GetSensorSettingById(int sensorSettingId);
		Task<IEnumerable<SensorSettingDto>> GetSensorSettingsBySensorIdAsync(int sensorId);
	}
}
