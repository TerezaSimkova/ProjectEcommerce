using ProjectEcommerce.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEcommerce.CORE.Interfaces
{
    public interface IRepositoryUtente : IRepository<Utente>
    {
        Utente GetByUsername(string username);
    }
}
