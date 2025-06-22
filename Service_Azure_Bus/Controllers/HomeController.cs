using Microsoft.AspNetCore.Mvc;
using Service_Azure_Bus.AzureServiceBus;

namespace Service_Azure_Bus.Controllers
{
    public class HomeController : Controller
    {
        private readonly MessagePublisher _messagePublisher;
        public HomeController(MessagePublisher messagePublisher)
        {
            _messagePublisher = messagePublisher;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] MessageRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Topic) || string.IsNullOrWhiteSpace(request.Message))
            {
                return BadRequest("Topic and Message are required.");
            }

            await _messagePublisher.PublishAsync(request.Topic, request.Message);
            return Ok("Message sent successfully.");
        }
    }

    public class MessageRequest
    {
        public string Topic { get; set; }
        public string Message { get; set; }
    }
}
