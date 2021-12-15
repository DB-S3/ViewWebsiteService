using Common;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ViewWebsiteService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [DisableCors]
    public class SiteController : ControllerBase
    {
        [Route("ViewPage/{_siteName}/{_pageName}")]
        [HttpGet]
        public async Task<Page> GetPage(string _siteName, string _pageName) {
            return await new Logic.Page().GetPage(_siteName, _pageName);
        }


    }
}
