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
    [Route("[controller]")]
    [ApiController]
    public class ProdukterController : ControllerBase
    {
        private readonly ORM_MsSql ORM;

        public ProdukterController()
        {
           ORM = new ORM_MsSql();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produkt>> Get()
        {
            List<Produkt> produkter = new();

            try
            {
                produkter = ORM.GetProducts();

            }catch (Exception ex)

            {
                throw new ArgumentException(ex.Message);
            }

            if (produkter.Count < 1) return NotFound();

            return produkter;

        }



        [HttpGet("{id}")]
        public ActionResult<Produkt> Get(int id)
        {
            Produkt produkt;

            try
            {
                produkt = ORM.GetProduct(id);

            }
            catch (Exception ex)

            {
                throw new ArgumentException(ex.Message);
            }

            if (produkt == null) return NotFound();

            return produkt;

        }


        [HttpPost]
        public ActionResult<Produkt> Post([FromBody] Produkt produkt)
        {
            ORM.CreateProdukt(produkt);
            return produkt;
        }



        [HttpPut("{id}")]
        public ActionResult<Produkt> Put(int id, [FromBody] Produkt produkt)
        {
            produkt.SetId(id);
            ORM.EditProduct(produkt);
            return produkt;
        }



        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {           

            if(ORM.DeleteProduct(id) == true)
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
