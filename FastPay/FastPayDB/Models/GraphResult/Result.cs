
using FastPayDB.Models.General;

namespace FastPayDB.Models.GraphResult;

public class Result
{
    public string? UserId { get; set; }
    public int? StatusCode { get; set; }
    public string? StatusMessage { get; set; }
    public List<ValidationError> ValidationErrors { get; set; }
}

