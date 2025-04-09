﻿using Focu.Core.Handlers;
using Focu.Core.Requests.Account;
using Focu.Web.Security;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Focu.Web.Pages.Identity;

public partial class LoginPage : ComponentBase
{
    #region Dependencies
    
    [Inject]
    public ISnackbar Snackbar { get; set; } = null!;
    
    [Inject]
    public IAccountHandler AccountHandler { get; set; } = null!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = null!;
    
    [Inject]
    public ICookieAuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;
    
    #endregion
    
    #region Properties

    protected bool IsBusy { get; set; }
    protected LoginRequest InputModel { get; } = new();
    
    #endregion
    
    #region Overrides
    
    protected override async Task OnInitializedAsync()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;
        
        if (user.Identity is { IsAuthenticated: true })
            NavigationManager.NavigateTo("/");
    }
    
    #endregion
    
    #region Methods
    
    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            var result = await AccountHandler.LoginAsync(InputModel);
            
            if(result.IsSuccess)
            {
                await AuthenticationStateProvider.GetAuthenticationStateAsync();
                AuthenticationStateProvider.NotifyAuthenticationStateChanged();
                NavigationManager.NavigateTo("/");
            }
            else
            {
                Snackbar.Add(result.Message, Severity.Error);
            }
        }
        catch (Exception ex)
        {
            Snackbar.Add(ex.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }
    
    #endregion
}