namespace HelloWorldRazorClassLibrary.Pages;

public partial class Index
{
    private string? Message;

    [Inject] private HttpClient Http { get; set; } = default!;

    [Inject] private IMessages Messages { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        var lang = CurrentCulture.Name[..2];
        Message = await Messages.GreetingAsync(lang) ?? string.Empty;
        StateHasChanged();
    }
}
