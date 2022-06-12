using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessLogic;
using BusinessLogicLayer;
using Entities;
using DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace SportsTournamentWebApp.Pages
{

    public class TournamentInfoModel : PageModel
    {
        TournamentManager tm;
        UserManager um;


        public TournamentInfoModel(UserManager userManager, TournamentManager tournamentManager)
        {
            this.um = userManager;
            this.tm = tournamentManager;
        }

        private Tournament t;
        private Dictionary<int, int> ranking;

        public Tournament T { get { return t; } }

        public Dictionary<int, int> Ranking { get { return ranking; } }

        [BindProperty]
        public int Id { get; set; }

        public void OnGet(string id)
        {
            //Retrieving the information for the selected tournament 
            Id = Convert.ToInt32(id);
            t = tm.GetTournamentByID(Convert.ToInt32(id));
            tm.GetTournamentInfo(t);
            ranking = tm.GetRanking(t);
        }


        public IActionResult OnPost()
        {

            if (User.Identity.IsAuthenticated)
            {

                //getting the user if the application got closed and they were loged in
                if (um.User == null)
                {
                    um.GetUser(User.FindFirst(ClaimTypes.Email).Value);
                }

                t = tm.GetTournamentByID(Id);

                //Checking if the user has already been registered for this tournament
                if (t.Users.Any(x => x.Id == um.User.Id))
                {
                    ViewData["message"] = "You have already registered for this tournament!";
                    return Page();
                }

                //Checking if the maximum number of players has been reached
                if (t.Users.Count == t.Info.MaxPlayers)
                {
                    ViewData["message"] = "The maximum number of players has been reached!";
                    return Page();
                }

                //Adding the user to the list of players of the tournament if all the cheks are passed
                tm.AddUser(t, um.User);
                ViewData["message"] = "You have successfully registered for this tournament!";
                return Page();
            }
            else
            {
                //Redirecting the user to the log in page if they are not authenticated
                return RedirectToPage("/LogIn");
            }
        }
    }
}
