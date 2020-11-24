using GT.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GT.Domain.Repositories.Interfaces
{
    /// <summary>
    /// Interface IGardenRepository
    /// </summary>
    public interface IGardenRepository
    {
        /// <summary>
        /// Gets the gardens asynchronous.
        /// </summary>
        /// <returns>Task&lt;IEnumerable&lt;Garden&gt;&gt;.</returns>
        Task<IEnumerable<Garden>> GetGardensAsync();

        /// <summary>
        /// Gets the garden asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;Garden&gt;.</returns>
        Task<Garden> GetGardenAsync(int id);

        /// <summary>
        /// Posts the garden asynchronous.
        /// </summary>
        /// <param name="garden">The garden.</param>
        /// <returns>Task&lt;Crop&gt;.</returns>
        Task<Garden> PostGardenAsync(Garden garden);

        /// <summary>
        /// Puts the garden asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="garden">The garden.</param>
        /// <returns>Task&lt;Crop&gt;.</returns>
        Task<Garden> PutGardenAsync(int id, Garden garden);

        /// <summary>
        /// Deletes the garden asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task.</returns>
        Task DeleteGardenAsync(int id);
    }
}