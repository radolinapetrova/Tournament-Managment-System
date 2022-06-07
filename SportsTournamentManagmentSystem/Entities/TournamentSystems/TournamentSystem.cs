using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class TournamentSystem
    {
        public static List<TournamentSystem> Systems { get { return GetTS(); } }

        public abstract void GetGames(Tournament t);

        public abstract override string ToString();


        private static List<TournamentSystem> GetTS()
        {
            List<TournamentSystem> objects = new List<TournamentSystem>();
            foreach (Type type in
                Assembly.GetAssembly(typeof(TournamentSystem)).GetTypes()
                .Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(TournamentSystem))))
            {
                objects.Add((TournamentSystem)Activator.CreateInstance(type));
                
            }
            return objects;
        }

        public static TournamentSystem GetTS(string ts)
        {
            return Systems.Find(x => x.ToString() == ts);
        }

    }
}
