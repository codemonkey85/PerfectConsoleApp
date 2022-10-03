namespace HelloWorldLibrary.BusinessLogic;

public interface IMessages
{
    string Greeting(string language);

    Task<string> GreetingAsync(string language);
}
