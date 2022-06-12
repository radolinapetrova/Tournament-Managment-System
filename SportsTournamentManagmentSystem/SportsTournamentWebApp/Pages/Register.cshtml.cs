using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessLogicLayer;
using BusinessLogic;
using DataAccessLayer;
using Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace SportsTournamentWebApp.Pages
{
    public class TournamentRegistrationModel : PageModel
    {
        UserManager um ;

        public TournamentRegistrationModel(UserManager userManager)
        {
            this.um = userManager;
        }


        [BindProperty]
        public RegisterUserDTO NewUser { get; set; }


        public void OnGet()
        {
        }

        public IActionResult OnPost(string button)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string[] pass = um.GetPass(NewUser.Password);
                    User u = new User(um.GetId(), NewUser.FName, NewUser.LName, NewUser.PhoneNumber, new Account(NewUser.Email, pass[1], pass[0]));
                    um.CreateAccount(u);
                    return RedirectToPage("/LogIn");
                }
                catch (Exception ex)
                {
                    ViewData["message"] = "An account with this data already exists!";
                }
               
            }
            return Page();
        }

    }
}
