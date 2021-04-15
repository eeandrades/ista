using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Repository.EntityFramework
{
    public class EntityNotFoundException : ApplicationException
    {
        public EntityNotFoundException(string message) : base(message)
        {
        }



        public EntityNotFoundException(Type entityType, params object[] keys)
             : this($"Entity {entityType.Name} not found exists. keys: {keys}")
        {
        }
    }
}
