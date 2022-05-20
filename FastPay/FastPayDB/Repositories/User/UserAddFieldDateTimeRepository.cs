
using FastPayDB.Context;
using FastPayDB.DatabaseModels.Account.User;
using FastPayDB.Models.GraphResult;

namespace FastPayDB.Repositories.User;

public partial class UserAddFieldDateTimeRepository : Repository<UserAddFieldDateTime>, IUserAddFieldDateTimeRepository
{
    #region Fields

    private new readonly ApplicationDbContext _context;
  
    #endregion

    #region Constractor

    public UserAddFieldDateTimeRepository([Service] ApplicationDbContext context) : base(context)
    {
        this._context = context;
    }

    #endregion

    

}

