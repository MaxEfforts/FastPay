

using FastPayDB.Context;
using FastPayDB.DatabaseModels.Account.Address;
using FastPayDB.DatabaseModels.Account.User;
using FastPayDB.Repositories.Address;
using FastPayDB.Repositories.Interfaces;

namespace FastPayDB.Repositories.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    #region Fields
    private readonly ApplicationDbContext _db;
    #endregion

    #region Constractor
    public UnitOfWork(ApplicationDbContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _db = db;
        this.UserRepository = new UserRepository(db, userManager, signInManager);
        this.ActivationCodeRepository = new ActivationCodeRepository(db);
    }
    #endregion

    #region Complete
    public async Task<int> CompleteAsync()
    {
        return await _db.SaveChangesAsync();
    }
    #endregion

    #region Dispose
    public async void Dispose()
    {
        await _db.DisposeAsync();
    }
    #endregion

    public IUserRepository UserRepository { get; private set; }
    public IActivationCodeRepository ActivationCodeRepository { get; private set; }
    public IRepository<UserFormSetting> UserFormSettingRepository { get; private set; }
    public IRepository<UserAddressFormSetting> UserAddressFormSettingRepository { get; }

    public IAddressRepository AddressRepository { get; private set; }

    public IRepository<UserAddField> UserAddFieldRepository { get; private set; }
    public IRepository<UserAddFieldOption> UserAddFieldOptionRepository { get; private set; }
    public IUserAddFieldDateTimeRepository UserAddFieldDateTimeRepository { get; private set; }


    public IRepository<UserAddressAddField> UserAddressAddFieldRepository { get; }
    public IRepository<UserAddressAddFieldOption> UserAddressAddFieldOptionRepository { get; }
    public IRepository<UserAddressAddFieldDateTime> UserAddressAddFieldDateTimeRepository { get; }

}

