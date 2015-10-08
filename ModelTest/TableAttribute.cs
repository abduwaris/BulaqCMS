using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTest
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    sealed class TableAttribute : Attribute
    {
        public TableAttribute(string tableName)
            : base()
        {
            this.tableName = tableName;
        }
        private string tableName;

        public string TableName { get { return this.tableName; } }
    }

    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class ColumnAttribute : Attribute
    {
        public ColumnAttribute(string columnName)
        {
            this.columnName = columnName;
        }
        string columnName;

        public string ColumnName { get { return this.columnName; } }
    }
}
