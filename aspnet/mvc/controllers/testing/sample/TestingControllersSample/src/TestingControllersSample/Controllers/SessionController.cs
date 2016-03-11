﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNet.Mvc;
using TestingControllersSample.Core.Interfaces;
using TestingControllersSample.Core.Model;
using TestingControllersSample.Infrastructure;
using TestingControllersSample.ViewModels;

namespace TestingControllersSample.Controllers
{
    public class SessionController : Controller
    {
        private readonly IBrainStormSessionRepository _sessionRepository;

        public SessionController(IBrainStormSessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public IActionResult Index(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index","Home",null);
            }
            var session = _sessionRepository.GetById(id.Value);
            if (session == null)
            {
                return Content("Session not found.");
            }
            var viewModel = new StormSessionViewModel()
                {
                    DateCreated = session.DateCreated,
                    IdeaCount = 123,
                    Name = session.Name
                };
            return View(viewModel);
        }
    }
}