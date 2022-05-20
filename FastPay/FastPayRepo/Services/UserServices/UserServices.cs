
using System.Linq.Expressions;
using HotChocolate;
using FastPayDB.DatabaseModels.Account.User;
using FastPayDB.Models.General;
using FastPayDB.Models.GraphResult;
using FastPayDB.Models.User;
using FastPayDB.Models.Util;
using FastPayDB.Util.Enum;
using FastPayRepo.Services.UserServices.SendUserMessage;
using Microsoft.Extensions.Logging;

namespace FastPayRepo.Services.UserServices;

public partial class UserServices : IUserServices
{
    private readonly IUserSettingsService _userSettingsService;

    #region Fields

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISendMessage _sendMessage;
    private readonly AppSettings _appSettings;
    private new readonly IMailService _mailService;
    private new readonly ILogger _logger;
    private new readonly IGeneralServices _generalService;

    #endregion

    #region Constractor

    public UserServices([Service] IUserSettingsService userSettingsService,IGeneralServices generalService, IMapper mapper, IUnitOfWork unitOfWork, ISendMessage sendMessage,
        IMailService mailService, ILogger logger,
        IOptions<AppSettings> appSettings)
    {
        this._userSettingsService = userSettingsService;
        this._mapper = mapper;
        this._unitOfWork = unitOfWork;
        this._sendMessage = sendMessage;
        this._appSettings = appSettings.Value;
        this._mailService = mailService;
        this._logger = logger;
        this._generalService = generalService;
    }

    #endregion

    //#region CheckConfirmation
    //private async Task<bool> CheckIfConfirmationNeeded()
    //{
    //    //return true if 
    //   // var formSettings = await GetFormSetting();
    //    if (formSettings == null)
    //        return false;
    //    var confirmation = formSettings.Where(x =>
    //                        (x.Name == "IsConfirmEmailRequired" && x.SettingValue == "True" && x.AppliedFor == "Register" && x.ControlType == 14) ||
    //                        (x.Name == "IsConfirmPhoneRequired" && x.SettingValue == "True" && x.AppliedFor == "Register" && x.ControlType == 14)).FirstOrDefault();
    //    if (confirmation != null)
    //        return true;

    //    return false;
    //}
    //#endregion

    #region Register
    public async Task<RegisterModel> Register(RegisterModel registerModel)
    {
        try
        {
            #region Validate if Email exist && Phone exist

            bool isEmailExist = await _unitOfWork.UserRepository.CheckEmailForRegister(registerModel.Email);
            if (isEmailExist)
            {
                registerModel.Result = new Result() { StatusCode = 0, StatusMessage = "Email exists" };
                return registerModel;
            }

            bool isPhoneExist = await _unitOfWork.UserRepository.CheckPhoneNumberForRegister(registerModel.PhoneNumber);
            if (isPhoneExist)
            {
                registerModel.Result = new Result() { StatusCode = 0, StatusMessage = "Phone number exists" };
                return registerModel;
            }

            #endregion

            #region Create User
            var applicationUser = _mapper.Map<ApplicationUser>(registerModel);
            //applicationUser.IsActive = !await CheckIfConfirmationNeeded();
            var result = await _unitOfWork.UserRepository.CreateUser(applicationUser, registerModel.PasswordHash!);
            if (!result)
            {
                registerModel.Result = new Result() { StatusCode = 0, StatusMessage = "Create User failed user name exists" };
                return registerModel;
            }
            #endregion

            #region SignIn
            var applicationUserAferRegistration = await _unitOfWork.UserRepository.GetUserByEmail(applicationUser.Email!);
            if (applicationUserAferRegistration == null)
            {
                registerModel.Result = new Result() { StatusCode = 0, StatusMessage = "Registration failed" };
                return registerModel;
            }

            var token = GenerateJwtToken(applicationUser.PasswordHash);
            var SignInResult = await _unitOfWork.UserRepository.SignIn(applicationUser.Email, token);
            if (!SignInResult)
            {
                registerModel.Result = new Result() { StatusCode = 0, StatusMessage = "SignIn user failed" };
                return registerModel;
            }
            #endregion

            #region Handle activation code for Phone & Email if any

            registerModel = _mapper.Map<RegisterModel>(applicationUser);
            registerModel.UserId = applicationUserAferRegistration.Id;
            registerModel.Token =  token;
            string StatusResult = "succes";
            //if (await CheckIfConfirmationNeeded())
            //{
                Notification notification = new Notification(new SendMailActivationCode(_mailService, _logger, _unitOfWork));
                var res = await notification.SendActivationCode("123", applicationUser);
                StatusResult = res ? "succes" : "cant send message to mail";
            //}
            registerModel.Result = new Result() { StatusCode = 1, StatusMessage = StatusResult };
            return registerModel;
            #endregion
        }
        catch (Exception e)
        {
            #region Handle exception

            Console.WriteLine(e);
            _logger.LogError(e, "{Repo} Register method error", typeof(UserServices));
            registerModel.Result = new Result
            {
                StatusCode = 0,
                StatusMessage = e.StackTrace
            };

            #endregion
        }

        return registerModel;
    }
    #endregion

