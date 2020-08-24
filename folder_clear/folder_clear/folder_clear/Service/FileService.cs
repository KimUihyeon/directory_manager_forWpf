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

        public List<FileAnalysisResult> directoryFullScanAsync(String path)
        {
            this.s = new Searcher();
            return Task.Factory.StartNew(() => {
                List<FileAnalysisResult> results = s.directoryFullSearch(path);

                int key = 0;

                foreach (var result in results)
                {
                    if (result.Error != null)
                    {
                        result.Key = key;
                        key++;
                    }

                }
                //Some work...
                return results;
            }).Result;
        }

        public void fullScanStop()
        {
            if(s != null)
            {
                s.isStop();
            }
        }

        internal bool delete(string path)
        {
            return FileUtil.delete(path);
        }
    }
}
