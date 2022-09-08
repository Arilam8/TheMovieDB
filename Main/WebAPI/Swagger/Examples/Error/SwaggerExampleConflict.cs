using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace WebAPI.Swagger.Examples.Error
{
    public class SwaggerExampleConflict : IExamplesProvider<ProblemDetails>
    {
        public ProblemDetails GetExamples()
        {
            ProblemDetails problemDetails = new ProblemDetails()
            {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.8",
                Title = "Conflict",
                Status = StatusCodes.Status409Conflict,

            };
            problemDetails.Extensions["traceId"] = "00-40c979533bfdf945bb168b518371cf32-28d186d2194f7743-00";
            return problemDetails;
        }
    }
}
