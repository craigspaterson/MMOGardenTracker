using GT.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GT.Domain.Repositories.Interfaces
{
    /// <summary>
    /// Interface ICropRepository
    /// </summary>
    public interface ICropRepository
    {
        //Task<IEnumerable<Crop>> GetAllCropsAsync();
        //Task<Crop> GetCropByIdAsync(int id);
        //Task<Crop> GetCropWithDetailsAsync(int id);

        /// <summary>
        /// Gets the crops asynchronous.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;Crop&gt;&gt;.</returns>
        Task<IEnumerable<Crop>> GetCropsAsync();

        /// <summary>
        /// Gets the crop asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Crop&gt;.</returns>
        Task<Crop> GetCropAsync(int id);

        /// <summary>
        /// Creates the crop asynchronous.
        /// </summary>
        /// <param name="crop">The crop.</param>
        /// <returns>Task&lt;Crop&gt;.</returns>
        Task<Crop> CreateCropAsync(Crop crop);

        /// <summary>
        /// Updates the crop asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="crop">The crop.</param>
        /// <returns>Task&lt;Crop&gt;.</returns>
        Task<Crop> UpdateCropAsync(int id, Crop crop);

        /// <summary>
        /// Deletes the crop asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task.</returns>
        Task DeleteCropAsync(int id);

        /// <summary>
        /// Gets the crop activities asynchronous.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;CropActivity&gt;&gt;.</returns>
        Task<IEnumerable<CropActivity>> GetCropActivitiesAsync(int id);
    }
}