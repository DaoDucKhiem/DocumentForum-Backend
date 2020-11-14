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

        Task<int> saveDocumentAsync(Document document);
    }
}
