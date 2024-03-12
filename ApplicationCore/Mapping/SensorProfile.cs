using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

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
			CreateMap<IdentityUser, UserDto>().ReverseMap();
			CreateMap<EditSensorDto, Sensor>().ReverseMap();
			CreateMap<Indicator, IndicatorDto>().ReverseMap();
			CreateMap<NotificationType, NotificationTypeDto>().ReverseMap();
			CreateMap<SensorDataIndicator, SensorDataIndicatorDto>().ReverseMap();
			CreateMap<SensorDataStamp, SensorDataStampDto>().ReverseMap();
			CreateMap<Subscription, SubscriptionDto>().ReverseMap();
		}
    }
}
