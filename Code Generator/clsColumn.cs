using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Generator
{
    public class clsColumn
    {
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public bool IsNull { get; set; }
        public bool IsPrimaryKey { get; set; }

    }
}
