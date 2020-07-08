using System;

namespace Common
{
    public class ObjectResponse<T>
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }

        public ObjectResponse(bool isSuccess, string message, T data)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;

        }
        public ObjectResponse(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}
