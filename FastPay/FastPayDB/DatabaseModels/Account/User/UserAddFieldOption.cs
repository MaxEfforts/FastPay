using System;
using System.ComponentModel.DataAnnotations;
using FastPayDB.DatabaseModels.Account.User;
using FastPayDB.DatabaseModels.Base;

namespace FastPayDB.DatabaseModels.Account.User
{
    public class UserAddFieldOption : BaseAddFieldOptionModel
    {
        /// <summary>
        /// Gets or sets UserAddFieldId
        /// </summary>
        [Required]
        public int UserAddFieldId { get; set; }
    
        /// <summary>
        /// Gets or sets related field option id from UserAddField table
        /// </summary>
        [ForeignKey("UserAddFieldId")]
        public UserAddField UserAddField { get; set; } 
    }
}
