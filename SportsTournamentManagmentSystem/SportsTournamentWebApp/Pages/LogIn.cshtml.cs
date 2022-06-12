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
    public class LogInModel : PageModel
    {

        UserManager um;

        public LogInModel(UserManager userManager)
        {
            this.um = userManager;
        }


        [BindProperty]
        public LogInUserDTO LogInUser { get; set; }

        private User user;

        public void OnGet()
        {
                
        }

        public IActionResult OnPost(string button)
        {
            if (button == "LogIn")
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        um.LogIn(LogInUser);
                        this.user = um.User;
                        SetUpCookie();
                        return RedirectToPage("/Index");

                    }
                    catch (Exception ex)
                    {

                        ViewData["message"] = ex.Message;
                    }
                }
                return Page();
               
            }
            else 
            {
                return RedirectToPage("/Register");
            }
           
        }

        public void SetUpCookie()
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, user.FisrtName));
            claims.Add(new Claim(ClaimTypes.Email, user.Account.Email));


            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(
            new ClaimsPrincipal(claimsIdentity),
            new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(60)
            });
        }
    }
}
