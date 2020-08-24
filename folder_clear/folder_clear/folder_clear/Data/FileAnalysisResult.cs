using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace folder_clear.Data
{
    public class FileAnalysisResult : ModelBase
    {
        private FileEntity _Data;
        private String _Error;

        private String _Path;


        public string Error { get => _Error; set { OnPropertyChanged(); _Error = value; } }
        public FileEntity Data { get => _Data; set { OnPropertyChanged(); _Data = value; } }

        public string Path { get => _Path; set { OnPropertyChanged(); _Path = value; } }
    }
}
