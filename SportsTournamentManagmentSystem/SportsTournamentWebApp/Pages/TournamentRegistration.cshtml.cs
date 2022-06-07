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
        TournamentManager tm = new TournamentManager(new TournamnentDBManager(), new TournamnentDBManager(), new TournamnentDBManager(), new TournamnentDBManager());

        [BindProperty]
        public RegisterUserDTO NewUser { get; set; }

        [BindProperty]
        public LogInUserDTO User { get; set; }

        
        UserManager um = new UserManager(new UserDBManager(), new UserDBManager());

        Tournament t;

        public void OnGet(string id)
        {
            t = tm.GetTournamentById(Convert.ToInt32(id));
        }

        public IActionResult OnPost(string button)

        {
            if (ModelState.IsValid)
            {
                if (button == "login")
                {
                    User user = um.LogIn(User);
                    tm.AddUser(t, user);
                }
                else
                {
                    string[] pass = um.GetPass(NewUser.Password);
                    User u = new User(um.GetId(), NewUser.FName, NewUser.LName, NewUser.PhoneNumber, new Account(NewUser.Email, pass[1], pass[0]));
                    um.CreateAccount(u);
                    tm.AddUser(t, u);
                }
            }
            return null;
            //return Page();
        }

        public void SetUpCookie()
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Email, User.Email));


            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(
            new ClaimsPrincipal(claimsIdentity),
            new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
            });
        }
    }
}
