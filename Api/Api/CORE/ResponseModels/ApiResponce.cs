namespace Api.CORE.ResponseModels
{
    public class ApiResponse
    {
        public required string Status { get; set; }
        public required string Message { get; set; }
        public required object Data { get; set; }
            
    }
    
}
