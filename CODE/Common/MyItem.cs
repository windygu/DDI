using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDI.Common
{
    public class MyItem
    {

        public string Name { get; private set; }
        public string Value { get; private set; }
        public MyItem(string name, string value)
        {
            Name = name;
            Value = value;
        }

    }
}
