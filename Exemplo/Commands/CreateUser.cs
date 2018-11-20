using System;

namespace Exemplo.Commands
{
    public class CreateUser : ICommand
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nickname { get; set; }
        public string Culture { get; set; }
    }
}