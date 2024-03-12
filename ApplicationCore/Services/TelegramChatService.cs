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

		public async Task AddTelegramChatAsync(TelegramChatDto telegramChatDto)
		{
			var entity = mapper.Map<TelegramChatEntity>(telegramChatDto);
			await telegramChatEntitiesRepo.InsertAsync(entity);
			await telegramChatEntitiesRepo.SaveAsync();
		}

		public async Task<IEnumerable<TelegramChatDto>> GetAllTelegramChatsAsync()
		{
			var telegramChatEntities = await telegramChatEntitiesRepo.GetAllAsync();
			return mapper.Map<IEnumerable<TelegramChatDto>>(telegramChatEntities);
		}

		public async Task<TelegramChatDto> GetTelegramChatAsync(int telegramChatId)
		{
			var entity = await telegramChatEntitiesRepo.GetByIDAsync(telegramChatId);
			return mapper.Map<TelegramChatDto>(entity);
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
