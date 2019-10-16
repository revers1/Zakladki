﻿using System;
using System.Collections.Generic;
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


        [HttpPost("addProduct")]
        public ContentResult AddProduct([FromBody]ProductViewModel model)
        {
            try
            {
                Product product = new Product()
                {
                    Name = model.Name,
                    Price = model.Price,                 
                     Quantity = model.Quantity,
                     Description = model.Description
                     
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