using ExaminationSystem.API.Exceptions;

namespace ExaminationSystem.API.ViewModels
{
    public class ResultViewModel<T>
    {
        public bool IsSuccess { get; set; }

        public T Result { get; set; }

        public string Message { get; set; }

        public ErrorCode ErrorCode { get; set; }


        public static ResultViewModel<T> Success<T>(T data, string message="")
        {
            return new ResultViewModel<T>
            {
                IsSuccess = true,
                Result = data,
                Message = message,
                ErrorCode = ErrorCode.None
            };
        }

        public static ResultViewModel<T> Failure<T>(ErrorCode errorCode, string message)
        {
            return new ResultViewModel<T>
            {
                IsSuccess = false,
                Result = default,
                Message = message,
                ErrorCode = errorCode
            };
        }

    }
}
