//Models/ErrorResponse.cs
namespace ToDoAPI.Models{
    public class ErrorResponse{
        public string? Title { get; set;}
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
    
}