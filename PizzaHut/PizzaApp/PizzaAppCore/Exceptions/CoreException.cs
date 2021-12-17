using System;

namespace PizzaHut.PizzaApp.Core.Exceptions
{
    public class CoreException : Exception
    {
        public int HttpResponse { get; set; }

        public CoreException(string message, int code) : base(message)
        {
            HttpResponse = code;
        }

        public CoreException(string message, Exception innerException, int code) : base(string.Format(message), innerException)
        {
            HttpResponse = code;
        }
    }
}
