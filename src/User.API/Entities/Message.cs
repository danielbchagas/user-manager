using Microsoft.AspNetCore.Identity;

namespace User.API.Entities;

public record Message
{
    public string UserId { get; private set; }
    public string UserName { get; private set; }
    public string? ZipCode { get; set; }
    
    public void Update(IdentityUser user)
    {
        UserId = user.Id;
        UserName = user.UserName ?? user.Email;
    }
}