using Microsoft.AspNetCore.Authorization;

namespace ZLShop.Auth;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        var permissionsClaim = context.User.FindFirst("permissions");

        if (permissionsClaim == null)
        {
            return Task.CompletedTask; // No permissions claim → fail
        }

        var permissions = permissionsClaim.Value.Split(',', StringSplitOptions.RemoveEmptyEntries);

        if (permissions.Contains(requirement.Permission))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
