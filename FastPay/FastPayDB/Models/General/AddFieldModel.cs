using HotChocolate.Language;

namespace FastPayDB.Models.General;

public class AddFieldModel
{
    public string Name { get; set; }
    public string? Value { get; set; }
    public string? DataType { get; set; }
    public int? UserAddFieldId { get; set; }
}