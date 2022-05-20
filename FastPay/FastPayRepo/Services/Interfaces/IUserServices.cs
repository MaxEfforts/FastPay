
using FastPayDB.Models.General;

namespace FastPayRepo.Services.Interfaces;

public interface IUserServices
{
    Task<RegisterModel> Register(RegisterModel registerDto);
    Task<LoginModel> Login(LoginModel loginDto);
    Task<ChangePasswordModel> ChangeUserPassword(ChangePasswordModel changePasswordModel);
    Task<Result> VerifyCodeByEmail(string code, string email);
    Task<Result> VerifyCodeByPhone(string code, string phone);
    Task<Result> ForgetPasswordByEmail(string email);
    Task<Result> ForgetPasswordByPhone(string phone, string phoneCode);
    Task<Result> ForgetPasswordByUserName(string userName);
    Task<Result> LoginSocialMedia(string socialAuthID, int socialMediaType);
    //Task<UserModel> GetUserById(int userId);
    //Task<UpdateUserProfileModel> UpdateUserProfile(UpdateUserProfileModel updateUserProfileModel);
     //Task<List<FormSettingModel>> GetFormSetting();
}

