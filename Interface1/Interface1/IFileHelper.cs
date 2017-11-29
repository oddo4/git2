using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface1
{
    interface IFileHelper
    {
        List<string> LoadFromString(string input);
        string SaveToString(List<string> input);
    }
}
