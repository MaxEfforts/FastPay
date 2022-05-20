
using FastPayDB.Context;
using FastPayDB.DatabaseModels.Account.Address;

namespace FastPayDB.Repositories.Address
{
    public class AddressRepository : Repository<UserAddress>, IAddressRepository
    {
        private readonly ApplicationDbContext context;

        public AddressRepository([Service] ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
