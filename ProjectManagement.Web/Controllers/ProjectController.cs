using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Entities;
using ProjectManagement.Entities.Models;
using ProjectManagement.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Web.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        /// <summary>
        ///  Using this method Add or Edit Project
        /// </summary>
        /// <param name="id">if id is not null then Edit page open otherwise blank page open</param>
        public async Task<IActionResult> Create(int? id)
        {
            try
            {
                if (id != null)
                {
                    return View(await _projectService.GetProjectById(id.GetValueOrDefault()));
                }
                return View();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  This is post method which is used for store data into database.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(ResponseModel<ProjectModel> projectRequestModel)
        {
            try
            {
                _ = await _projectService.CreateProject(projectRequestModel.Result);
                return RedirectToAction("List");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  This method is used for GridView of a project list.
        /// </summary>
        public async Task<IActionResult> List()
        {
            try
            {
                return View(await _projectService.GetProjectList());
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        ///  Using this method Delete any project from list.
        /// </summary>
        /// <param name="id">using the id find the record from list and delete that record.</param>
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _ = await _projectService.DeleteProject(id);
                return RedirectToAction("List");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
