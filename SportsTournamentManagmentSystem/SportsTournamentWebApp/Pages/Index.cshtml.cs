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

        TournamentManager tm = new TournamentManager(new TournamnentDBManager(), 15, 0);

        private IList<Tournament> tournaments;

        public IList<Tournament> Tournaments { get { return tournaments; } }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            tournaments = tm.UserTournaments;
        }
    }
}