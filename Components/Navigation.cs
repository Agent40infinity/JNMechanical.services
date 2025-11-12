using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;

namespace jnmechanical.services.Components
{
    public static class Navigation
    {
        public static bool visited = false;

        public const int duration = 1000;

        public static async Task NavigateTo(NavigationManager navManager, IJSRuntime js, string page)
        {
            page = StringCorrection(page);

            var forceRefresh = navManager.ToAbsoluteUri(page).AbsoluteUri == navManager.Uri;

            await js.InvokeVoidAsync("Unloaded", duration);
            await Task.Delay(duration);

            navManager.NavigateTo(page, forceRefresh);
        }

        private static string StringCorrection(string title)
        {
            return title.Replace(' ', '-');
        }
    }
}
