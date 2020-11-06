using Reinforced.Tecture.Channels;

namespace ProductsApp.Core.Channels
{
    public interface Db : 
        CommandQueryChannel<
            Reinforced.Tecture.Aspects.Orm.Command,
            Reinforced.Tecture.Aspects.Orm.Query
        >
    {
    }
}