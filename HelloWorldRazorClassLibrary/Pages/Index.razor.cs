namespace HelloWorldRazorClassLibrary.Pages;

public partial class Index
{
    private string? _message;

    [Inject] private IMessages Messages { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        var lang = CurrentCulture.Name[..2];
        _message = await Messages.GreetingAsync(lang);
        StateHasChanged();
    }
}
