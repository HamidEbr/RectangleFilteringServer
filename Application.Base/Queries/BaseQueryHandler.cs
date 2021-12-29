using Dapper.FluentMap;

namespace Application.Base.Queries
{
    public abstract class BaseQueryHandler
    {
        static BaseQueryHandler()
        {
            FluentMapper.Initialize(config =>
            {
                //config.AddMap(new BankModelMap());
            });
        }
    }
}
