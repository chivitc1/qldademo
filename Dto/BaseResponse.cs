using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public enum CodeType
    {
        Created = 1,
        Updated = 2,
        Deleted = 3,
        Found = 4,
        Failed = 5
    }
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public CodeType Code { get; set; }
    }
}
