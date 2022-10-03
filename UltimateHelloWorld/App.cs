namespace UltimateHelloWorld;

public record App(IMessages Messages)
{
    public void Run(string[] args)
    {
        var lang = "en";

        for (var i = 0; i < args.Length; i++)
        {
            if (args[i].ToLower().StartsWith("lang="))
            {
                lang = args[i][5..];
                break;
            }
        }

        var message = Messages.Greeting(lang);

        Console.WriteLine(message);
    }
}
