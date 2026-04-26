namespace BackendServer.Application.Common;

public class JsonHelper
{
        public static T? Deserialize<T>(string json)
        {
            try
            {
                return System.Text.Json.JsonSerializer.Deserialize<T>(json);
            }
            catch (System.Text.Json.JsonException ex)
            {
                Console.WriteLine($"JSON-Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General issue: {ex.Message}");
            }
            return default;
        }
}