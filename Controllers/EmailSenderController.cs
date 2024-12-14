using EmailSenderApi.Model.EmailSender;
using EmailSenderApi.Model.Infra;
using EmailSenderApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderApi.Controllers
{
    [Route("api/v1/email")]
    [ApiController]
    public class EmailSenderController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<EmailSenderController> _logger;

        public EmailSenderController(
            IEmailService emailService,
            ILogger<EmailSenderController> logger)
        {
            _emailService = emailService;
            _logger = logger;
        }

        [HttpPost("enviar")]
        public async Task<ActionResult<EmailSenderResponse>> SendEmail([FromBody] EmailSenderRequest email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var ret = await _emailService.SendEmail(email);
                return Ok(new { Status = "Sucesso", Data = ret });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Falha no envio do email");
                return StatusCode(500, new ErrorResponse("Error", "Falha de envio de email", ex.Message));
            }
        }
    }
}

