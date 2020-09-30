using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GT.Domain.Models
{
    /// <summary>
    /// Class Garden.
    /// </summary>
    public class Garden
    {
        /// <summary>
        /// Gets or sets the garden identifier.
        /// </summary>
        /// <value>The garden identifier.</value>
        public int GardenId { get; set; }

        /// <summary>
        /// Gets or sets the name of the garden.
        /// </summary>
        /// <value>The name of the garden.</value>
        [Required]
        [MaxLength(60)]
        public string GardenName { get; set; }

        /// <summary>
        /// Gets or sets the crops.
        /// </summary>
        /// <value>The crops.</value>
        public List<Crop> Crops { get; set; }
    }
}
