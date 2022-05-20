using FastPayDB.DatabaseModels.Account.User;
using FastPayDB.Models.General;
using FastPayDB.Models.GraphResult;

namespace FastPayDB.Models.User;

public class UserModel : ApplicationUser,IResultBase
{
    public Result? Result { get; set; }
    public List<AddFieldModel>? AddFieldList { get; set; }
}