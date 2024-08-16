namespace SDK.Base.Abstractions
{
    public interface IPhotoManager
    {
        /// <summary>
        /// Take a photo with the camera
        /// </summary>
        /// <returns></returns>
        public Task<string?> TakePhotoAsync();

        /// <summary>
        /// Select a photo from the gallery
        /// </summary>
        /// <returns></returns>
        public Task<string?> AddPhotoGalleryAsync();

        /// <summary>
        /// Delete photo
        /// </summary>
        /// <returns></returns>
        public bool Delete();
    }
}
