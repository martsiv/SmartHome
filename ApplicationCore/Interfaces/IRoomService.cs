using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface IRoomService
	{
		Task AddRoomAsync(RoomDto room);
		Task RemoveRoomAsync(int roomId);
		Task UpdateRoomAsync(int roomId, RoomDto room);
		Task<IEnumerable<RoomDto>> GetAllRoomsAsync();
		Task<RoomDto> GetRoomByIdAsync(int roomId);
	}
}
