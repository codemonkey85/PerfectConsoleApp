namespace HelloWorldRazorClassLibrary;

public record WasmMessages(HttpClient Http) : IMessages
{
    public string Greeting(string language) => throw new NotImplementedException();

    public async Task<string> GreetingAsync(string language) => await LookUpCustomTextAsync("Greeting", language);

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
