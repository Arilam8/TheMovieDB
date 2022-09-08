using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace WebAPI.Swagger.Examples.Error
{
    public class SwaggerExampleBadRequest : IExamplesProvider<ProblemDetails>
    {
        public ProblemDetails GetExamples()
        {
            ProblemDetails problemDetails = new ProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                Title = "Bad Request",
                Status = StatusCodes.Status400BadRequest,

            };
            problemDetails.Extensions["traceId"] = "00-79f920abf78bb94a9996185135eb281b-fac54f27db2b5246-00";
            return problemDetails;
        }
    }
}
