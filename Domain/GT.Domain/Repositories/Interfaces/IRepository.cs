using System;
using System.Linq;
using System.Linq.Expressions;

namespace GT.Domain.Repositories.Interfaces
{
    /// <summary>
    /// Interface IRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Finds all asynchronous.
        /// </summary>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        IQueryable<T> FindAllAsync();

        /// <summary>
        /// Finds the by condition asynchronous.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        IQueryable<T> FindByConditionAsync(Expression<Func<T, bool>> expression);

        /// <summary>
        /// Creates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void CreateAsync(T entity);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="entity">The entity.</param>
        void UpdateAsync(int id, T entity);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void DeleteAsync(int id);
    }
}