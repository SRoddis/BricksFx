using System.Collections.Generic;

namespace BricksFx.Core.Module
{
    public interface IBrickRegistration
    {
        void Register(IEnumerable<IBrick> bricks);
    }
}