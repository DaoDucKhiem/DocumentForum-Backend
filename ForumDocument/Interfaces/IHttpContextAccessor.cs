using Microsoft.AspNetCore.Http;

namespace ForumDocument.Interfaces
{
    public interface IHttpContextAccessor
    {
        HttpContext HttpContext { get; set; }
    }
}
