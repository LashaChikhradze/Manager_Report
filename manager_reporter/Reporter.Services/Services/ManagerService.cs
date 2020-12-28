using Reporter.Models.Models.Abstractions;
using Reporter.Services.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reporter.Services.Services
{
    public class ManagerService : IManagerService
    {
        private List<IAction> _allActions = new List<IAction>();

        public void AddActionInReportList(IAction action)
        {
            _allActions.Add(action);
        }
        public IAction SearchForAction(string actionName)
        {
            IAction tmp = null;
            foreach(var item in _allActions)
            {
                if(item.Name == actionName)
                {
                    tmp = item;
                }
            }
            return tmp;
        }
    }
}
