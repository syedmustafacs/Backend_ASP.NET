
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAPIFA.Models;

namespace FACycle.Controllers
{
    public class AccountsController : ApiController
    {
        // GET api/<controller>
        // financial_accountingEntities
        public HttpResponseMessage Get()
        {
            List<Account> accList = new List<Account>();
            using (financial_accountingEntities1 dc = new financial_accountingEntities1())
            {

                accList = dc.Accounts.OrderBy(a => a.Name).ToList();
                

                HttpResponseMessage response;
                response = Request.CreateResponse(HttpStatusCode.OK, accList);
                return response;
            }
        }  
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post(Account value)
        {
            using (financial_accountingEntities1 dc = new financial_accountingEntities1())
            {

                dc.Accounts.Add(new Account{Id=value.Id,Name=value.Name,Debit=value.Debit,Credit=value.Credit});//OrderBy(a => a.Name).ToList();
                dc.SaveChanges();

            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}