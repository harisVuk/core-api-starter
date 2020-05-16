using Demo.Core.IRepository;
using Demo.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Demo.Api.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private INewsRepository newsRepository;
        public NewsController(INewsRepository _newsRepository)
        {
            newsRepository = _newsRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IEnumerable<News> news = newsRepository.GetAll();

            return Ok(news);
        }
    }
}
