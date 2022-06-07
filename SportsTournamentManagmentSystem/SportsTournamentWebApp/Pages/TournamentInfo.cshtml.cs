using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessLogic;
using Entities;
using DataAccessLayer;

namespace SportsTournamentWebApp.Pages
{
    public class TournamentInfoModel : PageModel
    {
        TournamentManager tm = new TournamentManager(new TournamnentDBManager(), 15, 0);

        Tournament t;

        public Tournament T { get { return t; } }
        public void OnGet(string id)
        {
            t = tm.GetTournamentById(Convert.ToInt32(id));   
        }

        public IActionResult OnPost(string button)
        {
            if (button == "register")
            {
                return RedirectToPage("/TournamentRegistration");
            }
            return Page();
        }
    }
}
