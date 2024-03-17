using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using AutoMapper;

namespace ApplicationCore.Services
{
	public class NotificationTypeService : INotificationTypeService
	{
		private readonly IMapper mapper;
		private readonly IRepository<NotificationType> notificationTypesRepo;
		public NotificationTypeService(IMapper mapper,
							IRepository<NotificationType> notificationTypesRepo)
        {
            this.mapper = mapper;
			this.notificationTypesRepo = notificationTypesRepo;
        }

		public void AddNotificationType(NotificationTypeDto notificationTypeDto)
		{
			var entity = mapper.Map<NotificationType>(notificationTypeDto);
			notificationTypesRepo.Insert(entity);
			notificationTypesRepo.Save();
		}

		public async Task AddNotificationTypeAsync(NotificationTypeDto notificationTypeDto)
		{
			var entity = mapper.Map<NotificationType>(notificationTypeDto);
			await notificationTypesRepo.InsertAsync(entity);
			await notificationTypesRepo.SaveAsync();
		}

		public IEnumerable<NotificationTypeDto> GetAllNotificationTypes()
		{
			var notificationTypes = notificationTypesRepo.GetAll();
			return mapper.Map<IEnumerable<NotificationTypeDto>>(notificationTypes);
		}

		public async Task<IEnumerable<NotificationTypeDto>> GetAllNotificationTypesAsync()
		{
			var notificationTypes = await notificationTypesRepo.GetAllAsync();
			return mapper.Map<IEnumerable<NotificationTypeDto>>(notificationTypes);
		}

		public NotificationTypeDto? GetNotificationType(int notificationTypeId)
		{
			var entity = notificationTypesRepo.GetByID(notificationTypeId);
			if (entity == null) return null;
			return mapper.Map<NotificationTypeDto>(entity);
		}

		public async Task<NotificationTypeDto?> GetNotificationTypeAsync(int notificationTypeId)
		{
			var entity = await notificationTypesRepo.GetByIDAsync(notificationTypeId);
			if (entity == null) return null;
			return mapper.Map<NotificationTypeDto>(entity);
		}

		public NotificationTypeDto? GetNotificationTypeByLevel(int level)
		{
			var entity = notificationTypesRepo.GetItemBySpec(new NotificationTypeSpecs.ByLevel(level));
			if (entity == null) return null;
			return mapper.Map<NotificationTypeDto>(entity);
		}

		public async Task<NotificationTypeDto?> GetNotificationTypeByLevelAsync(int level)
		{
			var entity = await notificationTypesRepo.GetItemBySpecAsync(new NotificationTypeSpecs.ByLevel(level));
			if (entity == null) return null;
			return mapper.Map<NotificationTypeDto>(entity);
		}

		public void RemoveNotificationType(int notificationTypeId)
		{
			var entity = notificationTypesRepo.GetByID(notificationTypeId);
			if (entity != null)
			{
				notificationTypesRepo.Delete(notificationTypeId);
				notificationTypesRepo.Save();
			}
		}

		public async Task RemoveNotificationTypeAsync(int notificationTypeId)
		{
			var entity = await notificationTypesRepo.GetByIDAsync(notificationTypeId);
			if (entity != null)
			{
				await notificationTypesRepo.DeleteAsync(notificationTypeId);
				await notificationTypesRepo.SaveAsync();
			}
		}

		public void UpdateNotificationType(int notificationTypeId, NotificationTypeDto notificationTypeDto)
		{
			var existingEntity = notificationTypesRepo.GetByID(notificationTypeId);
			if (existingEntity != null)
			{
				mapper.Map(notificationTypeDto, existingEntity);
				notificationTypesRepo.Update(existingEntity);
				notificationTypesRepo.Save();
			}
		}

		public async Task UpdateNotificationTypeAsync(int notificationTypeId, NotificationTypeDto notificationTypeDto)
		{
			var existingEntity = await notificationTypesRepo.GetByIDAsync(notificationTypeId);
			if (existingEntity != null)
			{
				mapper.Map(notificationTypeDto, existingEntity);
				notificationTypesRepo.Update(existingEntity);
				await notificationTypesRepo.SaveAsync();
			}
		}
	}
}
