﻿namespace HelloWorldLibrary.Models;

public class CustomText
{
    public string Language { get; set; } = default!;

    public Dictionary<string, string> Translations { get; set; } = [];
}
