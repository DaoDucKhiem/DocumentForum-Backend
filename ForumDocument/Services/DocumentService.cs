﻿using ForumDocument.Entities;
using ForumDocument.Entities.DatabaseContext;
using ForumDocument.Interfaces;
using ForumDocument.Models;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Services
{
    public class DocumentService : BaseService, IDocumentService
    {

        public DocumentService(DataContext context, IAuthService authService) : base(context, authService)
        {
        }

        public async Task<List<Document>> GetAllDocumentAsync()
        {
            List<Document> listDocument;
            listDocument = await _context.Document.ToListAsync();
            return listDocument;
        }
        /// <summary>
        /// Lấy danh sách dữ liệu theo ID người dùng
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Document>> GetDocumentByUserID(Guid id, string search)
        {
            List<Document> listDocument = new List<Document>();
            var userID = new MySqlParameter("@UserID", id);
            listDocument = await _context.Document.FromSqlRaw("Select * from Document where UserID=@UserID", userID).Where(x => (x.DocumentName.Contains(search)
                                                        || x.Description.Contains(search)
                                                        || search == null)).ToListAsync();
            return listDocument;
        }

        /// <summary>
        /// lấy danh sách tài liệu theo từ khóa tìm kiếm, chuyên mục paging
        /// </summary>
        /// <param name="filterParam"></param>
        /// <returns></returns>
        /// ddkhiem
        public async Task<List<Document>> GetDocumentPagingAsync(FilterParam filterParam)
        {
            List<Document> listDocument;
            var skip = filterParam.PageIndex * filterParam.PageSize;
            listDocument = await _context.Document.Where(x => (x.CategoryID == filterParam.CategoryID || (filterParam.CategoryID == 0))
                                                        && (x.DocumentName.Contains(filterParam.SearchKey)
                                                        || x.Description.Contains(filterParam.SearchKey)
                                                        || filterParam.SearchKey == null))
                                                    .Skip(skip).Take(filterParam.PageSize).ToListAsync();
            return listDocument;
        }
        /// <summary>
        /// Lấy danh sách tài liệu phổ biến
        /// param. CategoryID = 10 : sắp xếp theo ViewCount
        /// param. CategoryID = 20 : sắp xếp theo CreatedDate
        /// </summary>
        /// <param name="filterParam"></param>
        /// <returns></returns>
        public async Task<List<Document>> GetMostPopularDocument(FilterParam filterParam)
        {
            List<Document> listDocument = new List<Document>();
            var number = new MySqlParameter("@Number", filterParam.PageSize);
            if (filterParam.CategoryID == 10)
            {
                listDocument = await _context.Document.FromSqlRaw("Select * from Document order by ViewCount DESC limit @Number", number).ToListAsync();
            }
            if (filterParam.CategoryID == 20)
            {
                listDocument = await _context.Document.FromSqlRaw("Select * from Document order by CreatedDate DESC limit @Number", number).ToListAsync();
            }
            return listDocument;
        }
        /// <summary>
        /// Lưu tài liệu
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public async Task<int> saveDocumentAsync(Document document)
        {
            _context.Document.Add(document);
            var result = await _context.SaveChangesAsync();

            return result;
        }
        /// <summary>
        /// Cập nhật lượt xem
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public async Task<Document> UpdateView(Document document)
        {
            var updatePoint = new Document();
            updatePoint = await _context.Document.SingleOrDefaultAsync(x => x.DocumentID == document.DocumentID);
            if (updatePoint != null)
            {
                updatePoint.ViewCount = updatePoint.ViewCount + 1;
            }
            _context.Entry(updatePoint).State = EntityState.Modified;
            _context.SaveChanges();
            return updatePoint;
        }
        /// <summary>
        /// Cập nhật lượt tải
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public async Task<Document> UpdateDownload(Document document)
        {
            var updatePoint = new Document();
            updatePoint = await _context.Document.SingleOrDefaultAsync(x => x.DocumentID == document.DocumentID);
            if (updatePoint != null)
            {
                updatePoint.DownloadCount = updatePoint.DownloadCount + 1;
            }
            _context.Entry(updatePoint).State = EntityState.Modified;
            _context.SaveChanges();
            return updatePoint;
        }
        /// <summary>
        /// Đếm tài liệu
        /// </summary>
        /// <returns></returns>
        public async Task<DocumentCount> CountTotalDocument()
        {
            DocumentCount countDocument = new DocumentCount();
            countDocument.Total = await _context.Document.FromSqlRaw("Select * from Document").CountAsync();
            var listDocument = await _context.Document.FromSqlRaw("Select * from Document").ToListAsync();
            listDocument.ForEach((res) =>
            {
                countDocument.TotalDownload += res.DownloadCount;
                countDocument.TotalView += res.ViewCount;
            });
            return countDocument;
        }

        public async Task<Document> GetDocumentByID(int id)
        {
            Document document = new Document();
            var ID = new MySqlParameter("@ID", id);
            document = await _context.Document.FromSqlRaw("Select * from Document where DocumentID=@ID", ID).FirstOrDefaultAsync();
            return document;
        }

        public async Task<int> deleteDocumentbyID(int id)
        {
            var document = await _context.Document.SingleOrDefaultAsync(x => x.DocumentID == id);
            _context.Document.Remove(document);
            var result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task<int> updateDocumentbyID(Document doc)
        {
            _context.Entry(doc).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task<int> UpdateDocumentAsync(Document document)
        {
            _context.Entry(document).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            return result;
        }
    }
}
