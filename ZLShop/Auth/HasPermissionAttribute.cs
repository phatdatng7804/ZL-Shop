using Microsoft.AspNetCore.Authorization;

namespace ZLShop.Auth;

/// <summary>
/// Custom attribute that acts as [Authorize] with a specific permission policy.
/// Usage: [HasPermission("product.create")]
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(string permission)
        : base(policy: permission)
    {
    }
}
