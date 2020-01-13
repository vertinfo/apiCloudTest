using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudTest.DbClients;
using CloudTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CloudTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        // GET: api/Feedback
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Feedback/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Feedback
        [HttpPost]
        public async Task Post()
        {
            var request = Request.Body;
            try
            {
                using (var streamReader = new HttpRequestStreamReader(request, Encoding.UTF8))
                using (var jsonReader = new JsonTextReader(streamReader))
                {
                    var json = await JObject.LoadAsync(jsonReader);
                    json.ToObject<LessonEventLoopModel>();
                    Trace.TraceInformation($"Posting- {json}");
                    LessonEventLoopModel model = json.ToObject<LessonEventLoopModel>();
                    PgDb db = new PgDb();
                    db.insertFeedback(model);
                }
            }
            catch (Exception e)
            {
                Trace.TraceInformation($"exception in feedback post: {e.Message}");   
            }
           
        }

        // PUT: api/Feedback/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
