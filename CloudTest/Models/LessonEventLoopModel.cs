using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudTest.Models
{
    public class LessonEventLoopModel
    {
        public string uId { get; set; }
        public string lesson { get; set; }
        public string lessonEvent { get; set; }
        public string devicename { get; set; }
        public JObject feedback { get; set; }
    }
}
