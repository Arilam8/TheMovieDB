using DataTransferObject;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;
using Utils.APIUtils.Models;

namespace WebAPI.Swagger.Examples.LightActorDTO
{
    public class SwaggerExampleAPIResponseMultiplePaginationLightActorDTO : IExamplesProvider<APIResponseMultiplePagination<DataTransferObject.LightActorDTO>>
    {
        public APIResponseMultiplePagination<DataTransferObject.LightActorDTO> GetExamples()
        {
            IList<DataTransferObject.LightActorDTO> lightActorDTOs = new List<DataTransferObject.LightActorDTO>();
            lightActorDTOs.Add(new DataTransferObject.LightActorDTO()
            {
                Id = 2,
                Surname = "Mark",
                Name = "Hamill",
                Image = null,
                Roles = new List<DataTransferObject.RoleDTO>()
                {
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 207,
                        Character = "Luke Skywalker"
                    }
                }
            });
            lightActorDTOs.Add(new DataTransferObject.LightActorDTO()
            {
                Id = 3,
                Surname = "Harrison",
                Name = "Ford",
                Image = "/ActhM39LTxgx3tnJv3s5nM6hGD1.jpg",
                Roles = new List<DataTransferObject.RoleDTO>()
                {
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 200,
                        Character = "Han Solo"
                    }
                }
            });
            lightActorDTOs.Add(new DataTransferObject.LightActorDTO()
            {
                Id = 4,
                Surname = "Carrie",
                Name = "Fisher",
                Image = "/veakLIqGCbG0ek3YKfrlzcF72CG.jpg",
                Roles = new List<DataTransferObject.RoleDTO>()
                {
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 208,
                        Character = "Princess Leia Organa"
                    }
                }
            });
            lightActorDTOs.Add(new DataTransferObject.LightActorDTO()
            {
                Id = 5,
                Surname = "Peter",
                Name = "Cushing",
                Image = "/rxfWFGJm35qJb2jy0jlauhYeNgV.jpg",
                Roles = new List<DataTransferObject.RoleDTO>()
                {
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 204,
                        Character = "Grand Moff Tarkin"
                    }
                }
            });
            lightActorDTOs.Add(new DataTransferObject.LightActorDTO()
            {
                Id = 6,
                Surname = "Anthony",
                Name = "Daniels",
                Image = "/7kR4kwXtvXtvrsxWeX3QLX5NS5V.jpg",
                Roles = new List<DataTransferObject.RoleDTO>()
                {
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 232,
                        Character = "C-3PO"
                    }
                }
            });
            lightActorDTOs.Add(new DataTransferObject.LightActorDTO()
            {
                Id = 130,
                Surname = "Kenny",
                Name = "Baker",
                Image = "/uo3RorCoGDWHecLtqjviwzFExxR.jpg",
                Roles = new List<DataTransferObject.RoleDTO>()
                {
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 229,
                        Character = "R2-D2"
                    }
                }
            });
            lightActorDTOs.Add(new DataTransferObject.LightActorDTO()
            {
                Id = 663,
                Surname = "William",
                Name = "Hootkins",
                Image = "/dav2i86GN0UvYIyoTwQmGE8Nweg.jpg",
                Roles = new List<DataTransferObject.RoleDTO>()
                {
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 216,
                        Character = "Red Six (Porkins)"
                    }
                }
            });
            lightActorDTOs.Add(new DataTransferObject.LightActorDTO()
            {
                Id = 3044,
                Surname = "Scott",
                Name = "Beach",
                Image = "/5Y3SbZeqOcw2w5KUUwnUjGoir6b.jpg",
                Roles = new List<DataTransferObject.RoleDTO>()
                {
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 231,
                        Character = "Stormtrooper (voice) (uncredited)"
                    }
                }
            });
            lightActorDTOs.Add(new DataTransferObject.LightActorDTO()
            {
                Id = 4945,
                Surname = "Joe",
                Name = "Johnston",
                Image = "/fbGZo6CG9Z9zKFh8D5wHunyu7gJ.jpg",
                Roles = new List<DataTransferObject.RoleDTO>()
                {
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 244,
                        Character = "Death Star Trooper (uncredited)"
                    }
                }
            });
            lightActorDTOs.Add(new DataTransferObject.LightActorDTO()
            {
                Id = 7727,
                Surname = "Phil",
                Name = "Tippett",
                Image = "/qIjrlRrM6MwNkbCYwRbPYbvq9P7.jpg",
                Roles = new List<DataTransferObject.RoleDTO>()
                {
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 237,
                        Character = "Cantina Alien (uncredited)"
                    }
                }
            });
            return new APIResponseMultiplePagination<DataTransferObject.LightActorDTO>()
            {
                Succeeded = true,
                StatusCode = 200,
                Message = "",
                Datas = lightActorDTOs,
                PageNumber = 1,
                PageSize = lightActorDTOs.Count,
                TotalPages = 11,
                FirstPage = null,
                LastPage = "https://127.0.0.1:5001/v1/Actors/11&pageNumber=11&pageCount=10",
                NextPage = "https://127.0.0.1:5001/v1/Actors/11&pageNumber=2&pageCount=10",
                PreviousPage = null,
                TotalRecords = 105
            };
        }
    }
}
