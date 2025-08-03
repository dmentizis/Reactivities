using Application.Activities.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers;

// Using primary constructor for Dependency Injection
public class ActivitiesController(IMediator mediator) : BaseApiController
{
    #region Old Depenency Injection Method
    // Old dependency injection method
    // private readonly AppDbContext context;

    // public ActivitiesController(AppDbContext context)
    // {
    //     this.context = context;
    // }
    #endregion

    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        return await mediator.Send(new GetActivityList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(string id)
    {
        #region Old Implementation
        //var activity = await context.Activities.FindAsync(id);

        // if (activity == null) return BadRequest(); // Error 400


        //if (activity == null) return NotFound(); // Error 404

        //return activity;
        #endregion

        return await mediator.Send(new GetActivityDetails.Query { Id = id });
    }
}
