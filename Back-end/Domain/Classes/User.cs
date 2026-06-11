using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGreatFamilyTree.Domain.Interfaces;

namespace TheGreatFamilyTree.Domain.Classes
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        private User(Guid id, string login, string password, string email)
        {
            Id = id;
            Login = login;
            Password = password;
            Email = email;
        }

        public static (User user, string error) Create(Guid id, string login, string password, string email)
        {
            string errorString = string.Empty;

            if (!email.Contains('@'))
            {
                errorString += "Адрес электронной почты указан неверно; ";
            }

            if (login.Length > Params._maxLoginLength)
            {
                errorString += $"Логин превышает длину в {Params._maxLoginLength} символов; ";
            }

            if(email.Length > Params._maxEmailLength)
            {
                errorString += $"Адрес почты превышает длину в {Params._maxEmailLength} символов; ";
            }

            return (new User(id, login, password, email), errorString);
        }
    }
}
