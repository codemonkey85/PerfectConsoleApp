namespace UltimateHelloWorld;

public record App(IMessages Messages)
{
    public void Run(string[] args)
    {
        var lang = "en";

        foreach (var arg in args)
        {
            if (!arg.ToLower().StartsWith("lang="))
            {
                continue;
            }

            lang = arg[5..];
            break;
        }

        var message = Messages.Greeting(lang);

        Console.WriteLine(message);
    }
}
