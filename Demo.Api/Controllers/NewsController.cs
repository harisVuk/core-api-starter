using Demo.Api.Utils;
using Demo.Core.IRepository;
using Demo.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Demo.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/[controller]")]
    public class NewsController : ControllerBase
    {
        private INewsRepository _newsRepository;
        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult Index()
        {
            IEnumerable<News> news = _newsRepository.GetAll();

            return Ok(news);
        }
    }
}
