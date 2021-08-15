﻿using System.Web.Mvc;
using VisionRT_WebApp.Models;
using DataLibrary;
using DataLibrary.BusinessLogic;
using DataLibrary.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VisionRT_WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ViewPatients()
        {
            ViewBag.Message = "Patients List";

            var data = PatientProcessor.LoadPatients();

            List<PatientModel> patients = new List<PatientModel>();

            foreach (var row in data)
            {
                patients.Add(new PatientModel
                {
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    DateOfBirth = row.DateOfBirth,
                    Gender = row.Gender
                });
            }

            return View(patients);
        }

        public ActionResult NewPatientForm()
        {
            ViewBag.Message = "Add a new patient.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewPatientForm(PatientModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = PatientProcessor.CreatePatient(model.FirstName, model.LastName, model.DateOfBirth, model.Gender);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}