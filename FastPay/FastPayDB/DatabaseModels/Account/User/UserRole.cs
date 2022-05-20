using FastPayDB.DatabaseModels.Base;

namespace FastPayDB.DatabaseModels.Account
{
    public class UserRole: BaseDataModel
    {
        /// <summary>
        /// Gets or sets the customer role name
        /// </summary>
        public string Name { get; set; }
        
    }
}