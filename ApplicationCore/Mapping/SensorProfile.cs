using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using AutoMapper;

namespace ApplicationCore.Mapping
{
	public class SensorProfile : Profile
	{
        public SensorProfile()
        {
			CreateMap<RegisterSensorModel, Sensor>();
			CreateMap<RegisterSensorModel, SensorDto>();
			CreateMap<Sensor, SensorDto>().ReverseMap();
			CreateMap<Notification, NotificationDto>().ReverseMap();
			CreateMap<NewNotificationModel, Notification>();
			CreateMap<Room, RoomDto>().ReverseMap();
			CreateMap<SensorSetting, SensorSettingDto>().ReverseMap();
			CreateMap<SensorType, SensorTypeDto>().ReverseMap();
			CreateMap<Setting, SettingDto>().ReverseMap();
			CreateMap<State, StateDto>().ReverseMap();
			CreateMap<User, UserDto>().ReverseMap();
		}
    }
}
