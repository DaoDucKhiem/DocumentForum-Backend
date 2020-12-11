using ForumDocument.Entities;
using ForumDocument.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Interfaces
{
    public interface ICommentService
    {
        Task<List<Comment>> GetAllCommentByDocumentID(int it);
        Task<List<Comment>> GetCommentByDocumentID(int id);
        Task<int> saveCommentAsync(Comment Comment);
        Task<int> deleteCommentbyID(int id);
        Task<int> updateCommentbyID(Comment Comment);
    }
}
