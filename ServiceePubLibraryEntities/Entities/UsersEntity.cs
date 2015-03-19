using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ServiceePubLibraryEntities.Exceptions;

namespace ServiceePubLibraryEntities
{
    public class UsersEntity
    {

        private Model_Service_ePub_LibraryContainer context;

        public UsersEntity()
        {
            this.context = new Model_Service_ePub_LibraryContainer();
        }

        private User GetUser(int id)
        {
            try
            {
                return this.context.User.Find(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public User GetUser(string email)
        {
            try
            {
                return this.context.User.Where(i => i.Email == email).ToList().First();
            }
            catch (Exception)
            {
                return null;
            }  
        }

        public int IsUser(string login, string password)
        {
            User user = GetUser(login);
            if (user == null)
                return 0;

            byte[] sha1Pass = Convert.FromBase64String(password);
            byte[] sha1Password = Encoding.UTF8.GetBytes(password);

            byte[] salt = Convert.FromBase64String(user.Salt);

            byte[] sha1PasswordWithSalt = new byte[salt.Length + sha1Password.Length];
            Array.Copy(sha1Password, 0, sha1PasswordWithSalt, 0, sha1Password.Length);
            Array.Copy(salt, 0, sha1PasswordWithSalt, sha1Password.Length, salt.Length);

            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] finalPasswordBytes = sha1.ComputeHash(sha1PasswordWithSalt);
            string finalPassword = Convert.ToBase64String(finalPasswordBytes);

            if (user.Password != finalPassword)
                return 0;

            return user.Id;
        }

        public void Register(string username, string email, string password, DateTime birthDate) 
        {
            try
            {
                User u = new User();

                u.Username = username;

                //generate salt (random byte[])
                Random r1 = new Random();
                int randomSize = r1.Next(5, 20);
                byte[] saltBytes = new byte[randomSize];
                Random r2 = new Random();
                r2.NextBytes(saltBytes);
                u.Salt = Convert.ToBase64String(saltBytes);

                //generate hash value of password with salt (sha1)
                SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
                byte[] passBytes = Encoding.UTF8.GetBytes(password);
                byte[] passwordBytes = new byte[passBytes.Length + saltBytes.Length];
                Buffer.BlockCopy(passBytes, 0, passwordBytes, 0, passBytes.Length);
                Buffer.BlockCopy(saltBytes, 0, passwordBytes, passBytes.Length, saltBytes.Length);
                u.Password = Convert.ToBase64String(sha1.ComputeHash(passwordBytes));

                u.Email = email;

                u.Birthdate = birthDate;

                // add user and save changes on DB
                this.context.User.Add(u);
                this.context.SaveChanges();
            }
            catch (DbUpdateException dbue)
            {
                if (dbue.InnerException.InnerException.Message.Contains("index_unique_email"))
                {
                    throw new UniqueEmailException();
                }
            }
        }
    }

}
