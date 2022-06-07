using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface ITournamentReader
    {
        public void Read(List<Tournament> list, int limit, int offset);

        public void Read(List<Tournament> list);
    }
}
