using System;

namespace Exemplo.Dominio
{
    public class Entity
    {
        protected Guid Guid { get; set; }
        public int Id { get; protected set; }
    }
}