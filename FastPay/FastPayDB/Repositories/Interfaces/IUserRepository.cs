

using FastPayDB.DatabaseModels.Account.User;
using FastPayDB.Util.Enum;

namespace FastPayDB.Repositories.Interfaces;

public interface IUserRepository : IRepository<ApplicationUser>
{
    Task<bool> CheckEmailForRegister(string Email);
    Task<bool> CheckPhoneNumberForRegister(string PhoneNumber);
    Task<ApplicationUser> GetUserByEmail(string Email);
    Task<ApplicationUser> GetUserById(int id);
    Task<ApplicationUser> GetUserByPhoneNumber(string PhoneNumber);
    Task<int> GetUserIdByToken(string token);
    Task<bool> CreateUser(ApplicationUser applicationUser, string PasswordHash);
    Task<bool> CheckUserToken(int userId, string token);
    Task<ApplicationUser> GetUser(string phoneNumber, string email);
    Task<ChangePasswordModel> ChangePassword(ChangePasswordModel changePasswordModel);
    Task<bool> SignIn(string email, string jwtToken);
    Task<string?> GetUserToken(int userId);
    Task<ApplicationUser?> CheckSocialAuthID(string socialAuthID, SocialMedia socialMedia);
    public Task UpdateUserProfile(ApplicationUser applicationUser);

}

