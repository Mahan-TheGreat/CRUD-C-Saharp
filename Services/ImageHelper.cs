namespace CRUD.Services;

public class ImageHelper : IImageHelper
{
    private readonly IWebHostEnvironment _host;

    public ImageHelper(IWebHostEnvironment host)
    {
        _host = host;
    }

    public string SaveImage(string filename, string base64String, string filePath)
    {
        var fileName = filename.Split('.')[0];
        var extension = filename.Split(".")[1];
        string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        var imageName = fileName + timestamp + "." +  extension;
        var imageFolderPath = _host.WebRootPath + "\\images\\" + filePath;
        var imagePath = Path.Combine(imageFolderPath,imageName);
        byte[] imageBytes =Convert.FromBase64String(base64String);
        if(!Directory.Exists(imageFolderPath))
        {
            Directory.CreateDirectory(imageFolderPath);
        }
        File.WriteAllBytes(imagePath, imageBytes);
        return "\\images\\" + Path.Combine(filePath, imageName);

    }
}
