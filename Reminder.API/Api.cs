using Reminder.Contracts.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminder.API
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/persons", GetPersons);
            app.MapGet("/persons/{id}", GetPerson);
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
    }
}
