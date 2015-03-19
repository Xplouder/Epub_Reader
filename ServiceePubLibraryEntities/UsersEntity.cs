using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServiceePubLibraryEntities
{
    public class UsersEntity
    {

        private Model_Service_ePub_LibraryContainer context;

        public UsersEntity() 
        {
            this.context = new Model_Service_ePub_LibraryContainer();
        }

        public String GetNickname(int id)
        {
            return this.context.User.Find(id).Nickname;
        }

        public void Register(string nickname, string password, string email, DateTime birthDate)
        {
            User u = new User();

            u.Nickname = nickname;

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
            System.Buffer.BlockCopy(passBytes, 0, passwordBytes, 0, passBytes.Length);
            System.Buffer.BlockCopy(saltBytes, 0, passwordBytes, passBytes.Length, saltBytes.Length);
            u.Password = Convert.ToBase64String(sha1.ComputeHash(passwordBytes));

            u.Email = email;

            u.Birthdate = birthDate;

            // add user and save changes on DB
            this.context.User.Add(u);
            this.context.SaveChanges();
            
            

        }
    }
}
