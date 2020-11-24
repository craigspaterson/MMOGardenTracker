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
        /// Posts the crop asynchronous.
        /// </summary>
        /// <param name="crop">The crop.</param>
        /// <returns>Task&lt;Crop&gt;.</returns>
        Task<Crop> PostCropAsync(Crop crop);

        /// <summary>
        /// Puts the crop asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="crop">The crop.</param>
        /// <returns>Task&lt;Crop&gt;.</returns>
        Task<Crop> PutCropAsync(int id, Crop crop);

        /// <summary>
        /// Deletes the crop asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task.</returns>
        Task DeleteCropAsync(int id);
    }
}