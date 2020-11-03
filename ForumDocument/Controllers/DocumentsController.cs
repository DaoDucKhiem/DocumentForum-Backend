using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ForumDocument.Entities;
using ForumDocument.Entities.DatabaseContext;
using ForumDocument.Models;
using ForumDocument.Helpers.Enumeration;
using ForumDocument.Interfaces;

namespace ForumDocument.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentSV;

        public DocumentsController(IDocumentService documentService)
        {
            _documentSV = documentService;
        }

        // GET: api/Documents
        [HttpGet]
        public async Task<ServiceResponse> GetDocument()
        {
            ServiceResponse result = new ServiceResponse();
            try
            {
                result.Data = _documentSV.GetAllDocumentAsync();
                result.Code = ServiceResponseCode.Success;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.OnExeption(ex);
            }

            return await Task.FromResult(result);
        }

    //    // GET: api/Documents/5
    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<Document>> GetDocument(int id)
    //    {
    //        var document = await _context.Document.FindAsync(id);

    //        if (document == null)
    //        {
    //            return NotFound();
    //        }

    //        return document;
    //    }

    //    // PUT: api/Documents/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    //    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> PutDocument(int id, Document document)
    //    {
    //        if (id != document.DocumentID)
    //        {
    //            return BadRequest();
    //        }

    //        _context.Entry(document).State = EntityState.Modified;

    //        try
    //        {
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!DocumentExists(id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return NoContent();
    //    }

    //    // POST: api/Documents
    //    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    //    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    //    [HttpPost]
    //    public async Task<ActionResult<Document>> PostDocument(Document document)
    //    {
    //        _context.Document.Add(document);
    //        await _context.SaveChangesAsync();

    //        return CreatedAtAction("GetDocument", new { id = document.DocumentID }, document);
    //    }

    //    // DELETE: api/Documents/5
    //    [HttpDelete("{id}")]
    //    public async Task<ActionResult<Document>> DeleteDocument(int id)
    //    {
    //        var document = await _context.Document.FindAsync(id);
    //        if (document == null)
    //        {
    //            return NotFound();
    //        }

    //        _context.Document.Remove(document);
    //        await _context.SaveChangesAsync();

    //        return document;
    //    }

    //    private bool DocumentExists(int id)
    //    {
    //        return _context.Document.Any(e => e.DocumentID == id);
    //    }
    }
}
