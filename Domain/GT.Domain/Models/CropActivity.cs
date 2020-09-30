using System;
using System.ComponentModel.DataAnnotations;

namespace GT.Domain.Models
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
        /// Gets or sets the activity identifier.
        /// </summary>
        /// <value>The activity identifier.</value>
        [Required]
        public int ActivityId { get; set; }

        /// <summary>
        /// Gets or sets the activity date.
        /// </summary>
        /// <value>The activity date.</value>
        [Required]
        public DateTime ActivityDate { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        [MaxLength(255)]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the crop identifier.
        /// </summary>
        /// <value>The crop identifier.</value>
        [Required]
        public int CropId { get; set; }

        /// <summary>
        /// Gets or sets the crop.
        /// </summary>
        /// <value>The crop.</value>
        public Crop Crop { get; set; }
    }
}