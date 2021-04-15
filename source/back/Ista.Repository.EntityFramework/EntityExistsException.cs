using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Repository.EntityFramework
{
    public class EntityExistsException : ApplicationException
    {
        public EntityExistsException(string message) : base(message)
        {
        }



        public EntityExistsException(Type entityType, params object[] keys)
             : this($"Entity {entityType.Name} already exists. keys: {keys}")
        {
        }
    }
}
