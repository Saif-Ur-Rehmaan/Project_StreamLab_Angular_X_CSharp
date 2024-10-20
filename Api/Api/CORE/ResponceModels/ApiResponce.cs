namespace Api.CORE.ResponceModels
{
    public class ApiResponce
    {
        public required string Status { get; set; }
        public required string Message { get; set; }
        public required object Data { get; set; }
    }
}
