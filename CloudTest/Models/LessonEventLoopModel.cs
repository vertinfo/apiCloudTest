using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudTest.Models
{
    public class LessonEventLoopModel
    {
        public string UserId { get; set; }
        public string Lesson { get; set; }
        public string LessonEvent { get; set; }
        public string Device { get; set; }
        public JObject Feedback { get; set; }
    }
}
