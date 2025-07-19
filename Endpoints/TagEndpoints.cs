using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoryPlannerApi.Entities;
namespace StoryPlannerApi.Endpoints;

public static class TagEndpoints
{
    public static void Map(WebApplication app)
    {
        app.MapGet("/tags", GetTags);

        app.MapGet("/tags/{id:int}", GetTagById)
            .WithName("GetTagById")
            .Produces<Tag>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);

        app.MapPost("/tags", CreateTag)
            .WithName("CreateTag")
            .Accepts<Tag>("application/json")
            .Produces<Tag>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest);

        app.MapPut("/tags/{id:int}", UpdateTag)
            .WithName("UpdateTag")
            .Accepts<Tag>("application/json")
            .Produces<Tag>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound);
    }

    public static async Task<ActionResult<List<Tag>>> GetTags(AppDbContext context)
    {
        var results = await context.Tags.ToListAsync();

        return results;
    }

    public static async Task<ActionResult<Tag>> GetTagById([FromRoute] int id, AppDbContext context)
    {
        var tag = await context.Tags.FindAsync(id);
        if (tag == null)
        {
            return new NotFoundResult();
        }
        return tag;
    }

    public static async Task<ActionResult<Tag>> CreateTag([FromBody] Tag tag, AppDbContext context)
    {
        context.Tags.Add(tag);
        await context.SaveChangesAsync();
        return new CreatedAtActionResult("GetTagById", "TagEndpoints", new { id = tag.Id }, tag);
    }

    public static async Task<ActionResult<Tag>> UpdateTag([FromRoute] int id, [FromBody] Tag tag, AppDbContext context)
    {
        if (id != tag.Id)
        {
            return new BadRequestResult();
        }
        context.Entry(tag).State = EntityState.Modified;
        await context.SaveChangesAsync();
        return new OkObjectResult(tag);
    }
}

public class TagCommand
{
    public string Name { get; set; } = string.Empty;
}