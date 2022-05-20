using HotChocolate;
using FastPayDB.DatabaseModels.Account.Address;
using FastPayDB.Models.Address;
using FastPayDB.Models.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastPayRepo.Services.AddressServises { }
//{
//    public class AddressService : IAddressService
//    {
//        private readonly IUserSettingsService _userSettingsService;
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IMapper _mapper;
//        private new readonly IGeneralServices _generalService;
//        private new readonly ILogger _logger;

//        public AddressService([Service] IUserSettingsService userSettingsService,
//            IGeneralServices generalService, IUnitOfWork unitOfWork,
//            ILogger logger, IMapper mapper)
//        {

//            this._userSettingsService = userSettingsService;
//            this._unitOfWork = unitOfWork;
//            this._mapper = mapper;
//            this._generalService = generalService;
//            this._logger = logger;
//        }

//        public async Task<AddressModel> AddAddress(AddressModel addressModel)
//        {
//            var token = _userSettingsService.GetToken();
//            if (token == null)
//            {
//                addressModel.Result = new Result() { StatusCode = 0, StatusMessage = "Token Not Sent" };
//                return addressModel;
//            }
//            var applicationUser = await _unitOfWork.UserRepository.GetUserById(addressModel.UserId);
//            if (applicationUser == null)
//            {
//                addressModel.Result = new Result() { StatusCode = 0, StatusMessage = "User Not Found" };
//                return addressModel;
//            }

//            if (addressModel != null)
//            {
//                try
//                {
//                    var address = new UserAddress();
//                    address = _mapper.Map<UserAddress>(addressModel);
//                    await _unitOfWork.AddressRepository.Add(address);
//                    await _unitOfWork.CompleteAsync();
//                    var newAddressModel = _mapper.Map<AddressModel>(address);
//                    newAddressModel.Result = new Result() { StatusCode = 1, StatusMessage = "Success" };
//                    return newAddressModel;
//                }
//                catch (Exception ex)
//                {
//                    addressModel.Result = new Result { StatusCode = 0, StatusMessage = ex.Message.ToString() };
//                    return addressModel;
//                }
//            }
//            else
//            {
//                addressModel = new AddressModel() { };
//                addressModel.Result = new Result { StatusCode = 0, StatusMessage = "addressModel not sent" };
//                return addressModel;
//            }

//        }

//        public async Task<Result> UpdateAddress(AddressModel addressModel, int addressId)
//        {
//            var token = _userSettingsService.GetToken();
//            if (token == null)
//            {
//                return new Result() { StatusCode = 0, StatusMessage = "Token Not Sent" };
//            }
//            var applicationUser = await _unitOfWork.UserRepository.GetUserById(addressModel.UserId);
//            if (applicationUser == null)
//            {
//                return new Result() { StatusCode = 0, StatusMessage = "User Not Found" };
//            }

//            var address = await _unitOfWork.AddressRepository.GetAsync(x => x.Id == addressId);
//            if (address == null)
//            {
//                return new Result() { StatusCode = 0, StatusMessage = "Address Not Found" };
//            }

//            try
//            {

//                // address = _mapper.Map<UserAddress>(addressModel);
//                address.Email = addressModel.Email;
//                address.PhoneNumber = addressModel.PhoneNumber;
//                address.CountryId = addressModel.CountryId;
//                address.StateProvinceId = addressModel.StateProvinceId;
//                address.Country = addressModel.Country;
//                address.Address1 = addressModel.Address1;
//                address.Address2 = addressModel.Address2;
//                address.ZipPostalCode = addressModel.ZipPostalCode;
//                address.PhoneCode = addressModel.PhoneCode;
//                address.PhoneNumber = addressModel.PhoneNumber;
//                address.UserId = addressModel.UserId;
//                address.AdditionalInformation = addressModel.AdditionalInformation;


//                // var newAddressModel = _mapper.Map<AddressModel>(address);
//                //--------------------------------------------------------------------------------
//                var addFieldList = await _unitOfWork.UserAddressAddFieldRepository.GetAllAsync();
   
//                await _unitOfWork.CompleteAsync();
//                return new Result() { StatusCode = 1, StatusMessage = "Success" };
//            }
//            catch (Exception ex)
//            {
//                return new Result() { StatusCode = 0, StatusMessage = ex.Message.ToString() };
//            }

//        }

//        //public async Task<Result> DeleteAddress(int addressId)
//        //{
//        //    var token = _userSettingsService.GetToken();
//        //    if (token == null)
//        //    {
//        //        return new Result() { StatusCode = 0, StatusMessage = "Token Not Sent" };
//        //    }
//        //    var address = await _unitOfWork.AddressRepository.GetAsync(x => x.Id == addressId);
//        //    if (address == null)
//        //    {
//        //        return new Result() { StatusCode = 0, StatusMessage = "Address Not Found" };
//        //    }

//        //    try
//        //    {
//        //        await _unitOfWork.AddressRepository.Remove(addressId);
//        //        await _unitOfWork.CompleteAsync();
//        //        return new Result() { StatusCode = 1, StatusMessage = "Success" };
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        return new Result() { StatusCode = 0, StatusMessage = ex.Message.ToString() };
//        //    }

//        //}

//        //public async Task<AddressModel> GetAddressById(int addressId)
//        //{
//        //    var address = await _unitOfWork.AddressRepository.GetAsync(x => x.Id == addressId);
//        //    if (address == null)
//        //    {
//        //        var addresModel = new AddressModel();
//        //        addresModel.Result = new Result() { StatusCode = 0, StatusMessage = "Address Not Found" };
//        //        return addresModel;
//        //    }
//        //    var addressModel = _mapper.Map<AddressModel>(address);
//        //    addressModel.AddFieldList = new List<AddFieldModel>();
//        //    var userAddressAddField = _unitOfWork.UserAddressAddFieldRepository.Table();


