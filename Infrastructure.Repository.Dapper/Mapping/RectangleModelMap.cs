using Dapper.FluentMap.Mapping;
using Domain.Core.Models;

namespace Infrastructure.Repository.Dapper.Mapping
{
    public class RectangleModelMap : EntityMap<RectangleModel>
    {
        public RectangleModelMap()
        {
            Map(p => p.Id).ToColumn("id");
            Map(p => p.X).ToColumn("x");
            Map(p => p.Y).ToColumn("y");
            Map(p => p.Width).ToColumn("width");
            Map(p => p.Height).ToColumn("height");
            Map(p => p.Time).ToColumn("time");
        }
    }
}
