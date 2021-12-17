using System;
using System.Net;

namespace PizzaHut.PizzaApp.Data.Exceptions
{
    public class DataException : Exception
    {
        public HttpStatusCode HttpResponse { get; set; }

        public DataException(string message, HttpStatusCode code) : base(message)
        {
            HttpResponse = code;
        }

        public DataException(string message, Exception innerException, HttpStatusCode code) : base(string.Format(message), innerException)
        {
            HttpResponse = code;
        }
    }
}
