namespace MvcEssentials.Services.Logic
{
    using System.Drawing;
    using System.IO;
    using System.Web;

    using Common;
    using ImageProcessor;
    using ImageProcessor.Imaging;
    using ImageProcessor.Imaging.Formats;

    public class ImageProcessService : IImageProcessService
    {
        public byte[] Resize(byte[] originalImage, int width, int height)
        {
            using (var originalImageStream = new MemoryStream(originalImage))
            {
                using (var resultImage = new MemoryStream())
                {
                    using (var imageFactory = new ImageFactory())
                    {
                        var createdImage = imageFactory
                                .Load(originalImageStream);

                        if (createdImage.Image.Width > width)
                        {
                            createdImage = createdImage
                                .Resize(new ResizeLayer(new Size(width, height), ResizeMode.Crop));
                        }

                        createdImage
                            .Format(new JpegFormat { Quality = Constants.ImageQuality })
                            .Save(resultImage);
                    }

                    return resultImage.GetBuffer();
                }
            }
        }

        public byte[] ToByteArray(HttpPostedFileBase upload)
        {
            byte[] resultArray = null;

            using (var binaryReader = new BinaryReader(upload.InputStream))
            {
                resultArray = binaryReader.ReadBytes(upload.ContentLength);
            }

            return resultArray;
        }
    }
}
