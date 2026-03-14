using System.Net;
namespace ZLShop.Exceptions
{
    public class ZLShopException : Exception
    {
        public HttpStatusCode StatusCode { get; set;}
        public ZLShopException(string message, HttpStatusCode stastusCode = HttpStatusCode.InternalServerError) : base(message)
        {
            StatusCode = stastusCode;
        }
    }
    public class BadRequestException : ZLShopException
    {
        public BadRequestException(string message) : base(message, HttpStatusCode.BadRequest){}
    }
    public class NotFoundException : ZLShopException
    {
        public NotFoundException(string message) : base(message, HttpStatusCode.NotFound){}
    }
    public class ConflictException : ZLShopException
    {
        public ConflictException(string message) : base(message, HttpStatusCode.Conflict){}
    }
    public class ForbiddenException : ZLShopException
    {
        public ForbiddenException(string message) : base(message, HttpStatusCode.Forbidden){}
    }
    public class UnauthorizedException : ZLShopException
    {
        public UnauthorizedException(string message) : base(message, HttpStatusCode.Unauthorized){}
    }
}