using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ForumDocument.Entities;
using ForumDocument.Entities.DatabaseContext;
using ForumDocument.Interfaces;
using ForumDocument.Models;
using ForumDocument.Helpers.Enumeration;

namespace ForumDocument.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        // GET: api/Documents
        [HttpGet]
        public async Task<ServiceResponse> GetDocument()
        {
            ServiceResponse result = new ServiceResponse();
            try
            {
                result.Data = await _documentService.GetAllDocumentAsync();
                result.Code = ServiceResponseCode.Success;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.OnExeption(ex);
            }
            return result;
        }

        /// <summary>
        /// get paging document
        /// </summary>
        /// <returns></returns>
        /// ddkhiem
        [HttpGet]
        [Route("documentPaging")]
        public async Task<ServiceResponse> GetDocumentPaging([FromBody] FilterParam filterParam)
        {
            ServiceResponse result = new ServiceResponse();
            try
            {
                result.Data = await _documentService.GetDocumentPagingAsync(filterParam);
                result.Code = ServiceResponseCode.Success;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.OnExeption(ex);
            }
            return result;
        }

        // GET: api/Documents/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Document>> GetDocument(int id)
        //{
        //    var document = await _context.Document.FindAsync(id);

        //    if (document == null)
        //    {
        //        return NotFound();
        //    }

        //    return document;
        //}

        //// PUT: api/Documents/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutDocument(int id, Document document)
        //{
        //    if (id != document.DocumentID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(document).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!DocumentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Documents
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        [Route("save")]
        public async Task<ServiceResponse> PostDocument(Document document)
        {
            ServiceResponse result = new ServiceResponse();
            try
            {
                result.Data = await _documentService.saveDocumentAsync(document);
                result.Code = ServiceResponseCode.Success;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.OnExeption(ex);
            }
            return result;
        }

        //// DELETE: api/Documents/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Document>> DeleteDocument(int id)
        //{
        //    var document = await _context.Document.FindAsync(id);
        //    if (document == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Document.Remove(document);
        //    await _context.SaveChangesAsync();

        //    return document;
        //}

        //private bool DocumentExists(int id)
        //{
        //    return _context.Document.Any(e => e.DocumentID == id);
        //}
    }
}
