using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessLogic;
using DataAccessLayer;
using Entities;

namespace SportsTournamentWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        TournamentManager tm;

        private IList<Tournament> tournaments;
        private List<Tournament> openTournaments = new List<Tournament>();
        private List<Tournament> finishedTournaments = new List<Tournament>();
        private List<Tournament> canceledTournaments = new List<Tournament>();

        private void GetTournaments()
        {
            foreach (Tournament t in tournaments)
            {
                if (t.Status == Status.open)
                {
                    openTournaments.Add(t);
                }
                else if (t.Status == Status.finished)
                {
                    finishedTournaments.Add(t); 
                }
                else if (t.Status == Status.canceled)
                {
                    canceledTournaments.Add(t);
                }
            }
        }

        public IList<Tournament> OpenTournaments { get { return openTournaments; } }
        public IList<Tournament> CanceledTournaments { get { return canceledTournaments; } }
        public IList<Tournament> FinishedTournaments { get { return finishedTournaments; } }


        public IndexModel(ILogger<IndexModel> logger, TournamentManager tournamentManager)
        {
            _logger = logger;
            this.tm = tournamentManager;
        }

        public void OnGet()
        {
            tournaments = tm.Tournaments;
            GetTournaments();
        }
    }
}