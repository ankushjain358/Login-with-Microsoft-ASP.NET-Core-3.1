﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Mvc;

namespace LoginWithMicrosoft.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public async void LoginWithMicrosoft()
        {
            // Way 1:
            //await HttpContext.ChallengeAsync("Microsoft-AccessToken",
            //    new AuthenticationProperties() { RedirectUri = "/" });

            // Way 2:
            await HttpContext.ChallengeAsync(MicrosoftAccountDefaults.AuthenticationScheme,
               new AuthenticationProperties() { RedirectUri = "/" });
        }

        public ActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}