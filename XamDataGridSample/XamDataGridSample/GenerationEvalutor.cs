using Infragistics.Windows.DataPresenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;

namespace XamDataGridSample
{
    public class GenerationEvalutor : IGroupByEvaluator
    {
        public IComparer SortComparer
        {
            get
            {
                return new Comparer();
            }
        }

        class Comparer : IComparer
        {
            public int Compare(object x, object y)
            {
                var ix = int.Parse(((Cell)x).Value as string);
                var iy = int.Parse(((Cell)y).Value as string);
                if (ix == iy) { return 0; }
                if (ix < iy) { return -1; }
                return 1;
            }
        }

        public bool DoesGroupContainRecord(GroupByRecord groupByRecord, DataRecord record)
        {
            return groupByRecord.Description == this.GroupByLabel(groupByRecord, record);
        }

        public object GetGroupByValue(GroupByRecord groupByRecord, DataRecord record)
        {
            groupByRecord.Description = this.GroupByLabel(groupByRecord, record);
            return int.Parse((string)record.GetCellValue(groupByRecord.GroupByField)) / 10;
        }

        private string GroupByLabel(GroupByRecord gr, DataRecord r)
        {
            var cellValue = int.Parse((string)r.GetCellValue(gr.GroupByField));
            return (cellValue / 10) + "0代";
        }
    }
}
