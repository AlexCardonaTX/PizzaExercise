using System;
using System.Net;

namespace PizzaHut.PizzaApp.Core.Exceptions
{
    public class CoreException : Exception
    {
        public HttpStatusCode HttpResponse { get; set; }

        public CoreException(string message, HttpStatusCode code) : base(message)
        {
            HttpResponse = code;
        }

        public CoreException(string message, Exception innerException, HttpStatusCode code) : base(string.Format(message), innerException)
        {
            HttpResponse = code;
        }
    }
}
