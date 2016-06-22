using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDataGridSampleApp.Commons
{
    public static class TaskExtensions
    {
        public static void InvokeAndForget(this Task self)
        {
        }

        public static void InvokeAndForget<T>(this Task self)
        {
        }
    }
}
