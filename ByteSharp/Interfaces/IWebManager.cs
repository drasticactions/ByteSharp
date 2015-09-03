using System;
using System.Net.Http;
using System.Threading.Tasks;
using ByteSharp.Entities.Web;

namespace ByteSharp.Interfaces
{
    public interface IWebManager
    {
        bool IsNetworkAvailable { get; }
        Task<Result> PostData(Uri uri, MultipartContent header, StringContent content);

        Task<Result> PutData(Uri uri, StringContent json);

        Task<Result> DeleteData(Uri uri, StringContent json);

        Task<Result> GetData(Uri uri);
        Task<Result> PutData(Uri uri, MultipartContent p, StringContent stringContent);
    }
}
