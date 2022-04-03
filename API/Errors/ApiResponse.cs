namespace API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            this.StatusCode = statusCode;
            this.Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public string GetDefaultMessageForStatusCode(int statusCode)
        {
            string message = string.Empty;
            switch (statusCode)
            {
                case 400:
                    message = "A Bad request!";
                    break;

                case 401:
                    message = "Authorize error!";
                    break;

                case 404:
                    message = "Resource Not Found!";
                    break;

                case 500:
                    message = "Server Error!";
                    break;

                default:
                    break;
            }
            return message;
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
