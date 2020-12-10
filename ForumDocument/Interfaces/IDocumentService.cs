using ForumDocument.Entities;
using ForumDocument.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Interfaces
{
    public interface IDocumentService
    {
        Task<List<Document>> GetAllDocumentAsync();

        Task<List<Document>> GetDocumentPagingAsync(FilterParam filterParam);
        Task<List<Document>> GetMostPopularDocument(FilterParam filterParam);
        Task<List<Document>> GetDocumentByUserID(Guid id);
        Task<Document> GetDocumentByID(int id);
        Task<Document> UpdateView(Document doc);
        Task<Document> UpdateDownload(Document doc);
        Task<DocumentCount> CountTotalDocument();
        Task<int> saveDocumentAsync(Document document);
        Task<int> deleteDocumentbyID(int id);
        Task<int> updateDocumentbyID(Document doc);
    }
}
