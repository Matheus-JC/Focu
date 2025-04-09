using Focu.Core.Handlers;
using Focu.Web.Security;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Focu.Web.Pages.Identity;

public partial class LogoutPage : ComponentBase
{
    #region Dependencies
    
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    
    [Inject]
    public IAccountHandler AccountHandler { get; set; } = null!;

    [Inject]
    public ICookieAuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;
    
    #endregion
    
    #region Overrides
    
    protected override async Task OnInitializedAsync()
    {
        if(await AuthenticationStateProvider.CheckAuthenticatedAsync())
        {
            await AccountHandler.LogoutAsync();
            await AuthenticationStateProvider.GetAuthenticationStateAsync();
            AuthenticationStateProvider.NotifyAuthenticationStateChanged();
            Snackbar.Add("Logged out", Severity.Info);
        }

        await base.OnInitializedAsync();
    }
    
    #endregion
}