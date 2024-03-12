using ApplicationCore.DTOs;
using ApplicationCore.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoomController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly IRoomService _roomService;
		private readonly IMapper _mapper;

		public RoomController(IConfiguration configuration,
								IRoomService roomService,
								IMapper mapper)
		{
			this._configuration = configuration;
			this._roomService = roomService;
			this._mapper = mapper;
		}
		[HttpPost("AddRoomAsync")]
		public async Task<IActionResult> AddRoom(RoomDto room) => await ExecuteServiceActionAsync(() => _roomService.AddRoomAsync(room));
		[HttpGet("GetAllRoomsAsync")]
		public async Task<IActionResult> GetAllRooms() => Ok(await _roomService.GetAllRoomsAsync());
		[HttpGet("GetRoomByIdAsync/{roomId}")]
		public async Task<IActionResult> GetRoomById(int roomId) => Ok(await _roomService.GetRoomByIdAsync(roomId));

		[HttpDelete("RemoveRoomAsync/{roomId}")]
		public async Task<IActionResult> RemoveRoom(int roomId) => await ExecuteServiceActionAsync(() => _roomService.RemoveRoomAsync(roomId));
		[HttpPut("UpdateRoomAsync/{roomId}")]
		public async Task<IActionResult> UpdateRoom(int roomId, RoomDto room) => await ExecuteServiceActionAsync(() => _roomService.UpdateRoomAsync(roomId, room));
		private async Task<IActionResult> ExecuteServiceActionAsync(Action action)
		{
			try
			{
				action();
				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}
	}
}
