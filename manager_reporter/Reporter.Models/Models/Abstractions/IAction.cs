using System;
using System.Collections.Generic;
using System.Text;

namespace Reporter.Models.Models.Abstractions
{
    public interface IAction
    {
        string Name { get; set; }
        DateTime Time { get; set; }
        string Json { get; set; }
    }
}
