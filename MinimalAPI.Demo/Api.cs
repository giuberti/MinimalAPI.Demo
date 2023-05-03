using DataAccess.Data;
using DataAccess.Models;

namespace MinimalAPI.Demo;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
		app.MapGet("/users", GetUsers);
        app.MapGet("/users/{id}", GetUser);
        app.MapPost("/users", InsertUser);
        app.MapPut("/users", UpdateUser);
        app.MapDelete("/users/{id}", DeleteUser);
    }

    private static async Task<IResult> GetUsers(IUserData data)
    {
		try
		{
			return Results.Ok(await data.GetUsers());
		}
		catch (Exception ex)
		{
			return Results.Problem(ex.Message);
		}
    }

    private static async Task<IResult> GetUser(int id, IUserData data)
    {
        try
        {
            var result = await data.GetUser(id);
            return (result == null)? Results.NotFound(): Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertUser(UserModel user, IUserData data)
    {
        try
        {
            await data.InsertUser(user);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateUser(UserModel user, IUserData data)
    {
        try
        {
            await data.UpdateUser(user);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteUser(int id, IUserData data)
    {
        try
        {
            await data.DeleteUser(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
