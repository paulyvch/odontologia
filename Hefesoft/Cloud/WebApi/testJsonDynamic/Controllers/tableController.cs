﻿using Microsoft.Practices.Unity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace testJsonDynamic.Controllers
{
    public class tableController : ApiController
    {
        testJsonDynamic.storage.azureStorage _azure;   

        public tableController(testJsonDynamic.storage.azureStorage azure)  
        {            
            _azure = azure;
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public dynamic Get(string nombreTabla, string partitionKey)
        {            
            return _azure.getAllByPartitionKey(nombreTabla, partitionKey);            
        }

        public dynamic Get(string nombreTabla, string partitionKey, string rowkey)
        {
            return _azure.getASingle(nombreTabla, partitionKey, rowkey);
        }

        // POST api/<controller>
        public async Task<dynamic> Post()
        {
            string value = await Request.Content.ReadAsStringAsync();
            var entidad = System.Web.Helpers.Json.Decode(value);
            _azure.insert(entidad);
            return entidad;
            //return new HttpResponseMessage(HttpStatusCode.OK);
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