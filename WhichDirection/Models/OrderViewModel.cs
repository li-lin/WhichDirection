using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WhichDirection.Models
{
    public class OrderViewModel
    {
        public string OrderJson { get; set; }
        public Dictionary<int, int> Convert
        {
            get
            {
                if (string.IsNullOrWhiteSpace(OrderJson))
                {
                    return new Dictionary<int, int>();
                }
                try
                {
                    var obj = JToken.Parse(OrderJson);
                }
                catch (Exception)
                {
                    throw new FormatException("不符合json格式.");
                }
                return JsonConvert.DeserializeObject<Dictionary<int, int>>(OrderJson);
            }
        }
    }
}