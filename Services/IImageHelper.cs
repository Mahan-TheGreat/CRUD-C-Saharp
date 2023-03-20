namespace CRUD.Services;

public interface IImageHelper
{
    string SaveImage(string fileName, string base64String, string filePath);
}
