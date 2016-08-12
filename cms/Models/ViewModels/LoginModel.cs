using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServerSimpleSite.Models.Pages;

namespace EPiServerSimpleSite.Models.ViewModels
{
    public class LoginModel : PageViewModel<LoginPage>
    {
        public LoginFormPostbackData LoginPostbackData { get; set; }
        public LoginModel(LoginPage currentPage)
            : base(currentPage)
        {
            LoginPostbackData = new LoginFormPostbackData();
        }
        public string Message { get; set; }
    }

    public class LoginFormPostbackData
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}