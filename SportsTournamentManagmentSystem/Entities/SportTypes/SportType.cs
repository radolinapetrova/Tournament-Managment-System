using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class SportType
    {
        public abstract override string ToString();

        public abstract void CheckResult(int result1, int result2);

        public static List<SportType> SportTypes { get { return GetST(); } }

        private static List<SportType> GetST()
        {
            List<SportType> objects = new List<SportType>();
            foreach (Type type in
                Assembly.GetAssembly(typeof(SportType)).GetTypes()
                .Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(SportType))))
            {
                objects.Add((SportType)Activator.CreateInstance(type));

            }
            return objects;
        }

        public static SportType GetST(string sport)
        {
            return SportTypes.Find(st => st.ToString() == sport);
        }
    }
}
