
using FastPayDB.DatabaseModels.Account.User;

namespace FastPayDB.Models.General;

public class FormSettingModel: BaseFormSettingModel
{
    /// <summary>
    /// Gets or sets DataTypeName
    /// </summary>
    public string DataTypeName { get; set; }
    
    /// <summary>
    /// Gets or sets ControlTypeName
    /// </summary>
    public string ControlTypeName { get; set; }
    
    /// <summary>
    /// Gets or sets ValidationRoles
    /// </summary>
    public List<ValidationRole> ValidationRoles { get; set; }
    
    /// <summary>
    /// Gets or sets DesignAttributeList
    /// </summary>
    public List<AddFieldModel> DesignAttributeList { get; set; }
    
    /// <summary>
    /// Gets or sets OptionValueList
    /// </summary>
    public List<AddFieldModel> OptionValueList { get; set; }
    
    /// <summary>
    /// Gets or sets AddFieldId
    /// </summary>
    public int? AddFieldId { get; set; }
   
}