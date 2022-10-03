using HelloWorldLibrary.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace HelloWorldRazorClassLibrary;

public record WasmMessages(HttpClient Http) : IMessages
{
    public string Greeting(string language)
    {
        var result = string.Empty;
        var task = new Task(async () => result = await LookUpCustomTextAsync("Greeting", language));
        task.RunSynchronously();
        return result;
    }

    private async Task<string> LookUpCustomTextAsync(string key, string language)
    {
        JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        try
        {
            var messageSets = await Http.GetFromJsonAsync<CustomText[]>("_content/HelloWorldRazorClassLibrary/CustomText.json");

            var messages = messageSets?.Where(x => x.Language == language).First();

            return messages is null
                ? throw new NullReferenceException("The specified language was not found in the json file.")
                : messages.Translations[key];
        }
        catch (Exception ex)
        {
            //Log.LogError("Error looking up the custom text", ex);
            throw;
        }
    }
}
