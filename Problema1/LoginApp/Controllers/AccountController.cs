using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginApp.Services;
using LoginApp.ViewModels;

namespace LoginApp.Controllers
{
    public class AccountController
    {
        private readonly ILoginService _loginService;

        public AccountController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public string Login(string username, string password)
        {
            var loginInputModel = new LoginInputModel() {Password = password, Username = username};
            return _loginService.Login(loginInputModel);
        }
    }
}
