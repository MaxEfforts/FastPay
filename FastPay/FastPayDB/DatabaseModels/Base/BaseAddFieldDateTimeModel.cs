namespace FastPayDB.DatabaseModels.Base;

public class BaseAddFieldDateTimeModel
{
    /// <summary>
    /// Gets or sets the entity identifier
    /// </summary>
    [Key]
    public int Id { get; set; }
    
    /// <summary>
    /// Gets or sets value
    /// </summary>
    public DateTime? Value { get; set; }
}