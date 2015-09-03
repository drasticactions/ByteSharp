using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteSharp.Entities.Comments;

namespace ByteSharp.Interfaces
{
    public interface ICommentManager
    {
        Task<CommentResponse> MakeCommentAsync(string postId, NewComment comment);
    }
}
