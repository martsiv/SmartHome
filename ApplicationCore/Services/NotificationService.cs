using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using AutoMapper;
using System.Net.Mail;

namespace ApplicationCore.Services
{
	public class NotificationService : INotificationService
	{
		private readonly IMapper mapper;
		private readonly IRepository<Notification> notificationsRepo;
        public NotificationService(IMapper mapper,
							IRepository<Notification> notificationsRepo)
        {
            this.mapper = mapper;
			this.notificationsRepo = notificationsRepo;
        }

		public IEnumerable<NotificationDto> GetAllNotifications()
		{
			var notifications = notificationsRepo.GetAll();
			return mapper.Map<IEnumerable<NotificationDto>>(notifications);
		}

		public async Task<IEnumerable<NotificationDto>> GetAllNotificationsAsync()
		{
			var notifications = await notificationsRepo.GetAllAsync();
			return mapper.Map<IEnumerable<NotificationDto>>(notifications);
		}

		public NotificationDto? GetLastNotifications(int sensorId)
		{
			var entity = notificationsRepo.GetItemBySpec(new NotificationSpecs.LastBySensor(sensorId));
			if (entity == null) return null;
			return mapper.Map<NotificationDto>(entity);
		}

		public async Task<NotificationDto?> GetLastNotificationsAsync(int sensorId)
		{
			var entity = await notificationsRepo.GetItemBySpecAsync(new NotificationSpecs.LastBySensor(sensorId));
			if (entity == null) return null;
			return mapper.Map<NotificationDto>(entity);
		}

		public NotificationDto? GetNotification(int notificationId)
		{
			var entity = notificationsRepo.GetByID(notificationId);
			if (entity == null) return null;
			return mapper.Map<NotificationDto>(entity);
		}

		public async Task<NotificationDto?> GetNotificationAsync(int notificationId)
		{
			var entity = await notificationsRepo.GetByIDAsync(notificationId);
			if (entity == null) return null;
			return mapper.Map<NotificationDto>(entity);
		}

		public void InsertNotification(NotificationDto notificationDto)
		{
			var entity = mapper.Map<Notification>(notificationDto);
			notificationsRepo.Insert(entity);
			notificationsRepo.Save();
		}

		public async Task InsertNotificationAsync(NotificationDto notificationDto)
		{
			var entity = mapper.Map<Notification>(notificationDto);
			await notificationsRepo.InsertAsync(entity);
			await notificationsRepo.SaveAsync();
		}

		public void RemoveNotification(int notificationId)
		{
			var entity = notificationsRepo.GetByID(notificationId);
			if (entity != null)
			{
				notificationsRepo.Delete(notificationId);
				notificationsRepo.Save();
			}
		}

		public async Task RemoveNotificationAsync(int notificationId)
		{
			var entity = await notificationsRepo.GetByIDAsync(notificationId);
			if (entity != null)
			{
				await notificationsRepo.DeleteAsync(notificationId);
				await notificationsRepo.SaveAsync();
			}
		}
	}
}
