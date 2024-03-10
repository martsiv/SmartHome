using ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
	public interface ISensorService
	{
		IEnumerable<NotificationDto> UpdateNotifications(int sensorId);
		IEnumerable<NotificationDto> GetLastNotifications(int sensorId);
		void InsertNotification(NotificationDto notificationDto);

		SensorDto RegisterSensor(RegisterSensorModel registerSensorModel);
		LoginSensorResponseModel LoginSensor(SensorDto sensor);
		void RemoveSensor(int sensorId);
		void UpdateSensor(int sensorId, SensorDto sensor);
		IEnumerable<SensorDto> GetAllSensors();
		SensorDto GetSensorById(int sensorId);
		SensorDto GetSensorByIP(string ipAddress);
		SensorDto GetSensorByMac(string macAddress);

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
		void RemoveSensorSettingsBySensor(int sensorId);
		void UpdateSensorSetting(int sensorSettingId, SensorSettingDto sensorSetting);
		IEnumerable<SensorSettingDto> GetAllSensorSettings();
		SensorSettingDto GetSensorSettingById(int sensorSettingId);
		IEnumerable<SensorSettingDto> GetSensorSettingsBySensorId(int sensorId);
	}
}
