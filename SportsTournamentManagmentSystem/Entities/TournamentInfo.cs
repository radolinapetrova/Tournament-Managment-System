using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TournamentInfo
    {
        private SportType sport;
        private string description;
        private DateTime startDate;
        private DateTime endDate;
        private int minPlayers;
        private int maxPlayers;
        private string location;
        private int n;//count of the players for when there is no need for all the users to be loaded
        private TournamentSystem ts;



        public SportType Sport { get { return sport; } private set { this.sport = value; } }
        public string Description { get { return description; } private set { this.description = value; } }
        public DateTime StartDate
        {
            get { return startDate; }
            private set
            {
                if (value.CompareTo(DateTime.Today.AddDays(14)) < 0)
                {
                    throw new Exception("The start date of the tournament must be at least two weeks from now!");
                }
                this.startDate = value;
            }
        }
        public DateTime EndDate
        {
            get { return endDate; }

            private set
            {
                if (this.startDate.CompareTo(value) > 0)
                {
                    throw new Exception("The end date of the tournament must be later than the start date!");
                }
                this.endDate = value;
            }
        }
        public int MinPlayers
        {
            get { return minPlayers; }
            private set
            {
                if (value < 2)
                {
                    throw new Exception("The minimum number of players must be at least 2!");
                }
                this.minPlayers = value;
            }
        }
        public int MaxPlayers
        {
            get { return maxPlayers; }
            private set
            {
                if (value < 2 || value < this.minPlayers)
                {
                    throw new Exception("The maximum number of players must be at least 2 and bigger than or equal to the minimum number!");
                }
                this.maxPlayers = value;
            }
        }
        public TournamentSystem System { get { return ts; } private set { this.ts = value; } }
        public string Location { get { return location; } private set { this.location = value; } }

        

        public TournamentInfo(SportType sport, string description, DateTime startDate, DateTime endDate, int minPlayers, int maxPlayers, string location, TournamentSystem ts)
        {
            this.Sport = sport;
            this.Description = description;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.MinPlayers = minPlayers;
            this.MaxPlayers = maxPlayers;
            this.Location = location;
            this.System = ts;
        }

        public TournamentInfo(SportType sport, string description, string startDate, string endDate, int minPlayers, int maxPlayers, string location, TournamentSystem ts)
        {
            DateTime start = DateTime.ParseExact(startDate, "yyyy-MM-dd", null);
            DateTime end = DateTime.ParseExact(endDate, "yyyy-MM-dd", null);

            this.sport = sport;
            this.description = description;
            this.startDate = start;
            this.EndDate = end;
            this.MinPlayers = minPlayers;
            this.MaxPlayers = maxPlayers;
            this.location = location;
            this.ts = ts;
        }
    }
}
