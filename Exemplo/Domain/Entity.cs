using System;

namespace Exemplo.Domain
{
    public class Entity
    {
        public Guid Guid { get; protected set; }
        public int Id { get; protected set; }
    }
}