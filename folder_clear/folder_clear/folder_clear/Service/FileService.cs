using folder_clear.Data;
using folder_clear.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace folder_clear
{
    public class FileService
    {

        private Searcher s;

        public void directoryFullScanAsync(String path, Action<List<FileAnalysisResult>> callback)
        {
            this.s = new Searcher();
            List<FileAnalysisResult> result = new List<FileAnalysisResult>();

            Thread t = new Thread(()=> {
                callback(s.directoryFullSearch(path));
            });
            t.Start();

            return;
        }

        public void fullScanStop()
        {
            if(s != null)
            {
                s.isStop();
            }
        }
    }
}
