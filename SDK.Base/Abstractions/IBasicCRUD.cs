namespace SDK.Base.Abstractions
{
    /// <summary>
    /// An interface to provide basic CRUD operations
    /// </summary>
    public interface IBasicCRUD<T>
    {
        /// <summary>
		/// Adds one entry to the storage
		/// </summary>
		/// <param name="item"></param>
		/// <returns>Boolian</returns>
		Task<bool> CreateAsync(T item);

        /// <summary>
        /// Returns one record from the storage
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T?> ReadAsync(int id);

        /// <summary>
        /// Updates one record in the storage
        /// </summary>
        /// <param name="item">Item to update</param>
        /// <returns>Boolian</returns>
        Task<bool> UpdateAsync(T item);

        /// <summary>
        /// Deleting a Single Record in a storage
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Boolian</returns>
        Task<bool> DeleteAsync(T item);

        /// <summary>
        /// Returns all records from the storage
        /// </summary>
        /// <returns></returns>
        Task<List<T?>> ReadAllAsync();

        /// <summary>
        /// Deletes all records from the storage. Be careful!
        /// </summary>
        /// <returns>Boolian</returns>
        Task<bool> DeleteAllAsync();
    }
}
