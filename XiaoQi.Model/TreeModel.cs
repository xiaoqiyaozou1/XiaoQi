using System;
using System.Collections.Generic;
using System.Text;

namespace XiaoQi.Model
{
   public class TreeModel
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string ParentId { get; set; }

        public List<TreeModel> Children = new List<TreeModel>();
    }
}
