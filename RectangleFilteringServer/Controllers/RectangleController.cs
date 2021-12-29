using Application.Base.Commands;
using Application.Base.Queries;
using Domain.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RectangleFilteringServer.ServiceModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RectangleFilteringServer.Controllers
{
    [ApiController]
    [Route("")]
    public class RectangleController : ControllerBase
    {
        private readonly ILogger<RectangleController> _logger;
        private readonly IMediator _mediator;

        public RectangleController(IMediator mediator, ILogger<RectangleController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RectangleModel>>> GetAsync()
        {
            var result = await _mediator.Send(new GetAllRectanglesQuery());
            return new OkObjectResult(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RectangleRequestModel rectangleRequest)
        {
            var mainRect = new System.Drawing.Rectangle(rectangleRequest.Main.X, rectangleRequest.Main.Y, rectangleRequest.Main.Width, rectangleRequest.Main.Height);
            var inputRects = rectangleRequest.Input.Select(i => new System.Drawing.Rectangle(i.X, i.Y, i.Width, i.Height));
            await _mediator.Send(new CreateRectanglesQuery(mainRect, inputRects));
            return new OkResult();
        }
    }
}
