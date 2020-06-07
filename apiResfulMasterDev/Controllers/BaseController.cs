using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using apiResfulMasterDev.Models;
using System.Text;
using System.Security.Cryptography;

namespace apiResfulMasterDev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public bool verificarToken(string userKey)
        {
            String convertString = this.HMACSHA256(userKey);

            using (var db = new masterDevContext())
            {
                var existUser = from d in db.Credential
                                where d.Sharedsecret == convertString
                                select d;

                if (existUser.FirstOrDefault() != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }

        public bool verifyCodeXSignature(string convertString)
        {
            using (var db = new masterDevContext())
            {
                var existUser = from d in db.Credential
                                where d.Sharedsecret == convertString
                                select d;

                if (existUser.FirstOrDefault() != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public String HMACSHA256(String key)
        {
            string key_gen = "";

            var msgBytes =
                Encoding.ASCII.GetBytes(key);



            var sha = new SHA256Managed();
            var hash = sha.ComputeHash(msgBytes);

            Console.Write("Message hash: ");
            foreach (byte b in hash)
            {
                // write as hexadecimal
                Console.Write(b.ToString("x2"));
                key_gen += b.ToString();
            }
            return key_gen;
        }
    }
}