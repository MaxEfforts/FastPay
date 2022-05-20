namespace FastPayDB.DatabaseModels.Base;

public class BaseAddFieldOptionModel:BaseDataModel
{
    /// <summary>
    /// Gets or sets field option name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets is default for this option
    /// </summary>
    public bool IsDefault { get; set; }
        
    /// <summary>
    /// Gets or sets position
    /// </summary>
    public int Position { get; set; }
}