using Reporter.Models.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reporter.Services.Services.Abstractions
{
    public interface IManagerService
    {
        void AddActionInReportList(IAction action);
        IAction SearchForAction(string actionName);
    }
}
