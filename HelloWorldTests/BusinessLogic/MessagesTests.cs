﻿namespace HelloWorldTests.BusinessLogic;

public class MessagesTests
{
    [Fact]
    public void Greeting_InEnglish()
    {
        ILogger<Messages> logger = new NullLogger<Messages>();
        Messages messages = new(logger);

        var expected = "Hello World";
        var actual = messages.Greeting("en");

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Greeting_InSpanish()
    {
        ILogger<Messages> logger = new NullLogger<Messages>();
        Messages messages = new(logger);

        var expected = "Hola Mundo";
        var actual = messages.Greeting("es");

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Greeting_Invalid()
    {
        ILogger<Messages> logger = new NullLogger<Messages>();
        Messages messages = new(logger);

        Assert.Throws<InvalidOperationException>(
            () => messages.Greeting("test")
            );
    }
}
