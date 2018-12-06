using System;

namespace Exemplo.Domain
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        private User() { }
        public User(string name, string email, string password)
        {
            Validade(name, email, password);

            this.Guid = Guid.NewGuid();
            this.Name = name;
            this.Email = email;
            this.Password = password;
        }
        private void Validade(string name, string email, string password)
        {
            DomainException.When(string.IsNullOrEmpty(name), "Name is required");
            DomainException.When(string.IsNullOrEmpty(email), "Email is required");
            DomainException.When(string.IsNullOrEmpty(password), "password is required");
        }

    }
}