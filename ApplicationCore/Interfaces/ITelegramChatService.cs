using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface ITelegramChatService
	{
		Task AddTelegramChatAsync(TelegramChatDto telegramChatDto);
		Task<IEnumerable<TelegramChatDto>> GetAllTelegramChatsAsync();
		Task<TelegramChatDto> GetTelegramChatAsync(int telegramChatId);
		Task UpdateTelegramChatAsync(int telegramChatId, TelegramChatDto telegramChatDto);
		Task RemoveTelegramChatAsync(int telegramChatId);
	}
}
