
using FastPayDB.Models.General;
using FastPayDB.Models.GraphResult;

namespace FastPayDB.Models.User;

public class UpdateUserProfileModel : ResultBase
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? PhoneCode { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PasswordHash { get; set; }
    public int? CompanyId { get; set; }
    public int? VendorId { get; set; }
    public int? RoleId { get; set; }
    public string? ProfilePicture { get; set; }
    
    public List<AddFieldModel>? AddFieldList { get; set; }

}
