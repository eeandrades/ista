using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ista.Domain
{
    public interface  IUnitOfWork
    {
        void Commit();

        int Contador { get; set; }
    }
}
