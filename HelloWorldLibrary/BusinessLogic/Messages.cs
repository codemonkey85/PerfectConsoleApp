namespace HelloWorldLibrary.BusinessLogic;

public record Messages(ILogger<Messages> Log) : IMessages
{
    public string Greeting(string language)
    {
        var output = LookUpCustomText("Greeting", language);
        return output;
    }

    public Task<string> GreetingAsync(string language) => throw new NotImplementedException();

    private string LookUpCustomText(string key, string language)
    {
        JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        try
        {
            var messageSets = JsonSerializer.Deserialize<List<CustomText>>
            (
                File.ReadAllText("CustomText.json"), options
            );

            var messages = messageSets?.Where(x => x.Language == language).First();

            return messages is null
                ? throw new NullReferenceException("The specified language was not found in the json file.")
                : messages.Translations[key];
        }
        catch (Exception ex)
        {
            Log.LogError("Error looking up the custom text", ex);
            throw;
        }
    }
}
