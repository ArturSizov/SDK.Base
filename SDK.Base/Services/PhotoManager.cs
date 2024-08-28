using Microsoft.Extensions.Logging;
using SDK.Base.Abstractions;

namespace SDK.Base.Services
{
    /// <summary>
    /// Photo manager
    /// </summary>
    public class PhotoManager : IPhotoManager
    {
        #region Private property
        /// <summary>
        /// Logger
        /// </summary>
        private readonly ILogger _logger;
        #endregion

        /// <summary>
        /// Ctor
        /// </summary>
        public PhotoManager(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<PhotoManager>();
        }

        #region Methods
        /// <inheritdoc/>
        public async Task<string?> TakePhotoAsync()
        {
            try
            {
                if (!MediaPicker.Default.IsCaptureSupported)
                    return null;

                var photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    _logger.LogDebug("Photo taken");

                    return photo.FullPath;
                }

                _logger.LogDebug("Photo not taken");

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message);
                return null;
            }
        }

        /// <inheritdoc/>
        public async Task<string?> AddPhotoGalleryAsync()
        {
            try
            {
                if (!MediaPicker.Default.IsCaptureSupported)
                    return null;

                var image = await MediaPicker.Default.PickPhotoAsync();

                if (image != null)
                {
                    _logger.LogDebug("Image uploaded");

                    return image.FullPath;
                }

                _logger.LogDebug("The image is not loaded");

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message);
                return null;
            }
        }

        /// <inheritdoc/>
        public string? Delete(string? image)
        {
           if(image == null) 
                return null;

             File.Delete(image);

            return null;
        }

        #endregion
    }
}
