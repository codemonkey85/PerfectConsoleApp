namespace HelloWorldRazorClassLibrary.Pages;

public partial class Index
{
    private string? message;

    [Inject] private IMessages Messages { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        var lang = CurrentCulture.Name[..2];
        message = await Messages.GreetingAsync(lang);
        StateHasChanged();
    }
}
