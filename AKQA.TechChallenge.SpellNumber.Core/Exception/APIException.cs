using System.Net;
namespace AKQA.TechChallenge.SpellNumber.Core.Exception
{
    public class APIException : System.Exception           
    {
        public HttpStatusCode StatusCode { get; set; }

        public APIException(string message, System.Exception innerException, HttpStatusCode statusCode) : base(message, innerException)
        {
            StatusCode = statusCode;     
        }
    }
}
