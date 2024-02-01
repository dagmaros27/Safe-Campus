using Microsoft.AspNetCore.Mvc;
using SafeCampus.Models;
using SafeCampus.Services;

namespace SafeCampus.Controllers;
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _reportService;

        public ReportController(ReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Report>>> Get()
        {
            var reports = await _reportService.GetAllReports();
            return Ok(reports);
        }

        [HttpGet("{id:length(24)}", Name = "GetReport")]
        public async Task<ActionResult<Report>> Get(string id)
        {
            var report = await _reportService.GetReportById(id);

            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }

        [HttpPost]
        public async Task<ActionResult<Report>> Create(Report report)
        {
            await _reportService.CreateReport(report);
            return CreatedAtRoute("GetReport", new { id = report.Id }, report);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Report report)
        {
            var existingReport = await _reportService.GetReportById(id);

            if (existingReport == null)
            {
                return NotFound();
            }

            report.CreatedAt = existingReport.CreatedAt; 
            report.UpdatedAt = DateTime.UtcNow; 

            await _reportService.UpdateReport(id, report);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingReport = await _reportService.GetReportById(id);

            if (existingReport == null)
            {
                return NotFound();
            }

            await _reportService.DeleteReport(id);

            return NoContent();
        }
    }
