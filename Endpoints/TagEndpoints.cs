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
            .Produces<Tag>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);

        app.MapPut("/tags/{id:int}", UpdateTag)
            .WithName("UpdateTag")
            .Accepts<Tag>("application/json")
            .Produces<Tag>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest);
    }

    public static async Task<IResult> GetTags(AppDbContext context)
    {
        var results = await context.Tags.ToListAsync();

        return Results.Ok(results);
    }

    public static async Task<IResult> GetTagById([FromRoute] int id, AppDbContext context)
    {
        var tag = await context.Tags.FindAsync(id);
        if (tag == null)
        {
            return Results.NotFound(new { Message = $"Tag with ID {id} not found." });
        }
        return Results.Ok(tag);
    }

    public static async Task<IResult> CreateTag([FromBody] TagCommand tagCommand, AppDbContext context)
    {
        var tag = tagCommand.MapFrom();
        if (string.IsNullOrWhiteSpace(tag.Name))
        {
            return Results.BadRequest("Tag name cannot be empty.");
        }
        context.Tags.Add(tag);
        await context.SaveChangesAsync();
        return Results.Ok<Tag>(tag);
    }

    public static async Task<IResult> UpdateTag([FromRoute] int id, [FromBody] TagCommand tagCommand, AppDbContext context, CancellationToken cancellationToken)
    {
        var tag = await context.Tags.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        if (tag == null)
        {
            return Results.BadRequest(new { Message = $"Tag with ID {id} not found." });
        }
        tag.Name = tagCommand.Name;
        await context.SaveChangesAsync(cancellationToken);
        return Results.Ok(tag);
    }
}

public class TagCommand
{
    public string Name { get; set; } = string.Empty;
    public Tag MapFrom()
    {
        return new Tag
        {
            Name = Name
        };
    }
}