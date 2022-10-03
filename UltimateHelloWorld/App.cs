namespace UltimateHelloWorld;

public class App
{
	private readonly IMessages _messages;

    public App(IMessages messages) => _messages = messages;

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

		var message = _messages.Greeting(lang);

		Console.WriteLine(message);
	}
}
