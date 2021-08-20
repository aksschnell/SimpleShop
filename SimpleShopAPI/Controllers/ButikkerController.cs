using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleShodModels;
using SimpleShopModels;
using SimpleShopOrm;
using System.Net.Http;

namespace SimpleShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ButikkerController : ControllerBase
    {
        

        private readonly ORM_MsSql ORM;

        public ButikkerController()
        {
            ORM = new ORM_MsSql();
        }

        [HttpGet("{id}")]
        public ActionResult<Butik> Get(int id)
        {
            Butik kunde;

            try
            {
                kunde = ORM.GetButik(id);

            }
            catch (Exception ex)

            {
                throw new ArgumentException(ex.Message);
            }

            if (kunde == null) return NotFound();

            return ORM.GetButik(id);

        }




        [HttpGet]
        public ActionResult<IEnumerable<Butik>> Get()
        {
            List<Butik> butikker = new();

            try
            {
                butikker = ORM.GetButikker();

            }
            catch (Exception ex)

            {
                throw new ArgumentException(ex.Message);
            }

            if (butikker.Count < 1) return NotFound();

            return butikker;

        }

    }
}
