
using FastPayDB.Models.GraphResult;

namespace FastPayDB.Models;

public class ChangePasswordModel : ResultBase
{
    public string UserId { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
    public string Token { get; set; }
    public string? NewToken { get; set; }

}
