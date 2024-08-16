using DevExpress.Utils;
using FFImageLoading;
using FFImageLoading.Work;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Graphics.Platform;
using SDK.Base.Abstractions;
using IImage = Microsoft.Maui.Graphics.IImage;

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

        /// <summary>
        /// Image service
        /// </summary>
        private readonly IImageService _imageService;

        /// <summary>
        /// MAUI image
        /// </summary>
        private IImage? _image;

        /// <summary>
        /// Photo resolution
        /// </summary>
        private double _maxSize = DeviceInfo.Platform switch
        {
            DevicePlatform => 640.0
        };

        #endregion

        /// <summary>
        /// Ctor
        /// </summary>
        public PhotoManager(ILoggerFactory loggerFactory, IImageService imageService)
        {
            _logger = loggerFactory.CreateLogger<PhotoManager>();
            _imageService = imageService;
        }

        #region Methods
        /// <inheritdoc/>
        public async Task<string?> TakePhotoAsync()
        {
            try
            {                            
                if (MediaPicker.Default.IsCaptureSupported)
                {
                    var photo = await MediaPicker.Default.CapturePhotoAsync();

                    if (photo != null)
                    {
                        using var stream = await GetStreamAsync(photo);
                        _image = PlatformImage.FromStream(stream);
                    }
                }
                if(_image != null)
                {
                    _logger.LogDebug("Photo taken");

                    return _image.Downsize((float)_maxSize, true).AsBase64();
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
        public Task<string?> AddPhotoGalleryAsync()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public bool Delete()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a flood with the desired resolution
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private async Task<Stream?> GetStreamAsync(FileResult? file)
        {
            if (file != null)
            {
                var stream = await _imageService.LoadStream(_ => file.OpenReadAsync())
                                                .DownSample((int)_maxSize, (int)_maxSize)
                                                .DownSampleMode(InterpolationMode.Medium)
                                                .AsJPGStreamAsync(_imageService, 50);
                return stream;
            }

            return null;
        }
        #endregion
    }
}
