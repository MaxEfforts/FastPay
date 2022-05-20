
using System.Linq.Expressions;
using FastPayDB.Models.General;
using FastPayDB.Models.User;
using FastPayDB.Util.Enum;

namespace FastPayRepo.Services.Interfaces;

public interface IGeneralServices
{
   Task<List<FormSettingModel>> GetFormSetting(List<FormSettingModel> formSettingModel,List<AddFieldOptionModel> addFieldOptionModelList);
   Task<List<string>> GetFormSettingDataType();
   Task<List<string>> GetFormSettingControlType();

}

