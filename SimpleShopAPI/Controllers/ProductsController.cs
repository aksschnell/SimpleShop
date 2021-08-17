using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleShodModels;
using SimpleShopModels;
using SimpleShopOrm;


namespace SimpleShopAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ORM_MsSql ORM;

        public ProductsController()
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
        



    }
}
