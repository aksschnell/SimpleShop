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
    public class StatusesController : ControllerBase
    {

        private readonly ORM_MsSql ORM;

        public StatusesController()
        {
            ORM = new ORM_MsSql();
        }


        [HttpGet("{id}")]
        public ActionResult<OrdreStatus> Get(int id)
        {
            OrdreStatus ordreStatus;

            try
            {
                ordreStatus = ORM.GetStatus(id);

            }
            catch (Exception ex)

            {
                throw new ArgumentException(ex.Message);
            }

            if (ordreStatus == null) return NotFound();

            return ordreStatus;

        }



        [HttpGet]
        public ActionResult<IEnumerable<OrdreStatus>> Get()
        {
            List<OrdreStatus> statuser = new();

            try
            {
                statuser = ORM.GetStatuses();

            }
            catch (Exception ex)

            {
                throw new ArgumentException(ex.Message);
            }

            if (statuser.Count < 1) return NotFound();

            return statuser;

        }



        [HttpPost]
        public ActionResult<OrdreStatus> Post([FromBody] OrdreStatus status)
        {
            ORM.CreateStatus(status);
            return status;
        }



        [HttpPut("{id}")]
        public ActionResult<OrdreStatus> Put(int id, [FromBody] OrdreStatus status)
        {
            status.SetId(id);
            ORM.EditStatus(status);
            return status;
        }



        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            if (ORM.DeleteStatus(id) == true)
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
