using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Practice.Abstract_Classes
{
    public abstract class UniqueId
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
