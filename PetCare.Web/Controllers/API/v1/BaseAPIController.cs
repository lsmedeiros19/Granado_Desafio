using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PetCare.Web.Controllers.API.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseAPIController : ControllerBase
    {
    }
}
