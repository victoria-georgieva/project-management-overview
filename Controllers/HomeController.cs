using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Models;
using ProjectManagement.Models.Core;
using System.Diagnostics;

namespace ProjectManagement.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProjectContext _context;
        public HomeController( ProjectContext context)
        {
   
            _context = context;
        }

        public IActionResult Index()
        {
            var projects = _context.Projects.ToList();

            return View(projects);
        }

        public IActionResult ProjectDetails(int ID)
        {

            var project = _context.Projects.Find(ID);

            if (project == null)
            {

                RedirectToAction("Error");


            }
            else
            {
                return View(project);

            }



            return View();

           

        }



        public IActionResult AddProject()
        {

           ViewBag. ProjectTypes=_context.ProjectTypes.ToList();

            return View();

        }


        [HttpPost]
        public IActionResult AddProject(Project model)
        {

            if (ModelState.IsValid)
            {

                var newProject = new Project
                {
                    Name=model.Name,
                     Cost=model.Cost,
                      DeadLine=model.DeadLine,
                       AnalysisPhaseFinish=model.AnalysisPhaseFinish,
                        AnalysisPhaseStart=model.AnalysisPhaseStart,
                        BackendDevelopmentPhaseFinish=model.BackendDevelopmentPhaseFinish,
                        BackendDevelopmentPhaseStart=model.BackendDevelopmentPhaseStart,
                         EstimationPhaseFinish=model.EstimationPhaseFinish,
                         EstimationPhaseStart=model.EstimationPhaseStart,
                          FronendDevelopmentPhaseFinish=model.FronendDevelopmentPhaseFinish,
                          FronendDevelopmentPhaseStart=model.FronendDevelopmentPhaseStart,
                           ReleasePhaseFinish=model.ReleasePhaseFinish,
                           ReleasePhaseStart=model.ReleasePhaseStart,
                            TestingPhaseFinish=model.TestingPhaseFinish,
                            TestingPhaseStart=model.TestingPhaseStart,
                             UATPhaseFinish=model.UATPhaseFinish,
                               UATPhaseStart=model.UATPhaseStart,
                                ProjecttypeID=model.ProjecttypeID
                         
                       


                };

                _context.Add(newProject);

                try
                {

                    _context.SaveChanges();

                   return RedirectToAction("Index");


                }

                catch(Exception e)
                {
                    return RedirectToAction("Error", e.Message);

                }
               


            }


            ViewBag.ProjectTypes = _context.ProjectTypes.ToList();

            return View(model);

        }



        [Authorize(Roles="CEO,PM")]
        public IActionResult EditProject(int id)
        {

            var project = _context.Projects.Find(id);
            ViewBag.ProjectTypes = _context.ProjectTypes.ToList();

            if (project == null)
            {

                RedirectToAction("Error");


            }

            else
            {

                return View(project);


            }

            return View();


        }


        [HttpPost]
        public IActionResult EditProject(Project model)
        {

            if (ModelState.IsValid)
            {

                var project = _context.Projects.Find(model.ID);

                project.Name = model.Name;
                project.Cost = model.Cost;
                project.DeadLine = model.DeadLine;
                project.AnalysisPhaseFinish = model.AnalysisPhaseFinish;
                project.AnalysisPhaseStart = model.AnalysisPhaseStart;
                project.BackendDevelopmentPhaseFinish = model.BackendDevelopmentPhaseFinish;
                project.BackendDevelopmentPhaseStart = model.BackendDevelopmentPhaseStart;
                project.EstimationPhaseFinish = model.EstimationPhaseFinish;
                project.EstimationPhaseStart = model.EstimationPhaseStart;
                project.FronendDevelopmentPhaseFinish = model.FronendDevelopmentPhaseFinish;
                project.FronendDevelopmentPhaseStart = model.FronendDevelopmentPhaseStart;
                project.ReleasePhaseFinish = model.ReleasePhaseFinish;
                project.ReleasePhaseStart = model.ReleasePhaseStart;
                project.TestingPhaseFinish = model.TestingPhaseFinish;
                project.TestingPhaseStart = model.TestingPhaseStart;
                project.UATPhaseFinish = model.UATPhaseFinish;
                project.UATPhaseStart = model.UATPhaseStart;
                project.ProjecttypeID = model.ProjecttypeID;


                try
                {

                    _context.SaveChanges();

                    return RedirectToAction("Index");


                }

                catch (Exception e)
                {
                    return RedirectToAction("Error", e.Message);

                }


            }

            ViewBag.ProjectTypes = _context.ProjectTypes.ToList();

            return View(model);

        }


        [Authorize(Roles = "CEO,PM")]
        public IActionResult DeleteProject(int ID)
        {

            var project = _context.Projects.Find(ID);

            if (project == null)
               {

                RedirectToAction("Error");


               }
            else
            {
                _context.Remove(project);

                try
                {

                    _context.SaveChanges();

                    return RedirectToAction("Index");


                }

                catch (Exception e)
                {
                    return RedirectToAction("Error", e.Message);

                }

            }





            return View();

        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}