    #region Login
    public async Task<LoginModel> Login(LoginModel loginModel)
    {
        try
        {
            var applicationUser = await _unitOfWork.UserRepository.GetUserById(loginModel.UserId);

            if (applicationUser == null)
            {
                loginModel.Result = new Result() { StatusCode = 0, StatusMessage = "User Not Registerd" };
                return loginModel;
            }

            if (!applicationUser.IsActive)
            {
                loginModel.Result = new Result() { StatusCode = 0, StatusMessage = "Email Or Phone Confirmation Is Required" };
                return loginModel;
            }
            var userToken = await _unitOfWork.UserRepository.GetUserToken(applicationUser.Id);
            loginModel.Token = userToken;
            loginModel.Result = new Result() { StatusCode = 1, StatusMessage = "Success" };
            return loginModel;
        }
        catch (Exception e)
        {
            #region Handle exception

            Console.WriteLine(e);
            _logger.LogError(e, "{Repo} Login method error", typeof(UserServices));
            loginModel.Result = new Result
            {
                StatusCode = 0,
                StatusMessage = e.StackTrace
            };


            #endregion
        }
        return loginModel;
    }
    #endregion

    #region ChangeUserPassword

    public async Task<ChangePasswordModel> ChangeUserPassword(ChangePasswordModel changePasswordModel)
    {
        var result = await _unitOfWork.UserRepository.CheckUserToken(int.Parse(changePasswordModel.UserId), changePasswordModel.Token);
        if (!result)
        {
            changePasswordModel.Result = new Result() { StatusCode = 0, StatusMessage = "User Token Not Valid" };
            return changePasswordModel;
        }

        return (await _unitOfWork.UserRepository.ChangePassword(changePasswordModel));

    }
    #endregion

    #region VerifyCodeByEmail
    public async Task<Result> VerifyCodeByEmail(string code, string email)
    {
        var applicationUser = await _unitOfWork.UserRepository.GetUserByEmail(email);
        if (applicationUser == null)
        {
            return new Result() { StatusCode = 0, StatusMessage = "User Not Found" };
        }
        var activateCode = await _unitOfWork.ActivationCodeRepository.GetActivationCode(applicationUser.Id, "email");
        if (activateCode == null || activateCode.Code != code)
        {
            return new Result() { StatusCode = 0, StatusMessage = "Activation Code Not Correct" };
        }
        applicationUser.EmailConfirmed = true;
        applicationUser.IsActive = true;
        await _unitOfWork.CompleteAsync();

        await _unitOfWork.ActivationCodeRepository.RemoveActivationCode(applicationUser.Id, "email");
        return new Result() { StatusCode = 1, StatusMessage = "Success" };
    }
    #endregion

    #region VerifyCodeByPhone
    public async Task<Result> VerifyCodeByPhone(string code, string phone)
    {
        var applicationUser = await _unitOfWork.UserRepository.GetUserByPhoneNumber(phone);
        if (applicationUser == null)
        {
            return new Result() { StatusCode = 0, StatusMessage = "User Not Found" };
        }
        var activateCode = await _unitOfWork.ActivationCodeRepository.GetActivationCode(applicationUser.Id, "phone");
        if (activateCode == null || activateCode.Code != code)
        {
            return new Result() { StatusCode = 0, StatusMessage = "Activation Code Not Correct" };
        }
        applicationUser.IsActive = true;
        applicationUser.PhoneNumberConfirmed = true;
        await _unitOfWork.CompleteAsync();
        await _unitOfWork.ActivationCodeRepository.RemoveActivationCode(applicationUser.Id, "phone");
        return new Result() { StatusCode = 1, StatusMessage = "Success" };
    }
    #endregion

