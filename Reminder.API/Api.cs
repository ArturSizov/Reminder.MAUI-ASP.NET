using Reminder.Contracts.DataAccessLayer.Interfaces;
using Reminder.Contracts.Models;

namespace Reminder.API
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/persons", GetPersons);
            app.MapGet("/persons/{id}", GetPerson);
            app.MapPost("/persons", InsertPerson);
            app.MapPut("/persons", UpdatePerson);
            app.MapDelete("/persons", DeletePerson);
        }
        private static async Task<IResult> GetPersons(IPersonData data)
        {
            try
            {
                return Results.Ok(await data.GetPersons());
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetPerson(int id, IPersonData data)
        {
            try
            {
                var result = await data.GetPerson(id);
                if (result == null) return Results.NotFound();
                return Results.Ok(result);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> DeletePerson(int id, IPersonData data)
        {
            try
            {
                await data.DeletePerson(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> InsertPerson(Person person, IPersonData data)
        {
            try
            {
                await data.InsertPerson(person);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> UpdatePerson(Person person, IPersonData data)
        {
            try
            {
                await data.UpdatePerson(person);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
    }
}
