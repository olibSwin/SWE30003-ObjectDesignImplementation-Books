using System.IO;
using System.Text.Json;

public static class JsonStorageService
{
    public static void Save<T>(string filePath, T data)
    {
        var directory = Path.GetDirectoryName(filePath);

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true
        });

        File.WriteAllText(filePath, json);
    }

    public static T Load<T>(string filePath)
    {
        if (!File.Exists(filePath))
            return default;

        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(json);
    }
}