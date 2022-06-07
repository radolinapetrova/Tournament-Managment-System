using Entities;

namespace BusinessLogic
{
    public class TournamentManager
    {

        ICUDTournament manager;
        IAutoIncrement autoIncr;
        ITournamentManager mngr;

        public TournamentManager(ICUDTournament manager, IAutoIncrement autoIncr, ITournamentReader reader, ITournamentManager mngr)
        {
            this.manager = manager;
            this.autoIncr = autoIncr;
            this.mngr = mngr;
            reader.Read(staffTournaments);

        }

        public TournamentManager(ICUDTournament manager, int limit, int offset, ITournamentReader reader)
        {
            this.manager = manager;
            reader.Read(userTournaments, limit, offset);
        }


        List<Tournament> staffTournaments = new List<Tournament>();
        List<Tournament> userTournaments = new List<Tournament>();

        public IList<Tournament> StaffTournaments { get { return staffTournaments.AsReadOnly(); } }
        public IList<Tournament> UserTournaments { get { return userTournaments.AsReadOnly(); } }

        public Tournament GetTournamentById(int id)
        {
            return userTournaments.Find(x => x.Id == id);
        }

        public void Add(Tournament t)
        {
            manager.Add(t);
            staffTournaments.Add(t);
        }

        public void Update(Tournament t)
        {
            if (t.Status == Status.canceled || t.Status == Status.finished)
            {
                throw new Exception("You can't update the information of finished or canceled tournaments!");
            }
            manager.Update(t);
            int i = staffTournaments.FindIndex(x => x.Id == t.Id);
            staffTournaments[i] = t;
        }

        public void Cancel(Tournament t)
        {
            if (t.Status == Status.canceled || t.Status == Status.finished)
            {
                throw new Exception("The tournament can't be canceled!");
            }
            t.SetStatus(Status.canceled);
            manager.Cancel(t.Id);
        }

        public void Delete(Tournament t)
        {
            if (t.Status == Status.open && t.Users.Count < 1)
            {
                staffTournaments.Remove(t);
                manager.Delete(t.Id);
            }
           
            throw new Exception("The tournament can't be deleted!");
        }

        public int GetId()
        {
            return autoIncr.GetId();
        }


        public void GetTournamentInfo(Tournament t)
        {
            //Checking if the tournament has already been loaded from the db
            if (t.Info == null)
            {
                manager.GetInfo(t);
            }
        }


        //FILTERING
        public Tournament GetTournamentByID(int id)
        {
            return staffTournaments.Find(x => x.Id == id);
        }

        public List<Tournament> GetTournamentsByTitle(string title)
        {
            return staffTournaments.FindAll(x => x.Title.ToLower().Contains(title.ToLower()));
        }


        public void AddUser(Tournament t, User u)
        {
            if (t.Users.Any(usr => usr.Id == u.Id))
            {
                throw new Exception("You have already registered for this tournament");
            }
            mngr.AddPlayer(t, u);    
            t.Users.Add(u);
        }
    }
}