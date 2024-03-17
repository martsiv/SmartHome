using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;

namespace ApplicationCore.Services
{
	public class TelegramChatService : ITelegramChatService
	{
		private readonly IMapper mapper;
		private readonly IRepository<TelegramChatEntity> telegramChatEntitiesRepo;
        public TelegramChatService(IMapper mapper,
							IRepository<TelegramChatEntity> telegramChatEntitiesRepo)
        {
            this.mapper = mapper;
			this.telegramChatEntitiesRepo = telegramChatEntitiesRepo;
        }

		public void AddTelegramChat(TelegramChatDto telegramChatDto)
		{
			var entity = mapper.Map<TelegramChatEntity>(telegramChatDto);
			telegramChatEntitiesRepo.Insert(entity);
			telegramChatEntitiesRepo.Save();
		}

		public async Task AddTelegramChatAsync(TelegramChatDto telegramChatDto)
		{
			var entity = mapper.Map<TelegramChatEntity>(telegramChatDto);
			await telegramChatEntitiesRepo.InsertAsync(entity);
			await telegramChatEntitiesRepo.SaveAsync();
		}

		public IEnumerable<TelegramChatDto> GetAllTelegramChats()
		{
			var telegramChatEntities = telegramChatEntitiesRepo.GetAll();
			return mapper.Map<IEnumerable<TelegramChatDto>>(telegramChatEntities);
		}

		public async Task<IEnumerable<TelegramChatDto>> GetAllTelegramChatsAsync()
		{
			var telegramChatEntities = await telegramChatEntitiesRepo.GetAllAsync();
			return mapper.Map<IEnumerable<TelegramChatDto>>(telegramChatEntities);
		}

		public TelegramChatDto? GetTelegramChat(int telegramChatId)
		{
			var entity = telegramChatEntitiesRepo.GetByID(telegramChatId);
			if (entity == null) return null;
			return mapper.Map<TelegramChatDto>(entity);
		}

		public async Task<TelegramChatDto?> GetTelegramChatAsync(int telegramChatId)
		{
			var entity = await telegramChatEntitiesRepo.GetByIDAsync(telegramChatId);
			if (entity == null) return null;
			return mapper.Map<TelegramChatDto>(entity);
		}

		public void RemoveTelegramChat(int telegramChatId)
		{
			var entity = telegramChatEntitiesRepo.GetByID(telegramChatId);
			if (entity != null)
			{
				telegramChatEntitiesRepo.Delete(telegramChatId);
				telegramChatEntitiesRepo.Save();
			}
		}

		public async Task RemoveTelegramChatAsync(int telegramChatId)
		{
			var entity = await telegramChatEntitiesRepo.GetByIDAsync(telegramChatId);
			if (entity != null)
			{
				await telegramChatEntitiesRepo.DeleteAsync(telegramChatId);
				await telegramChatEntitiesRepo.SaveAsync();
			}
		}

		public void UpdateTelegramChat(int telegramChatId, TelegramChatDto telegramChatDto)
		{
			var existingEntity = telegramChatEntitiesRepo.GetByID(telegramChatId);
			if (existingEntity != null)
			{
				mapper.Map(telegramChatDto, existingEntity);
				telegramChatEntitiesRepo.Update(existingEntity);
				telegramChatEntitiesRepo.Save();
			}
		}

		public async Task UpdateTelegramChatAsync(int telegramChatId, TelegramChatDto telegramChatDto)
		{
			var existingEntity = await telegramChatEntitiesRepo.GetByIDAsync(telegramChatId);
			if (existingEntity != null)
			{
				mapper.Map(telegramChatDto, existingEntity);
				telegramChatEntitiesRepo.Update(existingEntity);
				await telegramChatEntitiesRepo.SaveAsync();
			}
		}
	}
}
