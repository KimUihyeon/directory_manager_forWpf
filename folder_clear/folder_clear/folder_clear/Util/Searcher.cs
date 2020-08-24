using folder_clear.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace folder_clear.Util
{
    public class Searcher
    {

        private bool isStart;

        public void isStop()
        {
            this.isStart = false;
        }

        public List<FileAnalysisResult> directoryFullSearch(String path)
        {
            List<FileAnalysisResult> result = new List<FileAnalysisResult>();
            this.isStart = true;

            String[] files = FileUtil.fileCount(path).ToArray();
            foreach( string file in files ){


                if (FileUtil.isDirectory(file)) // 디렉토리
                {
                    try
                    {
                        if (!file.Contains("RECYCLE"))
                            result.AddRange(directoryFullSearch(file));
                    }
                    catch (Exception e)
                    {

                    }
                }
                else // 파일
                {
                    result.Add(FileUtil.analysisfileInfo(file));
                }
            }
            return result;
        }
    }
}
