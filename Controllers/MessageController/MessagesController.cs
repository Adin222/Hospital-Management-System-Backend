using Hospital_Management_System.Services.MessageServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers.MessageController
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("{chatName}")]
        [Authorize]
        public async Task<IActionResult> GetAllMessages(string chatName)
        {
            var messages = await _messageService.GetAllChatMessagesAsync(chatName);
            return Ok(messages);
        }
    }
}
