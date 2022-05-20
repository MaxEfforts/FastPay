namespace FastPayDB.DatabaseModels.Base;

public class BaseAddFieldModel:BaseDataModel
{
    /// <summary>
    /// Gets or sets field name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Gets or sets field DataType
    /// </summary>
    public string DataType { get; set; }
}