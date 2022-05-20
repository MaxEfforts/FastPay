using System.Linq;
using FastPayDB.Context;
using FastPayDB.DatabaseModels.Account.User;
using FastPayDB.Util;
using Microsoft.Extensions.Logging;

namespace FastPayDB.Repositories.User;

public class ActivationCodeRepository : Repository<ActivationCode>, IActivationCodeRepository
{
    #region Fields

    private new readonly ApplicationDbContext _context;

    #endregion

    #region Constractor
    public ActivationCodeRepository(ApplicationDbContext context) : base(context)
    {
        this._context = context;
    }
    #endregion

    #region SaveActivationCode

    public async Task SaveActivationCode(ActivationCode model)
    {
        _context.Entry(model).State = EntityState.Added;
        var entity = await base.Add(model);
    }

    #endregion

    #region GetActivationCode
    public async Task<ActivationCode?> GetActivationCode(int userId, string codeType)
    {
        var activationCode = await GetAsync(a => a != null && a.UserId == userId && a.CodeType == codeType);
        return activationCode;
    }
    #endregion


    #region RemoveActivationCode
    public async Task RemoveActivationCode(int userId, string codeType)
    {
        var activationCode = await _context.ActivationCode.FirstOrDefaultAsync(a => a.UserId == userId && a.CodeType == codeType);
        _context.ActivationCode.Remove(activationCode);
        _context.SaveChanges();
    }
    #endregion


    #region GenerateActivationCode

    public async Task<string> GenerateActivationCode()
    {
        string activationCode = "";
        //add unique coupon code in  UsersCartsItems table
        var rand = new RandomGenerator();
        // 6-Digits between 100000 and 999999
        activationCode = rand.RandomNumber(100000, 999999).ToString();
        var usersCartsItems = await GetAsync(x => x.Code == activationCode);
        while (usersCartsItems != null) // loop until get unique
        {
            activationCode = rand.RandomNumber(100000, 999999).ToString();
            usersCartsItems = await GetAsync(x => x.Code == activationCode);
        }

        if (usersCartsItems == null)//means unique then add it
        {
            return activationCode;
        }

        return "error";
    }

    #endregion
}