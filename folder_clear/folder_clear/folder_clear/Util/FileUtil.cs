using folder_clear.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace folder_clear.Util
{
    public class FileUtil
    {


        public static List<String> fileCount(String path)
        {
            List<String> files = new List<string>();
            files.AddRange(Directory.GetFiles(path));
            files.AddRange(Directory.GetDirectories(path));
            return files;
        }

        public bool delete(String path)
        {
            try
            {
                File.Delete(path);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        /**
         * 디렉토리 유무 확인
         */
        public static bool isDirectory(String path)
        {
            return Directory.Exists(path);
        }


        /**
         * 확장자 분리시킴
         */
        public static FileAnalysisResult analysisfileInfo(String path)
        {

            FileAnalysisResult result = new FileAnalysisResult();
            result.Path = path;

            try
            {

                FileEntity fileEntity = new FileEntity();
                fileEntity.주소 = result.Path;
                fileEntity.확장자 = Path.GetExtension(path);
                fileEntity.파일명 = Path.GetFileName(path);
                fileEntity.순수파일명 = Path.GetFileNameWithoutExtension(path);

                result.Data = fileEntity;
            }
            catch (Exception e)
            {
                result.Error = e.Message;
            }

            return result;
        }
    }
}
