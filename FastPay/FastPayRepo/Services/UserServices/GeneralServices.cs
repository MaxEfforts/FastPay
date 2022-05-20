
using System.Linq.Expressions;
using HotChocolate;
using FastPayDB.Models.General;
using Microsoft.Extensions.Logging;

namespace FastPayRepo.Services.UserServices;

public class GeneralServices : IGeneralServices
{
    private readonly IUserSettingsService _userSettingsService;
    
    #region Fields

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly AppSettings _appSettings;
    private new readonly ILogger _logger;
    private new readonly IMailService _mailService;

    #endregion

    #region Constractor

    public GeneralServices([Service] IUserSettingsService userSettingsService, IMapper mapper, IUnitOfWork unitOfWork,
        IOptions<AppSettings> appSettings, ILogger logger, IMailService mailService)
    {
        this._userSettingsService = userSettingsService;
        this._mapper = mapper;
        this._unitOfWork = unitOfWork;
        this._appSettings = appSettings.Value;
        this._logger = logger;
        this._mailService = mailService;
    }

    #endregion

       #region GetFormSetting

    public async Task<List<FormSettingModel>> GetFormSetting(List<FormSettingModel> formSettingModel,List<AddFieldOptionModel> addFieldOptionModelList)
    {
        try
        {
            foreach (var x in formSettingModel)
            {
                x.DesignAttributeList = new List<AddFieldModel>();

                #region handle option list for list values if any
                
                x.OptionValueList = x.OptionValueList==null ? new List<AddFieldModel>():x.OptionValueList;
                if (x.ControlType==(int)ControlTypeEnum.CheckList
                    || x.ControlType==(int)ControlTypeEnum.DropList
                    || x.ControlType==(int)ControlTypeEnum.RadioList)
                {
                    if (addFieldOptionModelList!=null)
                    {
                        var userAddFieldOptions = addFieldOptionModelList.Where(uafo => uafo.AddFieldId == x.AddFieldId);
                        if (userAddFieldOptions!=null && userAddFieldOptions.Count()>=1) //found then get them
                        {
                            foreach (var userAddFieldOption in userAddFieldOptions)
                            {
                                x.OptionValueList.Add(new AddFieldModel
                                {
                                    Name = userAddFieldOption.Name,
                                    Value = userAddFieldOption.Id.ToString(),
                                });
                            }
                        }
                    }
                }

                #endregion
                
                x.ControlTypeName = ((ControlTypeEnum)x.ControlType).ToString();
                x.DataTypeName = ((DataTypeEnum)x.DataType).ToString();
                    
                //update ValidationRoles collection
                x.ValidationRoles = x.ValidationRoles==null? new List<ValidationRole>():x.ValidationRoles;

                #region IsRequired

                if (x.Required!=null)
                {
                    x.ValidationRoles.Add(new ValidationRole
                    {
                        RoleKey = GetPropertyName(() => x.Required),
                        RoleValue = x.Required.ToString(),
                        ErrorMsg = x.RequiredErrorMsg?.ToString(),
                    });
                }

                #endregion
                    
                #region IsReadOnly

                if (x.IsReadOnly!=null)
                {
                    x.ValidationRoles.Add(new ValidationRole
                    {
                        RoleKey = GetPropertyName(() => x.IsReadOnly),
                        RoleValue = x.IsReadOnly.ToString(),
                        ErrorMsg = null,
                    });
                }

                #endregion
                    
                #region IsUnique

                if (x.IsUnique!=null)
                {
                    x.ValidationRoles.Add(new ValidationRole
                    {
                        RoleKey = GetPropertyName(() => x.IsUnique),
                        RoleValue = x.IsUnique.ToString(),
                        ErrorMsg = x.UniqueErrorMsg?.ToString(),
                    });
                }

                #endregion
                    
                #region ValidationExpression

                if (x.ValidationExpression!=null)
                {
                    x.ValidationRoles.Add(new ValidationRole
                    {
                        RoleKey = GetPropertyName(() => x.ValidationExpression),
                        RoleValue = x.ValidationExpression.ToString(),
                        ErrorMsg = x.ValidationExpressionErrorMsg?.ToString(),
                    });
                }

                #endregion
                    
                #region MaxLength

                if (x.MaxLength!=null)
                {
                    x.ValidationRoles.Add(new ValidationRole
                    {
                        RoleKey = GetPropertyName(() => x.MaxLength),
                        RoleValue = x.MaxLength.ToString(),
                        ErrorMsg = x.MaxLengthErrorMsg?.ToString(),
                    });
                }

                #endregion
                    
                #region MinLength

                if (x.MinLength!=null)
                {
                    x.ValidationRoles.Add(new ValidationRole
                    {
                        RoleKey = GetPropertyName(() => x.MinLength),
                        RoleValue = x.MinLength.ToString(),
                        ErrorMsg = x.MinLengthErrorMsg?.ToString(),
                    });
                }

                #endregion
                
            }
           
        }
        catch (Exception e)
        {
            #region Handle exception

            Console.WriteLine(e);
            _logger.LogError(e, "{Repo} GetAllFormSetting method error", typeof(UserServices));
            /*userRegisterFormSettingModel.Result = new Result
            {
                StatusCode = 0,
                StatusMessage = e.StackTrace
            };*/


            #endregion
        }
        return formSettingModel;
    }


    #endregion
    
    #region GetFormSettingDataType

    public async Task<List<string>> GetFormSettingDataType()
    {
        try
        {
            return Enum.GetNames(typeof(DataTypeEnum)).ToList();
        }
        catch (Exception e)
        {
            #region Handle exception

            Console.WriteLine(e);
            _logger.LogError(e, "{Repo} GetFormSettingDataType method error", typeof(UserServices));

            #endregion
        }
        return null;
    }

    #endregion
    
    #region GetFormSettingControlType

    public async Task<List<string>> GetFormSettingControlType()
    {
        try
        {
            return Enum.GetNames(typeof(ControlTypeEnum)).ToList();
        }
        catch (Exception e)
        {
            #region Handle exception

            Console.WriteLine(e);
            _logger.LogError(e, "{Repo} GetFormSettingControlType method error", typeof(UserServices));

            #endregion
        }
        return null;
    }

    #endregion

    #region GetPropertyName

    public static string GetPropertyName<T>(Expression<Func<T>> propertyExpression)
    {
        return (propertyExpression.Body as MemberExpression).Member.Name;
    }

    #endregion
}

