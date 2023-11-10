namespace UltimateHelloWorld;

public record App(IMessages Messages)
{
    public void Run(IEnumerable<string> args)
    {
        var lang = "en";

        foreach (var arg in args)
        {
            if (!arg.StartsWith("lang=", StringComparison.CurrentCultureIgnoreCase))
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
