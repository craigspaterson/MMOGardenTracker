using System;
using System.ComponentModel.DataAnnotations;

namespace GT.Web.Api.Models
{
    /// <summary>
    /// Class CropActivity.
    /// </summary>
    public class CropActivity
    {
        /// <summary>
        /// Gets or sets the crop activity identifier.
        /// </summary>
        /// <value>The crop activity identifier.</value>
        public int CropActivityId { get; set; }

        /// <summary>
        /// Gets or sets the crop identifier.
        /// </summary>
        /// <value>The crop identifier.</value>
        public int CropId { get; set; }

        /// <summary>
        /// Gets or sets the type of the activity.
        /// </summary>
        /// <value>The type of the activity.</value>
        public Activities ActivityType { get; set; }

        /// <summary>
        /// Gets or sets the activity date.
        /// </summary>
        /// <value>The activity date.</value>
        [Required]
        public DateTimeOffset ActivityDate { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        [MaxLength(255)]
        public string Notes { get; set; }
    }
}