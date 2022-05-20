
using FastPayDB.Models.GraphResult;

namespace FastPayDB.Models;

public class LoginModel : ResultBase
{
    public int UserId { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Token { get; set; }
}

