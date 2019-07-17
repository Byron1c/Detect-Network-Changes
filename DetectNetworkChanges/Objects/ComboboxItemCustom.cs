using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectNetworkChanges.Objects
{
    internal class ComboboxItemCustom
    {
        internal string Text { get; set; }
        internal string Name { get; set; }
        internal object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }

        internal  ComboboxItemCustom(string vText, string vName, object vValue) 
        {
            Text = vText;
            Name = vName;
            Value = vValue;
        }

    }
}
