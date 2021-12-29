using Domain.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Base.Commands
{
    public class CreateRectanglesQuery : IRequest<Unit>
    {
        public Rectangle Main { get; set; }
        public IEnumerable<Rectangle> Input { get; set; }

        public CreateRectanglesQuery(Rectangle main, IEnumerable<Rectangle> inputs)
        {
            Main = main;
            Input = inputs;
        }
    }

    public class CreateRectanglesQueryQueryHandler : BaseCommandHandler, IRequestHandler<CreateRectanglesQuery, Unit>
    {
        private readonly IRectangleRepository _rectangleRepository;

        public CreateRectanglesQueryQueryHandler(IRectangleRepository rectangleRepository)
        {
            _rectangleRepository = rectangleRepository;
        }

        public async Task<Unit> Handle(CreateRectanglesQuery request, CancellationToken cancellationToken)
        {
            foreach (var rectangle in request.Input)
            {
                if (HasRectangleOverlap(request.Main, rectangle))
                {
                    await _rectangleRepository.InsertAsync(new Domain.Core.Models.RectangleModel()
                    {
                        X = rectangle.X,
                        Y = rectangle.Y,
                        Width = rectangle.Width,
                        Height = rectangle.Height,
                        Time = DateTime.Now
                    });
                }
            }
            return Unit.Value;
        }

        public bool HasRectangleOverlap(Rectangle r1, Rectangle r2)
        {
            var area = (Math.Max(r1.Left, r2.Left) - Math.Min(r1.Right, r2.Right))
                * (Math.Max(r1.Top, r2.Top) - Math.Min(r1.Bottom, r2.Bottom));
            return area > 0;
        }
    }
}
