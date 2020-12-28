using Reporter.Models.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reporter.Models.Models
{
    public class Action : IAction
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public string Json { get; set; }
    }
}
