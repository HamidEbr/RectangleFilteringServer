using Domain.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Core.Repositories
{
    public interface IRectangleRepository
    {
        Task<IEnumerable<RectangleModel>> GetAllAsync();
        Task<long> InsertAsync(RectangleModel rectangleModel);

    }
}
