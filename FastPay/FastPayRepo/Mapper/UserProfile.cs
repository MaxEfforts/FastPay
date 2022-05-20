
using FastPayDB.DatabaseModels.Account.Address;
using FastPayDB.DatabaseModels.Account.User;
//using FastPayDB.DatabaseModels.General;
using FastPayDB.Models.Address;
using FastPayDB.Models.General;
using FastPayDB.Models.User;

namespace FastPayRepo.Mapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<ApplicationUser, RegisterModel>().ReverseMap();
        CreateMap<ActivationCodeModel, ActivationCode>().ReverseMap();
        CreateMap<UserFormSetting, FormSettingModel>().ReverseMap();
        CreateMap<ApplicationUser, UserModel>().ReverseMap();
        CreateMap<ApplicationUser, UpdateUserProfileModel>().ReverseMap();
        CreateMap<UserAddress, AddressModel>().ReverseMap();
        
        CreateMap<AddFieldOptionModel,UserAddFieldOption>().ReverseMap()
            .ForMember(dest => dest.AddFieldId, opt => opt.MapFrom(src => src.UserAddFieldId));;
      
        CreateMap<FormSettingModel,UserFormSetting>().ReverseMap()
            .ForMember(dest => dest.AddFieldId, opt => opt.MapFrom(src => src.UserAddFieldId));;
    }
}

