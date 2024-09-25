using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using KPCOS.Api.Service.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace KPCOS.Api.Controllers
{
    [Route("api/v1/pond-manager")]
    [EnableCors("AllowAllOrigins")]
    [ApiController]
    public class PondController : Controller
    {
        private readonly IPondService _pondService;

        public PondController(IPondService pondService)
        {
            _pondService = pondService;
        }


    }
}