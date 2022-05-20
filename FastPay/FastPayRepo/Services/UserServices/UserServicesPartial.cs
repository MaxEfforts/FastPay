
using HotChocolate;
using FastPayDB.DatabaseModels.Account.User;
using FastPayDB.Models.General;
using FastPayDB.Models.GraphResult;
using FastPayDB.Models.User;
using FastPayDB.Models.Util;
using FastPayDB.Util.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FastPayRepo.Services.UserServices;

//public partial class UserServices : IUserServices
//{
//    #region UpdateUserProfile

//    public async Task<UpdateUserProfileModel> UpdateUserProfile(UpdateUserProfileModel updateUserProfileModel)
//    {
//        try
//        {
//            var applicationUser = await _unitOfWork.UserRepository.GetUserById(updateUserProfileModel.Id);

//            if (applicationUser == null)
//            {
//                updateUserProfileModel.Result = new Result() { StatusCode = 0, StatusMessage = "can't find user by this id" };
//                return updateUserProfileModel;
//            }

//            //map to model
//            ApplicationUser updatedApplicationUser = _mapper.Map<UpdateUserProfileModel,ApplicationUser>(updateUserProfileModel);
//            await _unitOfWork.UserRepository.UpdateUserProfile(updatedApplicationUser);

//            #region Handle addFieldList

//            var addFieldList = await _unitOfWork.UserAddFieldRepository.GetAllAsync();
//            if (updateUserProfileModel.AddFieldList != null)
//                //check if any missing add fields
//                updateUserProfileModel.Result = new Result(){ ValidationErrors = new List<ValidationError>()};
//            foreach (var afm in updateUserProfileModel.AddFieldList)
//            {
//                var addFieldObj = addFieldList.FirstOrDefault(x => x?.Name?.ToLower() == afm.Name?.ToLower());
//                if (addFieldObj==null)
//                {
//                    updateUserProfileModel.Result.ValidationErrors.Add(new ValidationError
//                    {
//                        ErrorKey = "",
//                        ErrorMsg = "AddField Can't be found " + afm.Name
//                    });
//                }
//            }
            
//            //if there are some missing values then return
//            if (updateUserProfileModel.Result != null && updateUserProfileModel.Result.ValidationErrors.Count>=1)
//            {
//                updateUserProfileModel.Result.StatusCode = 0;
//                updateUserProfileModel.Result.StatusMessage = "Some AddField Can't be found";
//                return updateUserProfileModel;
//            }

//            foreach (var afm in updateUserProfileModel.AddFieldList)
//            {
//                var addFieldObj = addFieldList.FirstOrDefault(x => x?.Name?.ToLower() == afm.Name?.ToLower());
//                if (addFieldObj != null && addFieldObj.DataType == "Date") //then save date
//                {
//                    var result =
//                        await _unitOfWork.UserAddFieldDateTimeRepository.GetAsync(x =>
//                            x.UserAddFieldId == addFieldObj.Id);
//                    if (result != null)
//                    {
//                        result.Value = Convert.ToDateTime(afm.Value);
//                        _unitOfWork.UserAddFieldDateTimeRepository.Update(result);
//                    }
//                    else
//                    {
//                        result = new UserAddFieldDateTime();
//                        result.UserAddFieldId = addFieldObj.Id;
//                        result.Value = Convert.ToDateTime(afm.Value);
//                        await _unitOfWork.UserAddFieldDateTimeRepository.Add(result);
//                    }
//                }
//                else if (addFieldObj != null && addFieldObj.DataType == "Int") //then save int
//                {
//                    var result =
//                        await _unitOfWork.UserAddFieldIntRepository.GetAsync(
//                            x => x.UserAddFieldId == addFieldObj.Id);
//                    if (result != null)
//                    {
//                        result.Value = Convert.ToInt32(afm.Value);
//                        _unitOfWork.UserAddFieldIntRepository.Update(result);
//                    }
//                    else
//                    {
//                        result = new UserAddFieldInt();
//                        result.UserAddFieldId = addFieldObj.Id;
//                        result.Value = Convert.ToInt32(afm.Value);
//                        await _unitOfWork.UserAddFieldIntRepository.Add(result);
//                    }
//                }
//                else if (addFieldObj != null && addFieldObj.DataType == "Float") //then save float
//                {
//                    var result =
//                        await _unitOfWork.UserAddFieldFloatRepository.GetAsync(x =>
//                            x.UserAddFieldId == addFieldObj.Id);
//                    if (result != null) //if not found then insert as new
//                    {
//                        result.Value = Convert.ToDouble(afm.Value);
//                        _unitOfWork.UserAddFieldFloatRepository.Update(result);
//                    }
//                    else
//                    {
//                        result = new UserAddFieldFloat();
//                        result.UserAddFieldId = addFieldObj.Id;
//                        result.Value = Convert.ToDouble(afm.Value);
//                        await _unitOfWork.UserAddFieldFloatRepository.Add(result);
//                    }
//                }
//                else if (addFieldObj != null && addFieldObj.DataType == "String") //then save strings
//                {
//                    var result =
//                        await _unitOfWork.UserAddFieldStringRepository.GetAsync(x =>
//                            x.UserAddFieldId == addFieldObj.Id);

