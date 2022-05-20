
namespace FastPayDB.DatabaseModels.Account.Address
{
    public class UserAddressAddFieldOption : BaseAddFieldOptionModel
    {
        /// <summary>
        /// Gets or sets related field option id from UserAddField table
        /// </summary>
        [ForeignKey("UserAddressAddFieldId")]
        public UserAddressAddField UserAddressAddField { get; set; }
    }
}
