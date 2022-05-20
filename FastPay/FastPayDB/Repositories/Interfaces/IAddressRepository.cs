
using FastPayDB.DatabaseModels.Account.Address;
using FastPayDB.Models.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastPayDB.Repositories.Interfaces
{
    public interface IAddressRepository : IRepository<UserAddress>
    {
    }
}