//                    if (result != null)
//                    {
//                        result.Value = Convert.ToString(afm.Value);
//                        _unitOfWork.UserAddFieldStringRepository.Update(result);
//                    }
//                    else
//                    {
//                        result = new UserAddFieldString();
//                        result.UserAddFieldId = addFieldObj.Id;
//                        result.Value = Convert.ToString(afm.Value);
//                        await _unitOfWork.UserAddFieldStringRepository.Add(result);
//                    }
//                }
//            }

//            #endregion


//            int iResultCount = await _unitOfWork.CompleteAsync();
//            updateUserProfileModel.Result = new Result() { StatusCode = 1, StatusMessage = "Success" };
//            return updateUserProfileModel;
//        }
//        catch (Exception e)
//        {
//            #region Handle exception

//            Console.WriteLine(e);
//            _logger.LogError(e, "{Repo} Login method error", typeof(UserServices));
//            updateUserProfileModel.Result = new Result
//            {
//                StatusCode = 0,
//                StatusMessage = e.StackTrace
//            };

//            #endregion
//        }
//        return updateUserProfileModel;
//    }

//    #endregion

//    #region GetUserById

//    public async Task<UserModel> GetUserById(int userId)
//    {
//        UserModel userModel = new UserModel();
//        try
//        {
//            var applicationUser = await _unitOfWork.UserRepository.GetUserById(userId);

//            if (applicationUser == null)
//            {
//                userModel.Result = new Result() { StatusCode = 0, StatusMessage = "can't find user by this id" };
//                return userModel;
//            }
            
//            /*var result = await _unitOfWork.UserRepository.login(applicationUser);
//            if (!result)
//            {
//                userModel.Result = new Result() { StatusCode = 0, StatusMessage = "Failed to login" };
//            }*/
//            //map to model
//            userModel = _mapper.Map<ApplicationUser,UserModel>(applicationUser);
            
//            //process user add fields
//            userModel.AddFieldList = new List<AddFieldModel>();
//            var userAddField = _unitOfWork.UserAddFieldRepository.Table();
//            /*var userAddFieldDateTime = _unitOfWork.UserAddFieldDateTimeRepository.Table()
//                .Include(uaf_dt=>uaf_dt.UserAddField);
//            var userAddFieldInt = _unitOfWork.UserAddFieldIntRepository.Table()
//                .Include(uaf_i=>uaf_i.UserAddField);
//            var userAddFieldString = _unitOfWork.UserAddFieldStringRepository.Table()
//                .Include(uaf_s=>uaf_s.UserAddField);
//            var userAddFieldFloat = _unitOfWork.UserAddFieldFloatRepository.Table()
//                .Include(uaf_f=>uaf_f.UserAddField);*/

