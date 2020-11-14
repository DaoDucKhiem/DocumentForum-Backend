using ForumDocument.Entities;
using ForumDocument.Entities.DatabaseContext;
using ForumDocument.Interfaces;
using ForumDocument.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Services
{
    public class DocumentService : BaseService, IDocumentService
    {

        public DocumentService(DataContext context, IAuthService authService): base(context, authService)
        {
        }

        public async Task<List<Document>> GetAllDocumentAsync()
        {
            List<Document> listDocument;
            listDocument = await _context.Document.ToListAsync();
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

        public async Task<int> saveDocumentAsync(Document document)
        {
            _context.Document.Add(document);
            var result = await _context.SaveChangesAsync();

            return result;
        }
    }
}
