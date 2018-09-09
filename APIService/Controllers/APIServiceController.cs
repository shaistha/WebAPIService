using System;
using System.Web.Http;
using APIService.DataAccessRepository;

namespace APIService.Controllers
{
    public class APIServiceController : ApiController
    {
        private IDataAccessRepository _repository;
        //Dependency injection uisng Constructor injection
        public APIServiceController(IDataAccessRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public string ReadJsonFromFile(string value)
        {
            return _repository.LoadJsonFromFile(value.Trim(new Char[] { '/'}));
        }
    }
}