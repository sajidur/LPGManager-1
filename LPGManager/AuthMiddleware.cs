using LPGManager.Data.Services;
using Microsoft.AspNetCore.Authentication;
using System.Net.Http.Headers;
using System.Text;

public class AuthMiddleware
{
    private readonly RequestDelegate _next;

    public AuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IUserService userService)
    {
        try
        {
            var authHeader = AuthenticationHeaderValue.Parse(context.Request.Headers["Authorization"]);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);

            // authenticate credentials with user service and attach user to http context
            context.Items["User"] = await userService.Login(username, password);
        }
        catch (Exception ex)
        {
            // do nothing if invalid auth header
            // user is not attached to context so request won't have access to secure routes

        }

        await _next(context);
    }
}