//    //        var restult =await (from uaf in userAddField
//    //            join uaf_dt in _unitOfWork.UserAddFieldDateTimeRepository.Table() on uaf.Id equals uaf_dt.UserAddFieldId into uaf_dts 
//    //            from uaf_dt in uaf_dts.DefaultIfEmpty()
                
//    //            join uaf_i in _unitOfWork.UserAddFieldIntRepository.Table() on uaf.Id equals uaf_i.UserAddFieldId into uaf_is 
//    //            from uaf_i in uaf_is.DefaultIfEmpty()
                
//    //            join uaf_s in _unitOfWork.UserAddFieldStringRepository.Table() on uaf.Id equals uaf_s.UserAddFieldId into uaf_ss 
//    //            from uaf_s in uaf_ss.DefaultIfEmpty()
                
//    //            join uaf_f in _unitOfWork.UserAddFieldFloatRepository.Table() on uaf.Id equals uaf_f.UserAddFieldId into uaf_fs 
//    //            from uaf_f in uaf_fs.DefaultIfEmpty()
                
//    //            select new  AddFieldModel
//    //            {
//    //                Name = uaf.Name,
//    //                Value = GetTypeValue(uaf_dt,uaf_i,uaf_s,uaf_f),
//    //                DataType = GetTypeDataType(uaf_dt,uaf_i,uaf_s,uaf_f),
//    //                UserAddFieldId = uaf.Id
//    //            }

//    //            ).ToListAsync();

//    //        userModel.AddFieldList = restult;
            
//    //        userModel.Result = new Result() { StatusCode = 1, StatusMessage = "Success" };
//    //        return userModel;
//    //    }
//    //    catch (Exception e)
//    //    {
//    //        #region Handle exception

//    //        Console.WriteLine(e);
//    //        _logger.LogError(e, "{Repo} Login method error", typeof(UserServices));
//    //        userModel.Result = new Result
//    //        {
//    //            StatusCode = 0,
//    //            StatusMessage = e.StackTrace
//    //        };

//    //        #endregion
//    //    }
//    //    return userModel;
//    //}

//    //#endregion

    
//    //#region GetTypeDataType

//    //private static string? GetTypeDataType(UserAddFieldDateTime uafDt, UserAddFieldInt uafI, UserAddFieldString uafS, UserAddFieldFloat uafF)
//    //    {
//    //        string value = null;
//    //        if (uafDt!=null && uafI==null && uafS==null && uafF==null)
//    //        {
//    //            return DataTypeEnum.Date.ToString();
//    //        }
//    //        else if (uafDt == null && uafI != null && uafS == null && uafF == null)
//    //        {
//    //            return DataTypeEnum.Int.ToString();
//    //        }
//    //        else if (uafDt == null && uafI == null && uafS != null && uafF == null)
//    //        {
//    //            return DataTypeEnum.String.ToString();
//    //        }
//    //        else if (uafDt == null && uafI == null && uafS == null && uafF != null)
//    //        {
//    //            return DataTypeEnum.Float.ToString();
//    //        }
//    //        return value;    
//    //    }

//    //#endregion

//    //#region GetTypeValue

//    //private static string? GetTypeValue(UserAddFieldDateTime uafDt, UserAddFieldInt uafI, UserAddFieldString uafS, UserAddFieldFloat uafF)
//    //{
//    //    string value = null;
//    //    if (uafDt!=null && uafI==null && uafS==null && uafF==null)
//    //    {
//    //        return uafDt.Value.ToString();
//    //    }
//    //    else if (uafDt == null && uafI != null && uafS == null && uafF == null)
//    //    {
//    //        return uafI.Value.ToString();
//    //    }
//    //    else if (uafDt == null && uafI == null && uafS != null && uafF == null)
//    //    {
//    //        return uafS.Value.ToString();
//    //    }
//    //    else if (uafDt == null && uafI == null && uafS == null && uafF != null)
//    //    {
//    //        return uafF.Value.ToString();
//    //    }
//    //    return value;
//    //}


//    //#endregion


    
//}

