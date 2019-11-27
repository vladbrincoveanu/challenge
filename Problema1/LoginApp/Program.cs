using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginApp.Domain.Models;
using LoginApp.Domain.Repository;
using LoginApp.Services;

namespace LoginApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

//            var role = new Role() {Name = "test"};
//            var rep = new UserRepository(new ironmountainEntities());
//            var user = new User() {Name = "Test", Password= "password", Roles= new List<Role>() {role}};
//            rep.InsertUser(user);
//            rep.Save();
//
//            var test=rep.GetUsers();
//
//            string value = PasswordHashing.HashPassword("Cristina");


        }
    }
}
