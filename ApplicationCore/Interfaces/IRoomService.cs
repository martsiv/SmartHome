using ApplicationCore.DTOs;

namespace ApplicationCore.Interfaces
{
	public interface IRoomService
	{
		void AddRoom(RoomDto room);
		void RemoveRoom(int roomId);
		void UpdateRoom(int roomId, RoomDto room);
		IEnumerable<RoomDto> GetAllRooms();
		RoomDto? GetRoomById(int roomId);
		Task AddRoomAsync(RoomDto room);
		Task RemoveRoomAsync(int roomId);
		Task UpdateRoomAsync(int roomId, RoomDto room);
		Task<IEnumerable<RoomDto>> GetAllRoomsAsync();
		Task<RoomDto?> GetRoomByIdAsync(int roomId);
	}
}
