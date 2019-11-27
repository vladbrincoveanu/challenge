using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginApp.Domain.Repository;
using LoginApp.ViewModels;

namespace LoginApp.Services
{
    public class LoginService:ILoginService
    {
        private readonly UserRepository _userRepository;

        public LoginService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string Login(LoginInputModel loginInputModel)
        {
            if (loginInputModel.Username == "" || loginInputModel.Password == "") return "error";
            var users = _userRepository.GetUsersByProcedure();
            var passwordHashed = PasswordHashing.HashPassword(loginInputModel.Password);
            foreach (var user in users)
            {
                if (loginInputModel.Username.Equals(user.Name) && passwordHashed.Equals(user.Password))
                    return "ok";
            }
            return "failed";
        }
    }
}
