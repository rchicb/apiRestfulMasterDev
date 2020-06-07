using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using apiResfulMasterDev.Models;
using apiResfulMasterDev.Models.WS;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiResfulMasterDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CredentialController : BaseController
    {


        [HttpGet]
        public IActionResult getCredential()
        {
            Response oReply = new Response();
            oReply.Result = 0;


            using (masterDevContext db = new masterDevContext())
            {
                var query = db.Credential.ToList();
                oReply.Data = query;

            }


            return Ok(oReply);
        }

        [EnableCors("MiCors")]
        [HttpPut]
        public IActionResult add(CredentialViewModel model)
        {

            Response oReply = new Response();
            oReply.Result = 0;
            string convertString = this.HMACSHA256(model.UserKey);
            try { 
            if (!verificarToken(model.UserKey))
            {
                using (masterDevContext db = new masterDevContext())
                {
                    Credential oModel = new Credential();
                    oModel.Userkey = model.UserKey;
                    oModel.Sharedsecret = convertString;

                    db.Credential.Add(oModel);
                    db.SaveChanges();
                        oReply.Result = 204;
                        oReply.Data = convertString;
                    }
              
            }

            else
            {
                oReply.Result = 403;
                    oReply.Data = convertString;
                }
        }catch(Exception s){

                Console.WriteLine(s.Message);
        }

            return Ok(oReply);
        }


        
    }
}