    #region GenerateJwtToken
    private string GenerateJwtToken(string Password)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("FastPay # Wep * App6666");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name,Password.ToString()),
                new Claim(ClaimTypes.Role, "Admin")
            }),
            // Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    #endregion

    #region ForgetPasswordByEmail
    public async Task<Result> ForgetPasswordByEmail(string email)
    {
        var token = _userSettingsService.GetToken();
        if (token == null)
        {
            return new Result() { StatusCode = 0, StatusMessage = "Token Not Sent" };
        }
        var applicationUserId = await _unitOfWork.UserRepository.GetUserIdByToken(token);
        if (applicationUserId == 0)
        {
            return new Result() { StatusCode = 0, StatusMessage = "User Not Found" };
        }
        var applicationUser = await _unitOfWork.UserRepository.GetUserById(applicationUserId);
        if (applicationUser == null)
        {
            return new Result() { StatusCode = 0, StatusMessage = "User Not Found" };
        }
        // to do
        // if token not assign to user 
        if (applicationUser.Email != email)
        {
            return new Result() { StatusCode = 0, StatusMessage = "User Email Not Correct" };
        }
        Notification notification = new Notification(new SendMailActivationCode(_mailService, _logger, _unitOfWork));
        var res = await notification.SendActivationCode("1233", applicationUser);
        var statusMessage = res ? "succes" : "cant send message to mail";
        return new Result() { StatusCode = 1, StatusMessage = statusMessage };
    }
    #endregion

    #region ForgetPasswordByPhone
    public async Task<Result> ForgetPasswordByPhone(string phone, string phoneCode)
    {
        var token = _userSettingsService.GetToken();
        if (token == null)
        {
            return new Result() { StatusCode = 0, StatusMessage = "Token Not Sent" };
        }
        var applicationUserId = await _unitOfWork.UserRepository.GetUserIdByToken(token);
        if (applicationUserId == 0)
        {
            return new Result() { StatusCode = 0, StatusMessage = "User Not Found" };
        }
        var applicationUser = await _unitOfWork.UserRepository.GetUserById(applicationUserId);
        if (applicationUser == null)
        {
            return new Result() { StatusCode = 0, StatusMessage = "User Not Found" };
        }

        if (applicationUser.PhoneNumber != phone)
        {
            return new Result() { StatusCode = 0, StatusMessage = "User Phone Not Correct" };
        }
        Notification notification = new Notification(new SendPhoneActivationCode(_mailService, _logger, _unitOfWork));
        var res = await notification.SendActivationCode("123", applicationUser);
        var statusMessage = res ? "succes" : "cant send message to phone";
        return new Result() { StatusCode = 1, StatusMessage = statusMessage };
    }
    #endregion

    #region ForgetPasswordByUserName
    public async Task<Result> ForgetPasswordByUserName(string userName)
    {
        var token = _userSettingsService.GetToken();
        if (token == null)
        {
            return new Result() { StatusCode = 0, StatusMessage = "Token Not Sent" };
        }
        var applicationUserId = await _unitOfWork.UserRepository.GetUserIdByToken(token);
        if (applicationUserId == 0)
        {
            return new Result() { StatusCode = 0, StatusMessage = "User Not Found" };
        }
        var applicationUser = await _unitOfWork.UserRepository.GetUserById(applicationUserId);
        if (applicationUser == null)
        {
            return new Result() { StatusCode = 0, StatusMessage = "User Not Found" };
        }
        // to do
        // if token not assign to user 
        if (applicationUser.UserName != userName)
        {
            return new Result() { StatusCode = 0, StatusMessage = "User Name Not Correct" };
        }
        Notification notification = new Notification(new SendMailActivationCode(_mailService, _logger, _unitOfWork));
        var res = await notification.SendActivationCode("123", applicationUser);
        var statusMessage = res ? "succes" : "cant send message to mail";
        return new Result() { StatusCode = 1, StatusMessage = statusMessage };
    }
    #endregion

    #region LoginSocialMedia
    public async Task<Result> LoginSocialMedia(string socialAuthID, int socialMedia)
    {
        var applicationUser = await _unitOfWork.UserRepository.CheckSocialAuthID(socialAuthID, (SocialMedia)socialMedia);
        if (applicationUser == null)
        {
            //register
            #region Create User

            var newApplicationUser = new ApplicationUser()
            {
                Email = socialAuthID + "@Sochial.Com",
                UserName = new String(socialAuthID.Where(c => Char.IsLetter(c)).ToArray()),
                FullName = new String(socialAuthID.Where(c => Char.IsLetter(c)).ToArray()),
                IsActive = true,
                SocialAuthId = socialAuthID,
                SocialMediaType = (int)socialMedia,
                PasswordHash = socialAuthID
            };
            var result = await _unitOfWork.UserRepository.CreateUser(newApplicationUser, newApplicationUser.PasswordHash);
            if (!result)
            {
                return new Result() { StatusCode = 0, StatusMessage = "User Name Or Password Not Valid" };
            }
            #endregion

            #region SignIn
            var applicationUserAferRegistration = await _unitOfWork.UserRepository.GetUserByEmail(socialAuthID + "@Sochial.Com");
            if (applicationUserAferRegistration == null)
            {
                return new Result() { StatusCode = 0, StatusMessage = "Registration failed" };
            }

            var SignInResult = await _unitOfWork.UserRepository.SignIn(newApplicationUser.Email, socialAuthID);
            if (!SignInResult)
            {
                return new Result() { StatusCode = 0, StatusMessage = "SignIn user failed" };
            }
            return new Result() { UserId = applicationUserAferRegistration!.Id.ToString(), StatusCode = 1, StatusMessage = "SignIn user succes" };
            #endregion
        }
        else
        {
            //login
            applicationUser.IsActive = true;
            int iCount = await _unitOfWork.CompleteAsync();
            return new Result() { UserId = applicationUser!.Id.ToString(), StatusCode = 1, StatusMessage = "SignIn user succes" };
        }

    }
    #endregion
    
    // #region GetFormSetting

    //public async Task<List<FormSettingModel>> GetFormSetting()
    //{
    //    List<FormSettingModel> formSettingModelList = new List<FormSettingModel>();
     

    //    return formSettingModelList;
    //}


    //#endregion
    
   

}

