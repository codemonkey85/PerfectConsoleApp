using HelloWorldLibrary.Models;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace HelloWorldRazorClassLibrary.Pages;

public partial class Index
{
    private string? Message;

    [Inject] private HttpClient Http { get; set; }

    [Inject] private IMessages? Messages { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var lang = "en";
        //Message = Messages?.Greeting(lang) ?? string.Empty;
        var messageSets = await Http.GetFromJsonAsync<CustomText[]>("_content/HelloWorldRazorClassLibrary/CustomText.json");

        var messages = messageSets?.Where(x => x.Language == lang).First();

        Message = messages is null
            ? throw new NullReferenceException("The specified language was not found in the json file.")
            : messages.Translations["Greeting"];

        StateHasChanged();
    }
}
