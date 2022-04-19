using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagement.Database;
using ProjectManagement.Entities;
using ProjectManagement.Entities.Models;
using ProjectManagement.Repository.Repositories;
using ProjectManagement.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectManagement.Test
{
    public class ProjectUnitTestController
    {
        private ProjectRepository _projectRepository;
        private ProjectService _projectService;
        public static DbContextOptions<ApplicationDbContext> dbContextOptions { get; set;}
        public static string connectionString = "Server=(localdb)\\mssqllocaldb;Database=aspnet-ProjectManagement-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;MultipleActiveResultSets=true";
       static ProjectUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public ProjectUnitTestController()
        {
            var context = new ApplicationDbContext(dbContextOptions);
            _projectRepository = new ProjectRepository(context);
            _projectService = new ProjectService(_projectRepository, null);
        }

        [Fact]
        public async void Task_GetProjectById_OkResult()
        {
            //Arrange
            var projectId = 10;

            //Act
            var data = await _projectService.GetProjectById(projectId);

            //Assert
            Assert.IsType<ResponseModel<ProjectModel>>(data);
        }

        [Fact]
        public async void Task_GetProjectById_BadResult()
        {
            //Arrange
            var projectId = 15;

            //Act
            var data = await _projectService.GetProjectById(projectId);

            //Assert
            Assert.IsType<ResponseModel<ProjectModel>>(data);
        }


        [Fact]
        public async void Task_GetProjectsList()
        {
            //Act
            var data = await _projectService.GetProjectList();

            //Assert
            Assert.IsType<ResponseModel<List<ProjectModel>>>(data);
        }
    }
}
