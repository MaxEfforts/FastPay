namespace FastPayDB.DatabaseModels.Account.Address;

public class UserAddressAddFieldDateTime : BaseAddFieldDateTimeModel
{
    [Required]
    public int UserAddressAddFieldId { get; set; }
    /// <summary>
    /// Gets or sets related field option id from UserAddField table
    /// </summary>
    [ForeignKey("UserAddressAddFieldId")]
    public UserAddressAddField userAddressAddField { get; set; }
}