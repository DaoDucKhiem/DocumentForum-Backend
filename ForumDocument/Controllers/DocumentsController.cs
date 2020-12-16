using ForumDocument.Entities;
using ForumDocument.Helpers.Enumeration;
using ForumDocument.Interfaces;
using ForumDocument.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
        [HttpPost]
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

        [HttpPost]
        [Route("mostPopular")]
        public async Task<ServiceResponse> GetMostPopularDocument([FromBody] FilterParam filterParam)
        {
            ServiceResponse result = new ServiceResponse();
            try
            {
                result.Data = await _documentService.GetMostPopularDocument(filterParam);
                result.Code = ServiceResponseCode.Success;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.OnExeption(ex);
            }
            return result;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ServiceResponse> GetDocumentByUserID(Guid id, [FromQuery] string search)
        {
            ServiceResponse result = new ServiceResponse();
            try
            {
                result.Data = await _documentService.GetDocumentByUserID(id, search);
                result.Code = ServiceResponseCode.Success;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.OnExeption(ex);
            }
            return result;
        }

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
        [HttpPost]
        [Route("updateView")]
        public async Task<ServiceResponse> UpdateView(Document document)
        {
            ServiceResponse result = new ServiceResponse();
            try
            {
                result.Data = await _documentService.UpdateView(document);
                result.Code = ServiceResponseCode.Success;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.OnExeption(ex);
            }
            return result;
        }

        [HttpPost]
        [Route("updateDownload")]
        public async Task<ServiceResponse> UpdateDownload(Document document)
        {
            ServiceResponse result = new ServiceResponse();
            try
            {
                result.Data = await _documentService.UpdateDownload(document);
                result.Code = ServiceResponseCode.Success;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.OnExeption(ex);
            }
            return result;
        }
        [HttpGet]
        [Route("countDocument")]
        public async Task<ServiceResponse> CountTotalDocument()
        {
            ServiceResponse result = new ServiceResponse();
            try
            {
                result.Data = await _documentService.CountTotalDocument();
                result.Code = ServiceResponseCode.Success;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.OnExeption(ex);
            }
            return result;
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public async Task<ServiceResponse> GetDocumentByID(int id)
        {
            ServiceResponse result = new ServiceResponse();
            try
            {
                result.Data = await _documentService.GetDocumentByID(id);
                result.Code = ServiceResponseCode.Success;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.OnExeption(ex);
            }
            return result;
        }


        [HttpDelete("{id}")]
        public async Task<ServiceResponse> deleteDocumentbyID(int id)
        {
            ServiceResponse result = new ServiceResponse();
            try
            {
                result.Data = await _documentService.deleteDocumentbyID(id);
                result.Code = ServiceResponseCode.Success;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.OnExeption(ex);
            }
            return result;
        }

        [HttpPost("updateDocument")]
        public async Task<ServiceResponse> updateDocumentbyID(Document doc)
        {
            ServiceResponse result = new ServiceResponse();
            try
            {
                result.Data = await _documentService.updateDocumentbyID(doc);
                result.Code = ServiceResponseCode.Success;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.OnExeption(ex);
            }
            return result;
        }
    }
}
