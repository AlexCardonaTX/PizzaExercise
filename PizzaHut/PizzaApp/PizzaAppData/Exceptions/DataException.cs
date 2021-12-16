using System;

namespace PizzaHut.PizzaApp.Data.Exceptions
{
    public class DataException : Exception
    {
        public int HttpResponse { get; set; }

        public DataException(string message, int code) : base(message)
        {
            HttpResponse = code;
        }

        public DataException(string message, Exception innerException, int code) : base(string.Format(message), innerException)
        {
            HttpResponse = code;
        }
    }
}
