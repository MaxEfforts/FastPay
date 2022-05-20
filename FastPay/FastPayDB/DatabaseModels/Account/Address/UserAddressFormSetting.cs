namespace FastPayDB.DatabaseModels.Account.Address
{
    public class UserAddressFormSetting : BaseFormSettingModel
    {
        /// <summary>
        /// Gets or sets UserAddFieldId
        /// </summary>
        public int? UserAddressAddFieldId { get; set; }

        /// <summary>
        /// Gets or sets related field option id from UserAddField table
        /// </summary>
        [ForeignKey("UserAddressAddFieldId")]
        public UserAddressAddField? UserAddField { get; set; }
    }
}
