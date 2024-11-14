using Hospital_Management_System.Services.ChatServices;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers.ChatController
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatsController : ControllerBase
    {
        private readonly IChatService _chatService;
        public ChatsController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetChats(int Id)
        {
            var chats = await _chatService.GetAllChatsByUserId(Id);
            return Ok(chats);
        }

        [HttpDelete("chat/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteChat(int id)
        {
            await _chatService.DeleteChatById(id);
            return Ok("Chat has been successfully deleted");
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAllChats(int id)
        {
            await _chatService.DeleteAllChatsAsync(id);
            return Ok("All chats have bees successfully deleted");
        }
    }
}
