using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiResfulMasterDev.Models;
using apiResfulMasterDev.Models.WS;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiResfulMasterDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : BaseController
    {
        [EnableCors("MiCors")]
        [HttpGet("{Id}")]
        public IActionResult searchId(int Id)
        {
            Response oReply = new Response();
            oReply.Result = 0;


            string token = Request.Headers["X-Signature"];

            if (verifyXSignature(token))
            {
                
            try { 
            using (masterDevContext db = new masterDevContext())
            {
                var query = db.Message.Find(Id);
                oReply.Data = query;
                oReply.Result = 200;
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            }
            else
            {
                oReply.Message = "Please authenticate before realize the query";
            }

            return Ok(oReply);
        }
        [EnableCors("MiCors")]
        [HttpGet]
        public IActionResult searchTag([FromQuery]string Tag)
        {
            Response oReply = new Response();
            oReply.Result = 0;

            string token = Request.Headers["X-Signature"];

            if (verifyXSignature(token))
            {

                try { 
            using (masterDevContext db = new masterDevContext())
            {
                var query = (from d in db.Message
                            where d.Tag.Contains(Tag)
                            select d).ToList();
                oReply.Data = query;
                oReply.Result = 200;

            }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
            else
            {
                oReply.Message = "Please authenticate before realize the query";
            }

            return Ok(oReply);
        }

        [EnableCors("MiCors")]
        [HttpPost]
        public IActionResult addMessage(MessageViewModel model)
        {
            Response oReply = new Response();
            oReply.Result = 0;

            string token = Request.Headers["X-Signature"];

            if (verifyXSignature(token))
            {
                try { 
            using (masterDevContext db = new masterDevContext())
            {
                Message oMessage = new Message();
                oMessage.Message1 = model.Message1;
                oMessage.Tag = model.Tag;
                db.Message.Add(oMessage);
                db.SaveChanges();
                oReply.Result = 200;

            }
            }
            catch (Exception ex) {

                Console.WriteLine(ex.Message);
            }

            }
            else
            {
                oReply.Message = "Please authenticate before realize the query";
            }

            return Ok(oReply);
        }

        public Boolean verifyXSignature(string token)
        {
            return verifyCodeXSignature(token);
                
        }

    }
}