namespace FastPayDB.DatabaseModels.Account.User;

public class UserAddFieldDateTime:BaseAddFieldDateTimeModel
{
    [Required]
    public int UserAddFieldId { get; set; }
    /// <summary>
    /// Gets or sets related field option id from UserAddField table
    /// </summary>
    [ForeignKey("UserAddFieldId")]
    public UserAddField UserAddField { get; set; } 
}