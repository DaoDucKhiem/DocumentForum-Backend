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
    public class ReportService : BaseService, IReportService
    {
        public ReportService(DataContext context, IAuthService authenService) : base(context, authenService)
        {
        }

        public async Task<int> deleteReportbyID(int reportID)
        {
            var report = await _context.Report.SingleOrDefaultAsync(x => x.ReportID == reportID);
            _context.Report.Remove(report);
            var result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task<List<Report>> GetAllReport(bool isAdmin)
        {
            List<Report> listReport = new List<Report>();
            listReport = await _context.Report.FromSqlRaw("Select * from Report order by CreatedDate DESC").ToListAsync();
            return listReport;
        }

        public async Task<int> saveReportAsync(Report report)
        {
            _context.Report.Add(report);
            var result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task<int> updateStatusbyID(int reportID)
        {
            var report = await _context.Report.SingleOrDefaultAsync(x => x.ReportID == reportID);
            report.Status = 1;
            _context.Entry(report).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();

            return result;
        }
    }
}
