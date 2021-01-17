using System;
using System.Collections.Generic;
using System.Text;

namespace XiaoQi.Model
{
    public class UserStepsDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public int? Userage { get; set; }
        public int? Sex { get; set; }
        public string StepId { get; set; }      
        public int? UserSteps1 { get; set; }
    }
}
