using FastPayDB.DatabaseModels.Base;

namespace FastPayDB.DatabaseModels.Account
{
    public class UserUserRoleRelation : BaseDataModel
    {
        /// <summary>
        /// Gets or sets the user identifier
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the user role identifier
        /// </summary>
        public int UserRoleId { get; set; }
    }
}