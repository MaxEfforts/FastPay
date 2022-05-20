namespace FastPayDB.DatabaseModels.Account.User
{
    public class UserFormSetting : BaseFormSettingModel
    {
        /// <summary>
        /// Gets or sets UserAddFieldId
        /// </summary>
        public int? UserAddFieldId { get; set; }
    
        /// <summary>
        /// Gets or sets related field option id from UserAddField table
        /// </summary>
        [ForeignKey("UserAddFieldId")]
        public UserAddField? UserAddField { get; set; } 
    }
}
