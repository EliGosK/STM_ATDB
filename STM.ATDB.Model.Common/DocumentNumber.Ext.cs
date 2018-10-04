using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STM.ATDB.Model.Common
{
    public partial class DocumentNumber
    {
        public string DocumentKey { get; set; }
        public string DocumentSystem { get; set; }
        public int BatchRunning { get; set; }
        public int RunningDigit { get; set; }
        public List<string> RunningResults { get; set; }
        public string FirstRunningResult
        {
            get
            {
                if (RunningResults != null)
                {
                    return RunningResults[0];
                }
                else
                {
                    return null;
                }
            }
        }

        
        public List<string> FullRunningResults
        {
            get
            {
                return RunningResults.Select(d=> string.Concat(DocumentKey, d)).ToList();
            }
        }

        public string FullFirstRunningResult
        {
            get
            {
                if (RunningResults != null)
                {
                    return string.Concat(DocumentKey, RunningResults[0]);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
