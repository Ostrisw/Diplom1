using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dip
{
    class DBObject
    {
        public static MyEntities Entites { get; } = new MyEntities();
    }
}
