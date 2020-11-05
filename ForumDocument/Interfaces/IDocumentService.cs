using ForumDocument.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Interfaces
{
    public interface IDocumentService
    {
        Task<List<Document>> GetAllDocumentAsync();

        Task<int> saveDocumentAsync(Document document);
    }
}
