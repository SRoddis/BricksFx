using System.Collections.Generic;

namespace BricksFx.Module
{
    public interface IBrickRegistration
    {
        void Register(IEnumerable<IBrick> bricks);
    }
}