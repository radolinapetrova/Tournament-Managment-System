using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IGame
    {
        public void Add(Tournament t);


        public void Result(Tournament t, Game game);
    }
}
