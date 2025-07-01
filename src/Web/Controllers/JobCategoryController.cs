using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Domain.Entities;
using Application.JobCategories.Queries.GetJobCategories;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobCategoryController(IMediator mediator)
        {
            mediator = _mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<JobCategory>>> GetJobCategories()
        {
            var jobcategories = await _mediator.Send(new GetJobCategoriesQuery());
            return Ok(jobcategories);
        }
    }
}