

using FastPayDB.Context;
using FastPayDB.DatabaseModels.Account.User;
using FastPayDB.Models.GraphResult;
using FastPayDB.Util.Enum;

namespace FastPayDB.Repositories.User;

public partial class UserRepository : Repository<ApplicationUser>, IUserRepository
{
    #region Fields

    private new readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    #endregion

    #region Constractor

    public UserRepository([Service] ApplicationDbContext context, [Service] UserManager<ApplicationUser> userManager,
        [Service] SignInManager<ApplicationUser> signInManager) : base(context)
    {
        this._context = context;
        this._userManager = userManager;
        this._signInManager = signInManager;
    }

    #endregion

    #region CheckEmailForRegister

    public async Task<bool> CheckEmailForRegister(string Email)
    {
        var user = await base.GetAsync(x => x != null && x.Email == Email);
        //var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == Email);
        return user != null ? true : false;
    }

    #endregion

    #region GetUserByEmail
    public async Task<ApplicationUser> GetUserByEmail(string Email)
    {
        var user = await base.GetAsync(x => x != null && x.Email == Email);
        //var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == Email);
        return user;
    }
    #endregion

    #region GetUserById
    public async Task<ApplicationUser> GetUserById(int id)
    {
        var user = await base.GetAsync(x => x != null && x.Id == id);
        return user;
    }
    #endregion

    #region CheckPhoneNumberForRegister

    public async Task<bool> CheckPhoneNumberForRegister(string PhoneNumber)
    {
        var user = await base.GetAsync(x => x != null && x.PhoneNumber == PhoneNumber);
        //var user = await _context.Users.FirstOrDefaultAsync(x => x.PhoneNumber == PhoneNumber);
        return user != null ? true : false;
    }

    #endregion

    #region GetUserByPhoneNumber
    public async Task<ApplicationUser> GetUserByPhoneNumber(string PhoneNumber)
    {
        var user = await base.GetAsync(x => x != null && x.PhoneNumber == PhoneNumber);
        //var user = await _context.Users.FirstOrDefaultAsync(x => x.PhoneNumber == PhoneNumber);
        return user;
    }
    #endregion

    #region CreateUser

    public async Task<bool> CreateUser(ApplicationUser applicationUser, string PasswordHash)
    {
        try
        {
            var result = await _userManager.CreateAsync(applicationUser, PasswordHash);
            return result.Succeeded;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    #endregion

    #region CheckUserToken
    public async Task<bool> CheckUserToken(int userId, string token)
    {
        var result = await _context.UserTokens.FirstOrDefaultAsync(x => x.UserId == userId && x.Value == token);
        return result != null ? true : false;
    }
    #endregion

    #region GetUserIdByToken

    public async Task<int> GetUserIdByToken(string token)
    {
        var result = await _context.UserTokens.FirstOrDefaultAsync(x => x.Value == token);
        return result != null ? (int)result.UserId : 0;
    }
    #endregion

    #region CheckSocialAuthID

    public async Task<ApplicationUser?> CheckSocialAuthID(string socialAuthID, SocialMedia socialMedia)
    {
        var applicationUser = await _context.Users.FirstOrDefaultAsync(x => x.SocialAuthId == socialAuthID && x.SocialMediaType == ((int)socialMedia));
        return applicationUser;
    }
    #endregion

    #region GetUserToken

    public async Task<string?> GetUserToken(int userId)
    {
        return await _context.UserTokens.Where(x => x.UserId == userId).Select(x => x.Value).FirstOrDefaultAsync();

    }
    #endregion

    #region GetUser by phone & email

    public async Task<ApplicationUser> GetUser(string phoneNumber, string email)
    {
        var user = await base.GetAsync(x => x.PhoneNumber == phoneNumber && x.Email == email);
        return user;
    }

    #endregion
    
    #region ChangePassword

    public async Task<ChangePasswordModel> ChangePassword(ChangePasswordModel changePasswordModel)
    {
        var user = await _userManager.FindByIdAsync(changePasswordModel.UserId);
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var result = await _userManager.ResetPasswordAsync(user, token, changePasswordModel.NewPassword);
        if (result.Succeeded)
        {
            changePasswordModel.NewToken = token;
            changePasswordModel.Result = new Result() { StatusCode = 1, StatusMessage = "Success" };
            var uldUserToken = await _context.UserTokens.FirstOrDefaultAsync(x => x.UserId == int.Parse(changePasswordModel.UserId) && x.Value == changePasswordModel.Token);
            if (uldUserToken != null) uldUserToken.Value = token;
            await _context.SaveChangesAsync();
            return changePasswordModel;
        }
        else
        {
            changePasswordModel.Result = new Result() { StatusCode = 0, StatusMessage = "Password required Caital and smal litter and special characters" };
            return changePasswordModel;
        }
    }


    #endregion

    #region Login email & token

    public async Task<bool> SignIn(string Email, string jwtToken)
    {
        var user = await base.GetAsync(x => x.Email == Email);
        if (user == null)
        {
            return false;
        }
        try
        {
            var userToken = _context.UserTokens.FirstOrDefault(x => x.UserId == user.Id);
            if (userToken == null)
            {
                _context.UserTokens.Add(new IdentityUserToken<int>()
                {
                    UserId = user.Id,
                    LoginProvider = user.Email,
                    Name = "RefreshToken",
                    Value = jwtToken
                });
            }
            else
            {
                userToken.Value = jwtToken;
            }
            _context.SaveChanges();
            return true;
            #region comment

            //    await _signInManager.SignInAsync(user, isPersistent: false);
            //    await _userManager.RemoveAuthenticationTokenAsync(user, user.Email, "RefreshToken");
            //    await _userManager.SetAuthenticationTokenAsync(user, user.Email, "RefreshToken", jwtToken);
            //    return true; 
            #endregion
        }
        catch
        {
            return false;
        }
    }


    #endregion

    #region ActiveCustomer
    public async Task ActiveCustomer(int id, string codeType)
    {
        var applicationUser = await GetAsync(a => a != null && a.Id == id);
        if (applicationUser != null)
        {
            if (codeType == "email") // Email
                applicationUser.EmailConfirmed = true;
            else
                applicationUser.PhoneNumberConfirmed = true;

            //if (user.EmailConfirmed && user.PhoneNumberConfirmed)
            if (applicationUser.PhoneNumberConfirmed)
                applicationUser.IsActive = true;
            _context.Entry(applicationUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }


    #endregion

    #region UpdateUserProfile
    public async Task UpdateUserProfile(ApplicationUser applicationUser)
    {
        if (applicationUser == null)
            throw new ArgumentNullException(nameof(applicationUser));
        /*var entity =await (from au in _context.Users
            where au.Id == applicationUser.Id
            select au).FirstOrDefaultAsync();*/
        var entity = await GetAsync(x => x.Id == applicationUser.Id);
        if (entity!=null)
        {
            entity.FullName = applicationUser.FullName;
            entity.Email = applicationUser.Email;
        }
        _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    }

    #endregion

     #region UpdateUserAddField
    public async Task UpdateUserAddField(ApplicationUser applicationUser)
    {
        if (applicationUser == null)
            throw new ArgumentNullException(nameof(applicationUser));
        
        _context.Entry(applicationUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    }

    #endregion

    

}

