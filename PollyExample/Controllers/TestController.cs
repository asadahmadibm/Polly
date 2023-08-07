using Microsoft.AspNetCore.Mvc;
using Polly;
using System.Net.Mail;

namespace PollyExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ISomeService _someService;

        public TestController(ISomeService someService)
        {
            _someService = someService;
        }
        [HttpGet]
        public async Task<IActionResult> GetRetry3(CancellationToken cancellationToken)
        {

            var policy = Policy.Handle<InvalidOperationException>().Retry(3);
            policy.Execute(() => _someService.DoSomething(cancellationToken));

            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetWaitAndRetry(CancellationToken cancellationToken)
        {

            var policy = Policy.Handle<InvalidOperationException>().WaitAndRetry(3,);
            policy.Execute(() => _someService.DoSomething(cancellationToken));

            return Ok();
        }
    }
}
