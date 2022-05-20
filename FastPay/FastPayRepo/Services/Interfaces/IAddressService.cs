using FastPayDB.Models.Address;
using FastPayDB.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastPayRepo.Services.Interfaces
{
    public interface IAddressService
    {
        Task<AddressModel> AddAddress(AddressModel addressModel);
        Task<Result> UpdateAddress(AddressModel addressModel, int addressId);
        Task<Result> DeleteAddress(int addressId);
        Task<AddressModel> GetAddressById(int addressId);
        Task<List<FormSettingModel>> GetAddressFormSetting();
    }
}
