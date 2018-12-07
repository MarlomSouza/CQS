using System;

namespace Dominio.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(string erro) : base(erro) { }

        public static void Quando(bool haErro, string erro)
        {
            if (haErro)
                throw new DomainException(erro);
        }
    }
}