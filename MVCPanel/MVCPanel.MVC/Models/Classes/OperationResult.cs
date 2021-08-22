using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCPanel.MVC.Models.Enums;

namespace MVCPanel.MVC.Models.Classes
{
    public class OperationResult
    {
        public OperationResultType ResultType { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}