using ForumDocument.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Interfaces
{
    public interface IReportService
    {
        Task<List<Report>> GetAllReport(bool isAdmin);
        Task<int> saveReportAsync(Report report);
        Task<int> updateStatusbyID(int reportID);

        Task<int> deleteReportbyID(int reportID);
    }
}
