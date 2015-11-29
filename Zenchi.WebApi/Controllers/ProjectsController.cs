using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Zenchi.Domain.Entities;
using Zenchi.Domain.ServiceInterfaces;

namespace Zenchi.WebApi.Controllers
{
    public class ProjectsController : BaseController
    {
        protected IProjectService ProjectService { get; set; }

        public ProjectsController(ILoggingService loggingService, IProjectService projectService) : base(loggingService)
        {
            if (projectService == null)
                throw new ArgumentNullException("IProjectService is null");

            ProjectService = projectService;
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            try
            {
                return Ok(ProjectService.GetAllProjectsForUser());
            }
            catch (Exception ex)
            {
                return InternalServerError(ex, "Error getting all projects for user.", "");
            }
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(string id)
        {
            try
            {
                return Ok(ProjectService.GetProject(id));
            }
            catch (KeyNotFoundException ke)
            {
                LoggingService.LogException(ke, "Project not found for Id:" + id);
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex, "Error getting Project for id:" + id, "");
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Project value)
        {
            try
            {
                return Ok(ProjectService.CreateProject(value));
            }
            catch (Exception ex)
            {
                string logid = LoggingService.LogException(ex, "Error Creating Project");
                return InternalServerError(ex, "Error Creating Project", "");
            }
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(string id, [FromBody]Project value)
        {
            try
            {
                return Ok(ProjectService.UpdateProject(value));
            }
            catch (KeyNotFoundException ke)
            {
                LoggingService.LogException(ke, "Project not found for Id:" + id);
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex, "Error Creating Project", "");
            }
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(string id)
        {
            try
            {
                ProjectService.DeleteProject(id);
                return Ok();
            }
            catch (KeyNotFoundException ke)
            {
                LoggingService.LogException(ke, "Project not found for Id:" + id);
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex, "Error Deleting Project", "");
            }
        }
    }
}