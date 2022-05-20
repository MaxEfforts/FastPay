
using FastPayDB.DatabaseModels.Account.Address;
using FastPayDB.DatabaseModels.Account.User;

namespace FastPayDB.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IActivationCodeRepository ActivationCodeRepository { get; }
    IRepository<UserFormSetting> UserFormSettingRepository { get; }
    IRepository<UserAddressFormSetting> UserAddressFormSettingRepository { get; }

    IAddressRepository AddressRepository { get; }

    IRepository<UserAddField> UserAddFieldRepository { get; }
    IRepository<UserAddFieldOption> UserAddFieldOptionRepository { get; }
    //IRepository<UserAddFieldDateTime> UserAddFieldDateTimeRepository { get; }
    IUserAddFieldDateTimeRepository UserAddFieldDateTimeRepository { get; }

    IRepository<UserAddressAddField> UserAddressAddFieldRepository { get; }
    IRepository<UserAddressAddFieldOption> UserAddressAddFieldOptionRepository { get; }
    IRepository<UserAddressAddFieldDateTime> UserAddressAddFieldDateTimeRepository { get; }

    Task<int> CompleteAsync();

}

