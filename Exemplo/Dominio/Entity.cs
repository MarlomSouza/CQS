using System;

namespace Exemplo.Dominio
{
    public class Entity
    {
        public Guid Guid { get; set; }
        public int Id { get; protected set; }
    }
}