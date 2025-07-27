using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers;

// Using primary constructor for Dependency Injection
public class ActivitiesController(AppDbContext context) : BaseApiController
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
        return await context.Activities.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivityDetail(string id)
    {
        var activity = await context.Activities.FindAsync(id);

        // if (activity == null) return BadRequest(); // Error 400

        if (activity == null) return NotFound();
        
        return activity;
    }
}
