using ForumDocument.Entities;
using ForumDocument.Entities.DatabaseContext;
using ForumDocument.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Services
{
    public class DocumentService : IDocumentService, IBaseService<Document>
    {
        private readonly DataContext _context;

        public DocumentService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Document>> GetAllDocumentAsync()
        {
            List<Document> listDocument;
            listDocument = await _context.Document.ToListAsync();
            return listDocument;
        }
    }
}
