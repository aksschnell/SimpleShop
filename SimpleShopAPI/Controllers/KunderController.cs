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
    public class KunderController : ControllerBase
    {

        private readonly ORM_MsSql ORM;

        public KunderController()
        {
            ORM = new ORM_MsSql();
        }

        [HttpGet("{id}")]
        public ActionResult<Kunde> Get(int id)
        {
            Kunde kunde;

            try
            {
                kunde = ORM.GetCustomer(id);

            }
            catch (Exception ex)

            {
                throw new ArgumentException(ex.Message);
            }

            if (kunde == null) return NotFound();

            return  ORM.GetCustomer(id);

        }

        [HttpGet]
        public ActionResult<IEnumerable<Kunde>> Get()
        {
            List<Kunde> kunder = new();

            try
            {
                kunder = ORM.GetCustomers();

            }
            catch (Exception ex)

            {
                throw new ArgumentException(ex.Message);
            }

            if (kunder.Count < 1) return NotFound();

            return kunder;

        }


        [HttpPost]
        public ActionResult<Kunde> Post([FromBody] Kunde kunde)
        {
            ORM.CreateCustomer(kunde);
            return kunde;
        }



        [HttpPut("{id}")]
        public ActionResult<Kunde> Put(int id, [FromBody] Kunde kunde)
        {
            kunde.SetId(id);
            ORM.EditCustomer(kunde);
            return kunde;
        }



        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            if (ORM.DeleteCustomer(id) == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }


        

    }
}
