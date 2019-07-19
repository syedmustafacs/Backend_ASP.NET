using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAPIFA.Models; 

namespace FACycle.Controllers
{
    public class ChartOfAccountController : ApiController
    {
        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            List<account_type> accList = new List<account_type>();
            using (financial_accountingEntities2 dc = new financial_accountingEntities2())
            {
                
                accList = dc.account_type.OrderBy(a => a.TypeName).ToList();
                
               
                HttpResponseMessage response;
                response = Request.CreateResponse(HttpStatusCode.OK, accList);
                return response;
            }
        }  

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            List<account_type> accList = new List<account_type>();
            using (financial_accountingEntities2 dc = new financial_accountingEntities2())
            {

               // accList = dc.account_type.OrderBy(a => a.TypeName).ToList();
                var specificAcc= dc.account_type.FirstOrDefault((p) => p.Id == id);

                HttpResponseMessage response;
                response = Request.CreateResponse(HttpStatusCode.OK, specificAcc);
                return response;
            }

        }

        // POST api/<controller>
        [HttpPost]
        public void Post(account_type a)
        {
            using (financial_accountingEntities2 dc = new financial_accountingEntities2())
            {

               dc.account_type.Add(new account_type { Id = a.Id, TypeName = a.TypeName });
               dc.SaveChanges();
            }
            
        }

        // PUT api/<controller>/5
        public void Put(int id, account_type a)
        {

            using (financial_accountingEntities2 dc = new financial_accountingEntities2()) 
            {
                
            }
        } 

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            using (financial_accountingEntities2 dc = new financial_accountingEntities2())
            {
                var s = dc.account_type.Find(id);
                dc.account_type.Remove(s);
                dc.SaveChanges();
            }
        }
    }
}