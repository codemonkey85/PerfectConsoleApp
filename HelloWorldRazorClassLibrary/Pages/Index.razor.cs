namespace HelloWorldRazorClassLibrary.Pages;

public partial class Index
{
    private string? Message;

    [Inject] private HttpClient Http { get; set; }

    [Inject] private IMessages Messages { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var lang = System.Globalization.CultureInfo.CurrentCulture.Name.Substring(0, 2);
        Message = await Messages.GreetingAsync(lang) ?? string.Empty;
        StateHasChanged();
    }
}
