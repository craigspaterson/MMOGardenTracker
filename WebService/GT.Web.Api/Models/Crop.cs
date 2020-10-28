using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT.Web.Api.Models
{
    /// <summary>
    /// Class Crop.
    /// </summary>
    public class Crop
    {
        /// <summary>
        /// Gets or sets the garden identifier.
        /// </summary>
        /// <value>The garden identifier.</value>
        [Required]
        public int GardenId { get; set; }

        /// <summary>
        /// Gets or sets the crop identifier.
        /// </summary>
        /// <value>The crop identifier.</value>
        public int CropId { get; set; }

        /// <summary>
        /// Gets or sets the name of the crop.
        /// </summary>
        /// <value>The name of the crop.</value>
        [Required]
        [MaxLength(60)]
        public string CropName { get; set; }

        /// <summary>
        /// Gets or sets the name of the plant.
        /// </summary>
        /// <value>The name of the plant.</value>
        [Required]
        [MaxLength(60)]
        public string PlantName { get; set; }

        /// <summary>
        /// Gets or sets the begin date.
        /// </summary>
        /// <value>The begin date.</value>
        [Required]
        public DateTimeOffset BeginDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>The end date.</value>
        public DateTimeOffset? EndDate { get; set; }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>The notes.</value>
        [MaxLength(255)]
        public string Notes { get; set; }

        /// <summary>
        /// Gets or sets the crop activities.
        /// </summary>
        /// <value>The crop activities.</value>
        public List<CropActivity> CropActivities { get; set; }
    }
}
