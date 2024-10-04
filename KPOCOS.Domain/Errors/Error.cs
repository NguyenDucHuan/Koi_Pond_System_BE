using System.Collections.Generic;
using Newtonsoft.Json;

namespace KPOCOS.Domain.Errors
{
    public class Error
    {
        public int StatusCode { get; set; }
        public List<ErrorDetail> Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}