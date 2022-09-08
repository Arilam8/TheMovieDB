using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Filters;

namespace WebAPI.Swagger.Examples.Error
{
    public class SwaggerExampleNotFound : IExamplesProvider<ProblemDetails>
    {
        public ProblemDetails GetExamples()
        {
            ProblemDetails problemDetails = new ProblemDetails()
                                            {
                                                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                                                Title = "Not Found",
                                                Status = StatusCodes.Status404NotFound,

                                            };
            problemDetails.Extensions["traceId"] = "00-e19c7de93a0c78448261272fa697b1d7-28bb1d6429bf4f40-00";
            return problemDetails;
        }
    }
}
