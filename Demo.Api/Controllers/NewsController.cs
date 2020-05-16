using Demo.Core.IRepository;
using Demo.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Demo.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/[controller]")]
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
