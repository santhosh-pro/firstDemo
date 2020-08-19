using System.Collections.Generic;

namespace firstDemo.Common.Helpers.Models
{
    public class ErrorResponse
    {
        public ErrorResponse(){}

        public ErrorResponse(ErrorModel error)
        {
            Errors.Add(error);
        }
        
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
        
        
    }
}