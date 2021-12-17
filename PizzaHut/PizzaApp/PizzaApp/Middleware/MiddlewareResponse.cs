namespace PizzaHut.PizzaApp.Presentation.Middleware
{
    public class MiddlewareResponse<T>
    {
        public int Status { get; set; }
        public T Data { get; set; }
        public Error Error { get; set; }

        public MiddlewareResponse() { }
        public MiddlewareResponse(T data)
        {
            this.Status = 200;
            this.Data = data;
            this.Error = new Error
            {
                Message = null
            };
        }
    }
}
