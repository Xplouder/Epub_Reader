using System;
using System.ServiceModel.Security;
using System.Windows.Forms;
using ePubIntegrator.ServiceReference_ePubCloud;

namespace ePubIntegrator.Models {
    public class User
    {
        private readonly int id;
        private readonly String username;
        private readonly String email;
        private readonly DateTime birthDate;

        public User (int id,String username, String email, DateTime birthDate)
        {
            this.id = id;
            this.username = username;
            this.email = email;
            this.birthDate = birthDate;
        }

        public User(UserContract uc, String defaultPath)
        {
            this.id = uc.Id;
            this.username = uc.Username;
            this.email = uc.Email;
            this.birthDate = uc.BirthDate;
        }

        public int Id
        {
            get { return this.id; }
        }

        public string Username
        {
            get { return this.username; }
        }

        public string Email
        {
            get { return this.email;  }
        }

        public DateTime BirthDate
        {
            get { return this.birthDate; }
        }

    }
}
