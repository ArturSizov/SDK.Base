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

                return GetFilePath(photo);
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

                return GetFilePath(image);
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message);
                return null;
            }
        }

        /// <inheritdoc/>
        public bool Delete(string? image)
        {
            try
            {
                if (image == null)
                {
                    _logger.LogDebug("The image is not delete");
                    return false;
                }

                File.Delete(image);

                if(!File.Exists(image))
                {
                    _logger.LogDebug("Image delete");
                    return true;
                }

                _logger.LogDebug("The image is not delete");

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex.Message);
                return false;
            }        
        }

        private string? GetFilePath(FileResult? image)
        {
            if (image == null)
            {
                _logger.LogDebug("The image is not loaded");
                return null;
            }

            var localFilePath = Path.Combine(FileSystem.AppDataDirectory, image.FileName);

            File.Copy(image.FullPath, localFilePath, true);

            File.Delete(image.FullPath);

            if (!File.Exists(localFilePath))
            {
                _logger.LogDebug("The image is not loaded");
                return null;
            }

            _logger.LogDebug("Image uploaded");
            return localFilePath;
        }

        #endregion
    }
}
