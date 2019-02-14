using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using proyectoPrueba.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace proyectoPrueba.Controllers
{
    [Route("api/[controller]")]
    public class CertificatesController : ControllerBase
    {

        private readonly AppDBContext _context;

        public CertificatesController (AppDBContext context)
        {
            this._context = context;

            //if (this._context.Certificates.Count() == 0)
            //{
            //    Certificates cert = new Certificates();

            //    X509Certificate2 x509 = new X509Certificate2("./SCD-colegiado-Ministerio.p12", "111111");
            //    /*Vigencia del CSD*/
            //    string notAfter = x509.GetExpirationDateString();  //Cambiarlo a DateTime
            //    cert.notAfer = notAfter;

            //    ///*No. de Serie del Certificado*/
            //    string serialNumber = BitConverter.ToString(x509.GetSerialNumber().Reverse().ToArray());  //Convertir el array de bytes a string
            //    cert.serialNumber = serialNumber;

            //    ///*Issuer*/
            //    string issuer = x509.Issuer;
            //    cert.issuer = issuer;

            //    ///*El certificado incluye la llave privada?*/
            //    //bool bExisteKey = oCSD.HasPrivateKey;
            //    //Console.WriteLine("Contiene llave privada? - " + bExisteKey.ToString());
            //    //Console.WriteLine();

            //    ///*Subject*/
            //    string subject = x509.Subject;
            //    cert.subject = subject;

            //    ///*Thubprint*/
            //    //string sThumprint = oCSD.Thumbprint;
            //    //Console.WriteLine("Thumbprint: " + sThumprint);
            //    //Console.WriteLine();

            //    ///*Certificado en base 64*/
            //    //string sCertRaw = Convert.ToBase64String(oCSD.Export(X509ContentType.Cert));
            //    //Console.WriteLine("Certificado: " + sCertRaw);
            //    //Console.WriteLine();


            //    this._context.Certificates.Add(cert);
            //    this._context.SaveChanges();
            //}
        }

        // GET api/users
        [HttpGet]
        public ActionResult<List<Certificates>> GetAll()
        {
            var certs = new List<Certificates>();
            certs = this._context.Certificates.ToList();
            foreach (Certificates cert in certs)
            {
                if(cert != null)
                {
                    X509Certificate2 x509 = new X509Certificate2(System.Convert.FromBase64String(cert.file64), "111111");
                    /*Vigencia del CSD*/
                    string notAfter = x509.GetExpirationDateString();  //Cambiarlo a DateTime
                    cert.notAfer = notAfter;

                    ///*No. de Serie del Certificado*/
                    string serialNumber = BitConverter.ToString(x509.GetSerialNumber().Reverse().ToArray());  //Convertir el array de bytes a string
                    cert.serialNumber = serialNumber;

                    ///*Issuer*/
                    string issuer = x509.Issuer;
                    cert.issuer = issuer;

                    ///*Subject*/
                    string subject = x509.Subject;
                    cert.subject = subject;

                    //this._context.Certificates.Add(cert);
                    //this._context.SaveChanges();
                }
            }
            return certs;
            //return this._context.Certificates.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Certificates> Post([FromBody]Certificates value)
        {
            this._context.Certificates.Add(value);
            this._context.SaveChanges();
            return Ok(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