//        //    var restult = await (from uaf in userAddressAddField
//        //                         join uaf_dt in _unitOfWork.UserAddressAddFieldDateTimeRepository.Table() on uaf.Id equals uaf_dt.UserAddressAddFieldId into uaf_dts
//        //                         from uaf_dt in uaf_dts.DefaultIfEmpty()

//        //                         join uaf_i in _unitOfWork.UserAddressAddFieldIntRepository.Table() on uaf.Id equals uaf_i.UserAddressAddFieldId into uaf_is
//        //                         from uaf_i in uaf_is.DefaultIfEmpty()

//        //                         join uaf_s in _unitOfWork.UserAddressAddFieldStringRepository.Table() on uaf.Id equals uaf_s.UserAddressAddFieldId into uaf_ss
//        //                         from uaf_s in uaf_ss.DefaultIfEmpty()

//        //                         join uaf_f in _unitOfWork.UserAddressAddFieldFloatRepository.Table() on uaf.Id equals uaf_f.UserAddressAddFieldId into uaf_fs
//        //                         from uaf_f in uaf_fs.DefaultIfEmpty()

//        //                         select new AddFieldModel
//        //                         {
//        //                             Name = uaf.Name,
//        //                             Value = GetTypeValue(uaf_dt, uaf_i, uaf_s, uaf_f),
//        //                             DataType = GetTypeDataType(uaf_dt, uaf_i, uaf_s, uaf_f),
//        //                             UserAddFieldId = uaf.Id
//        //                         }

//        //        ).ToListAsync();

//        //    addressModel.AddFieldList = restult;
//        //    return addressModel;
//        //}

//        //private static string? GetTypeDataType(UserAddressAddFieldDateTime uafDt, UserAddressAddFieldInt uafI, UserAddressAddFieldString uafS, UserAddressAddFieldFloat uafF)
//        //{
//        //    string value = null;
//        //    if (uafDt != null && uafI == null && uafS == null && uafF == null)
//        //    {
//        //        return DataTypeEnum.Date.ToString();
//        //    }
//        //    else if (uafDt == null && uafI != null && uafS == null && uafF == null)
//        //    {
//        //        return DataTypeEnum.Int.ToString();
//        //    }
//        //    else if (uafDt == null && uafI == null && uafS != null && uafF == null)
//        //    {
//        //        return DataTypeEnum.String.ToString();
//        //    }
//        //    else if (uafDt == null && uafI == null && uafS == null && uafF != null)
//        //    {
//        //        return DataTypeEnum.Float.ToString();
//        //    }
//        //    return value;
//        //}


//        //private static string? GetTypeValue(UserAddressAddFieldDateTime uafDt, UserAddressAddFieldInt uafI, UserAddressAddFieldString uafS, UserAddressAddFieldFloat uafF)
//        //{
//        //    string value = null;
//        //    if (uafDt != null && uafI == null && uafS == null && uafF == null)
//        //    {
//        //        return uafDt.Value.ToString();
//        //    }
//        //    else if (uafDt == null && uafI != null && uafS == null && uafF == null)
//        //    {
//        //        return uafI.Value.ToString();
//        //    }
//        //    else if (uafDt == null && uafI == null && uafS != null && uafF == null)
//        //    {
//        //        return uafS.Value.ToString();
//        //    }
//        //    else if (uafDt == null && uafI == null && uafS == null && uafF != null)
//        //    {
//        //        return uafF.Value.ToString();
//        //    }
//        //    return value;
//        //}

//        #region GetFormSetting

//        public async Task<List<FormSettingModel>> GetAddressFormSetting()
//        {
//            List<FormSettingModel> formSettingModelList = new List<FormSettingModel>();
//            try
//            {
//                List<UserAddressFormSetting?> formSetting = await _unitOfWork.UserAddressFormSettingRepository.GetAllAsync();
//                List<FormSettingModel> formSettingModel = _mapper.Map<List<UserAddressFormSetting>, List<FormSettingModel>>(formSetting!);

//                IEnumerable<UserAddressAddFieldOption?> addFieldOptionList = new List<UserAddressAddFieldOption?>();

//                #region handle option list for list values if any

//                foreach (var x in formSettingModel)
//                {
//                    if (x.ControlType == (int)ControlTypeEnum.CheckList
//                        || x.ControlType == (int)ControlTypeEnum.DropList
//                        || x.ControlType == (int)ControlTypeEnum.RadioList)
//                    {
//                        if (addFieldOptionList != null && addFieldOptionList.Count() <= 0)
//                        {
//                            addFieldOptionList = await _unitOfWork.UserAddressAddFieldOptionRepository.GetAllAsync();
//                        }
//                    }
//                }
//                #endregion

//                List<AddFieldOptionModel> addFieldOptionModelList = _mapper.Map<IEnumerable<UserAddressAddFieldOption>, List<AddFieldOptionModel>>(addFieldOptionList);
//                formSettingModelList = await _generalService.GetFormSetting(formSettingModel, addFieldOptionModelList);
//                return formSettingModelList;
//            }
//            catch (Exception e)
//            {
//                #region Handle exception

//                Console.WriteLine(e);
//                _logger.LogError(e, "{Repo} Register method error", typeof(AddressService));

//                #endregion
//            }

//            return formSettingModelList;
//        }


//        #endregion
//    }
//}
