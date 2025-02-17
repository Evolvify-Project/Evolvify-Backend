using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evolvify.Application.DTOs.Response
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; }

       
        public ApiResponse(bool success,int statusCode, string message, T? data = default, List<string>? errors = null)
        {
            Success = success;
            Message = message?? GetDefaultMessage(statusCode);
            StatusCode = statusCode;
            Data = data!;
            Errors = errors ?? new List<string>();
           
        }

        public ApiResponse(T data)
        {
            Success = true;
            Message = string.Empty;
            StatusCode = 200;
            Data = data;
            Errors = new List<string>();
        }


        private string GetDefaultMessage(int statusCode)
        {
            return statusCode switch
            {
              
                400 => "The server could not understand the request due to invalid syntax.",
                401 => "The client must authenticate itself to get the requested response.",
                403 => "The client does not have access rights to the content.",
                404 => "The server can not find the requested resource.",
                405 => "The method specified in the request is not allowed.",
                500 => "The server has encountered a situation it doesn't know how to handle.",
                _ => "An error occurred while processing the request."
            };
        }

    }
}
