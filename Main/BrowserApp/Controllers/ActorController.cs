using BrowserApp.Models;
using DataTransferObject;
using Microsoft.AspNetCore.Mvc;
using Utils.APIUtils;
using Utils.APIUtils.Models;

namespace BrowserApp.Controllers
{
    public class ActorController : Controller
    {
        private static int _idActor;
        private static APIResponseSingle<ActorDTO> _responseActor;
        private static APIResponseSingle<ActorDTO> _previousResponseActor;

        public ActorController() { }

        public IActionResult Index(int? idActor)
        {
            _idActor = idActor ?? 1;
            _responseActor = WebAPIManager.GetActorByIdActorAsync(_idActor).Result;
            return CheckResponseStatus();
        }

        private IActionResult CheckResponseStatus()
        {
            if (!_responseActor.Succeeded)
                return View("Error", new ErrorModel(_responseActor.StatusCode, _responseActor.Message));
            else
            {
                // Resolve the problem about the "Errors pages" so now we can show the correct previous page with the movies.
                _previousResponseActor = _responseActor;
                return View("Index", new ActorModel(_previousResponseActor.Data));
            }
        }
    }
}
