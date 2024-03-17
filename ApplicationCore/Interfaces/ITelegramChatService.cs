using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface ITelegramChatService
	{
		void AddTelegramChat(TelegramChatDto telegramChatDto);
		IEnumerable<TelegramChatDto> GetAllTelegramChats();
		TelegramChatDto? GetTelegramChat(int telegramChatId);
		void UpdateTelegramChat(int telegramChatId, TelegramChatDto telegramChatDto);
		void RemoveTelegramChat(int telegramChatId);
		Task AddTelegramChatAsync(TelegramChatDto telegramChatDto);
		Task<IEnumerable<TelegramChatDto>> GetAllTelegramChatsAsync();
		Task<TelegramChatDto?> GetTelegramChatAsync(int telegramChatId);
		Task UpdateTelegramChatAsync(int telegramChatId, TelegramChatDto telegramChatDto);
		Task RemoveTelegramChatAsync(int telegramChatId);
	}
}
