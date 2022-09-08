using Swashbuckle.AspNetCore.Filters;

namespace WebAPI.Swagger.Examples.Operation
{
    public class SwaggerExampleOperation : IExamplesProvider<Models.Operation[]>
    {
        public Models.Operation[] GetExamples()
        {
            return new[]
            {
                new Models.Operation
                {
                    Op = "replace",
                    Path = "/valid",
                    Value = true
                }
            };
        }
    }
}
