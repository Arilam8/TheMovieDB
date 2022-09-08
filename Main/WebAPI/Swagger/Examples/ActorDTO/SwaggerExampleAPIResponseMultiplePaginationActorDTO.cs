using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;
using Utils.APIUtils.Models;

namespace WebAPI.Swagger.Examples.ActorDTO
{
    public class SwaggerExampleAPIResponseMultiplePaginationActorDTO : IExamplesProvider<APIResponseMultiplePagination<DataTransferObject.ActorDTO>>
    {
        public APIResponseMultiplePagination<DataTransferObject.ActorDTO> GetExamples()
        {
            IList<DataTransferObject.ActorDTO> actorDTOs = new List<DataTransferObject.ActorDTO>();
            actorDTOs.Add(new DataTransferObject.ActorDTO()
            {
                NbMovies = 2,
                Id = 35,
                Surname = "Sally",
                Name = "Field",
                Roles = new List<DataTransferObject.RoleDTO>()
                {
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 637,
                        Character = "Miranda Hillard"
                    },
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 3942,
                        Character = "Mrs. Gump"
                    }
                }
            });
            actorDTOs.Add(new DataTransferObject.ActorDTO()
            {
                NbMovies = 2,
                Id = 169,
                Surname = "Hanns",
                Name = "Zischler",
                Roles = new List<DataTransferObject.RoleDTO>()
                {
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 2224,
                        Character = "Captain von Lerenau"
                    },
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 4953,
                        Character = "Kottke"
                    }
                }
            });
            actorDTOs.Add(new DataTransferObject.ActorDTO()
            {
                NbMovies = 2,
                Id = 176,
                Surname = "Kieran",
                Name = "O'Brien",
                Roles = new List<DataTransferObject.RoleDTO>()
                {
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 3595,
                        Character = "Hughie McGowan"
                    },
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 4397,
                        Character = "Lee Simpson"
                    }
                }
            });
            actorDTOs.Add(new DataTransferObject.ActorDTO()
            {
                NbMovies = 2,
                Id = 198,
                Surname = "Dan",
                Name = "Castellaneta",
                Roles = new List<DataTransferObject.RoleDTO>()
                {
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 621,
                        Character = "Genie (voice)"
                    },
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 4008,
                        Character = "Homer Simpson / Itchy / Barney / Abe Simpson / Stage Manager / Krusty the Clown / Mayor Quimby / Mayor's Aide / Multi-Eyed Squirrel / Panicky Man / Sideshow Mel / Mr. Teeny / EPA Official / Kissing Cop / Bear / Boy on Phone / NSA Worker / Officer / Santa's Little Helper / Squeaky-Voiced Teen (voice)"
                    }
                }
            });
            actorDTOs.Add(new DataTransferObject.ActorDTO()
            {
                NbMovies = 2,
                Id = 517,
                Surname = "Pierce",
                Name = "Brosnan",
                Roles = new List<DataTransferObject.RoleDTO>()
                {
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 641,
                        Character = "Stu"
                    },
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 4668,
                        Character = "Guy Shepherd"
                    }
                }
            });
            actorDTOs.Add(new DataTransferObject.ActorDTO()
            {
                NbMovies = 2,
                Id = 886,
                Surname = "William",
                Name = "Fichtner",
                Roles = new List<DataTransferObject.RoleDTO>()
                {
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 90,
                        Character = "Danny's Father"
                    },
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 3456,
                        Character = "Narrator"
                    }
                }
            });
            actorDTOs.Add(new DataTransferObject.ActorDTO()
            {
                NbMovies = 2,
                Id = 1333,
                Surname = "Andy",
                Name = "Serkis",
                Roles = new List<DataTransferObject.RoleDTO>()
                {
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 317,
                        Character = "Supreme Leader Snoke"
                    },
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 529,
                        Character = "Supreme Leader Snoke"
                    }
                }
            });
            actorDTOs.Add(new DataTransferObject.ActorDTO()
            {
                NbMovies = 2,
                Id = 1582,
                Surname = "James",
                Name = "Duval",
                Roles = new List<DataTransferObject.RoleDTO>()
                {
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 1486,
                        Character = "Baz"
                    },
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 1857,
                        Character = "Stewart Miles"
                    }
                }
            });
            actorDTOs.Add(new DataTransferObject.ActorDTO()
            {
                NbMovies = 2,
                Id = 1776,
                Surname = "Francis",
                Name = "Ford Coppola",
                Roles = new List<DataTransferObject.RoleDTO>()
                {
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 2566,
                        Character = "Himself"
                    },
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 4093,
                        Character = "Director of TV Crew (uncredited)"
                    }
                }
            });
            actorDTOs.Add(new DataTransferObject.ActorDTO()
            {
                NbMovies = 2,
                Id = 1937,
                Surname = "Mickey",
                Name = "Rooney",
                Roles = new List<DataTransferObject.RoleDTO>()
                {
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 2155,
                        Character = "Jimmy Connors"
                    },
                    new DataTransferObject.RoleDTO()
                    {
                        Id = 4814,
                        Character = "Mickey McGuire (as Mickey McGuire)"
                    }
                }
            });
            return new APIResponseMultiplePagination<DataTransferObject.ActorDTO>()
            {
                Succeeded = true,
                StatusCode = 200,
                Message = "",
                Datas = actorDTOs,
                PageNumber = 1,
                PageSize = actorDTOs.Count,
                TotalPages = 19,
                FirstPage = null,
                LastPage = "https://127.0.0.1:5001/v1/Actors/FavoriteActors/pageNumber=19&pageCount=10",
                NextPage = "https://127.0.0.1:5001/v1/Actors/FavoriteActors/pageNumber=2&pageCount=10",
                PreviousPage = null,
                TotalRecords = 185
            };
        }
    }
}
