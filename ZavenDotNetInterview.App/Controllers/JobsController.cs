﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
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

        public JobsController(IJobProcessorService jobProcessorService)
        {
            _jobProcessorService = jobProcessorService;
        }

        // GET: Tasks
        public async Task<ActionResult> Index()
        {
            using (ZavenDotNetInterviewContext _ctx = new ZavenDotNetInterviewContext())
            {
                JobsRepository jobsRepository = new JobsRepository(_ctx);
                List<Job> jobs = await jobsRepository.GetAllJobs();
                return View(jobs);
            }
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
            if (!ModelState.IsValid && await _jobProcessorService.DoesNameExist(name))
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
        public ActionResult Details(Guid jobId)
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetDataItems()
        {
            return Json(await _jobProcessorService.GetJobs(), JsonRequestBehavior.AllowGet);
        }
    }
}
