namespace PollyExample
{
    public class SomeService : ISomeService
    {
        private readonly HttpClient _httpClient;

        public SomeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public  string DoSomething(CancellationToken cancellationToken)
        {
            string result = string.Empty;
            _httpClient.GetAsync("notfounduri", cancellationToken);
            result = "Ok";
            return result;
           
        }
    }
}
