using FastPayDB.DatabaseModels.Account.User;

namespace FastPayDB.Repositories.Interfaces;

public interface IActivationCodeRepository : IRepository<ActivationCode>
{
    Task<string> GenerateActivationCode();
    Task SaveActivationCode(ActivationCode model);
    Task<ActivationCode?> GetActivationCode(int userId, string codeType);
    Task RemoveActivationCode(int userId, string codeType);

}