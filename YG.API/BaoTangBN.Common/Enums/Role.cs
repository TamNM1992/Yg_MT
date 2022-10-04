using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YG.Common.Enums
{
    public enum Role : int
    {
        Boss = 0,
        S = 1,
        A = 2,
        B = 3
    }
    public class ActiveResponse
    {
        public string value { get; set; }
        public string status { get; set; }
        public ActiveResponse(string value, string status)
        {
            this.value = value;
            this.status = status;
        }
    }
}
