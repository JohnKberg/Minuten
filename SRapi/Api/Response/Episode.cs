using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;

namespace SRapi.Response
{

    public class Episode
    {

        public int Id { get; set; }

        
        public string Title { get; set; }

        
        public string Description { get; set; }

        
        public string Url { get; set; }

        
        public DateTime Publishdateutc { get; set; }

        
        public string Imageurl { get; set; }

        
        public string Imageurltemplate { get; set; }
    }

}

