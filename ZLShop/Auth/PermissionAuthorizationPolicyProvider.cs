using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace ZLShop.Auth;

/// <summary>
/// Dynamically creates authorization policies for any permission code.
/// When [HasPermission("product.create")] is used, this provider automatically
/// creates a matching policy with a PermissionRequirement.
/// </summary>
public class PermissionAuthorizationPolicyProvider : IAuthorizationPolicyProvider
{
    private readonly DefaultAuthorizationPolicyProvider _fallbackPolicyProvider;

    public PermissionAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
    {
        _fallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
    }

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        => _fallbackPolicyProvider.GetDefaultPolicyAsync();

    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
        => _fallbackPolicyProvider.GetFallbackPolicyAsync();

    public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        // Every policy name is treated as a permission code
        var policy = new AuthorizationPolicyBuilder()
            .AddRequirements(new PermissionRequirement(policyName))
            .Build();

        return Task.FromResult<AuthorizationPolicy?>(policy);
    }
}
