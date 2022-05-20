using System;
using System.ComponentModel.DataAnnotations;
using FastPayDB.DatabaseModels.Base;

namespace FastPayDB.DatabaseModels.Account.User
{
    public class ActivationCode : BaseDataModel
    {
        /// <summary>
        /// Gets or sets activation code
        /// </summary>
        public string Code { get; set; }
        
        /// <summary>
        /// Gets or sets the user id
        /// </summary>
        public int UserId { get; set; }
        
        /// <summary>
        /// Email
        /// Phone
        /// </summary>
        public string CodeType { get; set; }
    }
}
