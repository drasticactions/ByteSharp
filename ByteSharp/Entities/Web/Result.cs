namespace ByteSharp.Entities.Web
{
    public class Result
    {
        public Result(bool isSuccess, string json)
        {
            IsSuccess = isSuccess;
            ResultJson = json;
        }

        public bool IsSuccess { get; private set; }
        public string ResultJson { get; private set; }
    }
}
