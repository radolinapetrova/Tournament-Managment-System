using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface ICUDTournament
    {
        public void Update(Tournament t);

        public void Cancel(int id);    
        public void Delete(int id);    

        public void Add(Tournament t);


    }
}
