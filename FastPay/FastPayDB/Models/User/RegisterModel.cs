
using FastPayDB.Models.GraphResult;

namespace FastPayDB.Models.User;

public class RegisterModel : ResultBase
{
    public int? UserId { get; set; }
    public string? FullName { get; set; }
    public string? UserName { get; set; }
    public string Email { get; set; }
    public bool? EmailConfirmed { get; set; }
    public string? PhoneCode { get; set; }
    public string PhoneNumber { get; set; }
    public bool? PhoneNumberConfirmed { get; set; }
    public string? PasswordHash { get; set; }
    public bool? IsSocial { get; set; }
    public string? SocialAuthID { get; set; }
    public int? SocialMediaType { get; set; }
    public string? SecurityStamp { get; set; }
    public int? AccessFailedCount { get; set; }
    public int? UserType { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsDeleted { get; set; }
    public int? CompanyId { get; set; }
    public int? VendorId { get; set; }
    public int? BranchId { get; set; }
    public int? DoctorId { get; set; }
    public int? AdminApproved { get; set; }
    public bool? TwoFactorEnabled { get; set; }
    public int? RoleId { get; set; }
    public int? GanderId { get; set; }
    public int? NationalityId { get; set; }
    public bool? HaveInsurance { get; set; }
    public string? InsuranceNumber { get; set; }
    public int? BloodTypeId { get; set; }
    public string? MedicalInformation { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public int? UpdatedBy { get; set; }
    public string? ProfilePicture { get; set; }
    public string? CivilId { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Token { get; set; }
}
