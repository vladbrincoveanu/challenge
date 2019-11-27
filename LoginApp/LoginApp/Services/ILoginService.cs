using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginApp.ViewModels;

namespace LoginApp.Services
{
    public interface ILoginService
    {
        string Login(LoginInputModel loginInputModel);
    }
}
