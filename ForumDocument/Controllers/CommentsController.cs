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
using ForumDocument.Interfaces;
using ForumDocument.Helpers.Enumeration;

namespace ForumDocument.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService documentService)
        {
            _commentService = documentService;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ServiceResponse> GetCommentByDocumentID(int id)
        {
            ServiceResponse result = new ServiceResponse();
            try
            {
                result.Data = await _commentService.GetCommentByDocumentID(id);
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
        [Route("getAll/{id}")]
        public async Task<ServiceResponse> GetAllCommentByDocumentID(int id)
        {
            ServiceResponse result = new ServiceResponse();
            try
            {
                result.Data = await _commentService.GetAllCommentByDocumentID(id);
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
        public async Task<ServiceResponse> PostDocument(Comment comment)
        {
            ServiceResponse result = new ServiceResponse();
            try
            {
                result.Data = await _commentService.saveCommentAsync(comment);
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
        public async Task<ServiceResponse> deleteCommentbyID(int id)
        {
            ServiceResponse result = new ServiceResponse();
            try
            {
                result.Data = await _commentService.deleteCommentbyID(id);
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
