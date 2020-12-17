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
    public class ReportsController : ControllerBase
    {

        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ServiceResponse> GetAllCommentByDocumentID(bool isAdmin)
        {
            ServiceResponse result = new ServiceResponse();
            try
            {
                result.Data = await _reportService.GetAllReport(isAdmin);
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
        public async Task<ServiceResponse> PostDocument(Report report)
        {
            ServiceResponse result = new ServiceResponse();
            try
            {
                result.Data = await _reportService.saveReportAsync(report);
                result.Code = ServiceResponseCode.Success;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.OnExeption(ex);
            }
            return result;
        }
        [HttpPut]
        [Route("update/{id}")]
        public async Task<ServiceResponse> updateStatusbyID(int id)
        {
            ServiceResponse result = new ServiceResponse();
            try
            {
                result.Data = await _reportService.updateStatusbyID(id);
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
        public async Task<ServiceResponse> deleteReportbyID(int id)
        {
            ServiceResponse result = new ServiceResponse();
            try
            {
                result.Data = await _reportService.deleteReportbyID(id);
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
