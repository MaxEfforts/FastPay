using FastPayDB.DatabaseModels.Account.User;

using FastPayDB.Models.General;

namespace FastPayDB.Repositories.Interfaces;

public interface IFormSettingRepository : IRepository<UserFormSetting>
{
    Task<List<UserFormSetting>> GetFormSetting();
}