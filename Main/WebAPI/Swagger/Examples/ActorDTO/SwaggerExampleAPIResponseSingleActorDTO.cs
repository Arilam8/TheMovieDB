using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using Utils.APIUtils.Models;

namespace WebAPI.Swagger.Examples.ActorDTO
{
    public class SwaggerExampleAPIResponseSingleActorDTO : IExamplesProvider<APIResponseSingle<DataTransferObject.ActorDTO>>
    {
        public APIResponseSingle<DataTransferObject.ActorDTO> GetExamples()
        {
            return new APIResponseSingle<DataTransferObject.ActorDTO>()
            {
                Succeeded = true,
                StatusCode = 200,
                Message = "",
                Data = new DataTransferObject.ActorDTO()
                {
                    NbMovies = 4,
                    Bio = "Sally Margaret Field (born November 6, 1946) is an American actress. She has received many awards and nominations, including two Academy Awards, three Primetime Emmy Awards, two Golden Globe Awards, a Screen Actors Guild Award, a Cannes Film Festival Award for Best Actress, and nominations for a Tony Award and for two British Academy Film Awards.\n\nField began her career on television, starring in the comedies Gidget (1965–1966), The Flying Nun (1967–1970), and The Girl with Something Extra (1973–1974). In 1967, she was also in the western The Way West. In 1976, she attracted critical acclaim for her performance in the television film Sybil, for which she received the Primetime Emmy Award for Outstanding Lead Actress in a Limited Series or Movie. Her film debut was as an extra in Moon Pilot (1962). Her film career escalated during the 1970s with starring roles in films including Stay Hungry (1976), Smokey and the Bandit (1977), Heroes (1977), The End (1978), and Hooper (1978). During the 1980s she won the Academy Award for Best Actress twice for Norma Rae (1979) and Places in the Heart (1984), and she appeared in Smokey and the Bandit II (1980), Absence of Malice (1981), Kiss Me Goodbye (1982), Murphy's Romance (1985), Steel Magnolias (1989), Soapdish (1991), Mrs. Doubtfire (1993), and Forrest Gump (1994).\n\nIn the 2000s, Field returned to television with a recurring role on the NBC medical drama ER, for which she won the Primetime Emmy Award for Outstanding Guest Actress in a Drama Series in 2001 and the following year made her stage debut with Edward Albee's The Goat, or Who Is Sylvia?. For her portrayal of Nora Walker in the ABC television family drama series Brothers & Sisters (2006-2011), Field won the Primetime Emmy Award for Outstanding Lead Actress in a Drama Series. She starred as Mary Todd Lincoln in Lincoln (2012), for which she was nominated for the Academy Award for Best Supporting Actress, and she portrayed Aunt May in The Amazing Spider-Man (2012) and its 2014 sequel, with the first being her highest-grossing release. In 2015, she portrayed the title character in Hello, My Name Is Doris, for which she was nominated for the Critics' Choice Movie Award for Best Actress in a Comedy. In 2017, she returned to the stage after an absence of 15 years with the revival of Tennessee Williams's The Glass Menagerie, for which was nominated for the Tony Award for Best Actress in a Play. In 2014, she was presented with a star on the Hollywood Walk of Fame and in 2019, she received the Kennedy Center Honor.",
                    Birthdate = new System.DateTime(1946, 11, 6),
                    Deathdate = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue,
                    Id = 35,
                    Surname = "Sally",
                    Name = "Field",
                    Image = "/36qWnokCU1VOdSyrmGbTxzGou44.jpg",
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
                        },
                        new DataTransferObject.RoleDTO()
                        {
                            Id = 11025,
                            Character = "Aunt May"
                        },
                        new DataTransferObject.RoleDTO()
                        {
                            Id = 11258,
                            Character = "Aunt May"
                        }
                    }
                }
            };
        }
    }
}
