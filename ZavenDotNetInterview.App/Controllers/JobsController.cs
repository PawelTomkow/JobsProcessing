using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using ZavenDotNetInterview.App.ViewModels.Jobs;
using ZavenDotNetInterview.Core.Models;
using ZavenDotNetInterview.Infrastructure.Repositories;
using ZavenDotNetInterview.Infrastructure.Services.Interfaces;
using ZavenDotNetInterview.Persistence.Context;

namespace ZavenDotNetInterview.App.Controllers
{
    [Route("[controller]/[action]")]
    public class JobsController : Controller
    {
        private readonly IJobProcessorService _jobProcessorService;
        private readonly IJobService _jobService;
        private readonly ILogService _logService;

        public JobsController(IJobProcessorService jobProcessorService, 
            IJobService jobService, 
            ILogService logService)
        {
            _jobProcessorService = jobProcessorService;
            _jobService = jobService;
            _logService = logService;
        }

        // GET: Tasks
        public async Task<ActionResult> Index()
        {
            var jobs = await _jobService.GetAllJobs();
            return View(jobs);
        }

        // POST: Tasks/Process
        [HttpGet]
        public async Task<ActionResult> Process()
        {
            await _jobProcessorService.ProcessJobs();

            return RedirectToAction("Index");
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        public async Task<ActionResult> Create(string name, DateTime doAfter)
        {
            if (!ModelState.IsValid && await _jobService.DoesNameExist(name))
            {
                return View("Error");
            }

            try
            {
                using (var ctx = new ZavenDotNetInterviewContext())
                {
                    var newJob = new Job() { Id = Guid.NewGuid(), DoAfter = doAfter, Name = name, Status = JobStatus.New };
                    ctx.Jobs.Add(newJob);
                    ctx.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Details(Guid jobId)
        {
            var response = new DetailsViewModel()
            {
                Job = await _jobService.GetJob(jobId),
                Logs = await _logService.GetLogsJobDescending(jobId)
            };

            return View(response);
        }

        [HttpGet]
        public async Task<ActionResult> GetDataItems()
        {
            return Json(await _jobService.GetAllJobs(), JsonRequestBehavior.AllowGet);
        }
    }
}
