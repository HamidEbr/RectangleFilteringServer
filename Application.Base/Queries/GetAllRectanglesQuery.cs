using Domain.Core.Models;
using Domain.Core.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Base.Queries
{
    public class GetAllRectanglesQuery : IRequest<IEnumerable<RectangleModel>>
    {
    }

    public class GetAllRectanglesQueryHandler : BaseQueryHandler, IRequestHandler<GetAllRectanglesQuery, IEnumerable<RectangleModel>>
    {
        private readonly IRectangleRepository _rectangleRepository;

        public GetAllRectanglesQueryHandler(IRectangleRepository rectangleRepository)
        {
            _rectangleRepository = rectangleRepository;
        }

        public async Task<IEnumerable<RectangleModel>> Handle(GetAllRectanglesQuery request, CancellationToken cancellationToken)
        {
            return await _rectangleRepository.GetAllAsync();
        }
    }
}
