namespace HelloWorldLibrary.BusinessLogic;

public class Messages : IMessages
{
    private readonly ILogger<Messages> _log;

    public Messages(ILogger<Messages> log) => _log = log;

    public string Greeting(string language)
    {
        var output = LookUpCustomText("Greeting", language);
        return output;
    }

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
            _log.LogError("Error looking up the custom text", ex);
            throw;
        }
    }
}
