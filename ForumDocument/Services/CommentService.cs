using ForumDocument.Entities;
using ForumDocument.Entities.DatabaseContext;
using ForumDocument.Interfaces;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Services
{
    public class CommentService : BaseService, ICommentService
    {
        public CommentService(DataContext context, IAuthService authService) : base(context, authService)
        {
        }

        public async Task<int> deleteCommentbyID(int id)
        {
            var Comment = await _context.Comment.SingleOrDefaultAsync(x => x.CommentID == id);
            _context.Comment.Remove(Comment);
            var result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task<List<Comment>> GetAllCommentByDocumentID(int it)
        {
            List<Comment> listDocument = new List<Comment>();
            var DocID = new MySqlParameter("@DocID", it);
            listDocument = await _context.Comment.FromSqlRaw("Select * from Comment where DocumentID=@DocID order by CreatedDate DESC limit 10", DocID).ToListAsync();
            return listDocument;
        }

        public async Task<List<Comment>> GetCommentByDocumentID(int id)
        {
            List<Comment> listDocument = new List<Comment>();
            var DocID = new MySqlParameter("@DocID", id);
            listDocument = await _context.Comment.FromSqlRaw("Select * from Comment where DocumentID=@DocID", DocID).ToListAsync();
            return listDocument;
        }

        public async Task<int> saveCommentAsync(Comment Comment)
        {
            _context.Comment.Add(Comment);
            var result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task<int> updateCommentbyID(Comment Comment)
        {
            _context.Entry(Comment).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();

            return result;
        }
    }
}
