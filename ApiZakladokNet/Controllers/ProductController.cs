using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApiZakladokNet.Entity;
using ApiZakladokNet.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace ApiZakladokNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly EFContext context;
        private readonly IHostingEnvironment appEnvironment;
        public ProductController(EFContext ccontext, IHostingEnvironment appenv)
        {
            context = ccontext;
            appEnvironment = appenv;
        }


        [HttpGet("getProduct")]
        public ContentResult GetProducts()
        {
            List<Product> product = context.Dbproduct.ToList();
            string json = JsonConvert.SerializeObject(product);
            return Content(json, "application/json");
        }
        [HttpGet("getImage/{id}")]
        public ContentResult GetImage(int id)
        {
            var path = string.Empty;
            string filename = (context.Dbproduct.FirstOrDefault(t => t.Id == id)).Imagge;
            using (var file = new FileStream(appEnvironment.WebRootPath + @"/Content/" + filename, FileMode.Open, FileAccess.Read))
            {
                var photo = new byte[file.Length];
                file.Read(photo, 0, (int)file.Length);
                path = Convert.ToBase64String(photo);
            }
            string json = JsonConvert.SerializeObject(path);
            return Content(json, "application/json");
        }


        [HttpPost("addProduct")]
        public ContentResult AddProduct([FromBody]ProductViewModel model)
        {
            try
            {
                string path = string.Empty;
                if (model.Imagge != null)
                {
                    byte[] imagebyte = Convert.FromBase64String(model.Imagge);
                    using (MemoryStream stream = new MemoryStream(imagebyte, 0, imagebyte.Length))
                    {
                        path = Guid.NewGuid().ToString() + ".jpg";
                        Image productImage = Image.FromStream(stream);
                        productImage.Save(appEnvironment.WebRootPath + @"/Content/" + path, ImageFormat.Jpeg);
                    }
                }

                Product product = new Product()
                {
                    Name = model.Name,
                    Price = model.Price,                 
                     Quantity = model.Quantity,
                     Description = model.Description,
                     Imagge=path,
                     CoordX=model.CoordX,
                     CoordY=model.CoordY,
                     User_Id=model.User_Id
                     
                };
                context.Dbproduct.Add(product);
                context.SaveChanges();
                return Content("Product successfuly added");
            }
            catch (Exception ex)
            {
                return Content("Error " + ex.Message);
            }
        }
        [HttpGet("getProductOne/{id}")]
        public ContentResult GetProductsOne(int id)
        {
            var product = context.Dbproduct.Where(w=>w.User_Id==id);
            string json = JsonConvert.SerializeObject(product);
            return Content(json, "application/json");
        }
        [HttpGet("getProductClient/{id}")]
        public ContentResult GetProductClient(int id)
        {
            var product = context.Dbproduct.FirstOrDefault(w => w.Id == id);
            string json = JsonConvert.SerializeObject(product);
            return Content(json, "application/json");
        }

        [HttpDelete("deleteProduct/{id}")]
        public ContentResult DeleteProduct(int id)
        {
            try
            {
                var product = context.Dbproduct.FirstOrDefault(w => w.Id == id);
                context.Remove(product);
                context.SaveChanges();
                return Content("Product successfuly delted");
            }
            catch (Exception ex)
            {

                return Content("Error" + ex.Message);

            }
        }






    }
}