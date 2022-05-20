using System;

namespace FastPayDB.DatabaseModels.Base
{
    public class BaseDataModel : IBaseDataModel
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets if published or not
        /// </summary>
        public bool IsPublished { get; set; } = false;

        /// <summary>
        /// Gets or sets the date and time of entity creation
        /// </summary>
        public DateTime? CreatedOnUtc { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets if user is deleted or not
        /// </summary>
        public bool IsDeleted { get; set; } = false;

    }
}