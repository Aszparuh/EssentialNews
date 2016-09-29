namespace MvcEssentials.Services.Logic
{
    using System.Web;

    public interface IImageProcessService
    {
        byte[] ToByteArray(HttpPostedFileBase upload);

        byte[] Resize(byte[] originalImage, int width, int height);
    }
}
