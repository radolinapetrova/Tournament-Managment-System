using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessLogicLayer;
using Entities;
using System.Security.Claims;

namespace SportsTournamentWebApp.Pages
{
    [Authorize]
    public class AccountModel : PageModel
    {
        UserManager um;

        public AccountModel(UserManager manager)
        {
            um = manager;
        }



        [BindProperty]
        public UpdateUser CurrentUser { get; set; }


        public void OnGet()
        {
            um.GetUser(User.FindFirst(ClaimTypes.Email).Value);
            CurrentUser = new UpdateUser();
            CurrentUser.Email = um.User.Account.Email;
            CurrentUser.Phone = um.User.Phone;
        }

        public IActionResult OnPost(string button)
        {
            if (button == "logout")
            {
                HttpContext.SignOutAsync();
                HttpContext.Session.Clear();
                return RedirectToPage("/Index");
            }
            else
            {
                try
                {
                    um.Update(CurrentUser);
                    ViewData["message"] = "You have successfully updated your profile information";
                }
                catch (Exception ex)
                {

                    ViewData["message"] = ex.Message;
                }
                return Page();
            }
        }
    }
}
