using folder_clear.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace folder_clear.Control
{
    /// <summary>
    /// FileSearchControl.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FileSearchControl : System.Windows.Controls.UserControl
    {

        private FileService _fileService;

        public FileSearchControl()
        {
            InitializeComponent();
            this._fileService = new FileService();
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            var reulst = dlg.ShowDialog();
            if (reulst == DialogResult.OK)
            {
                String path = dlg.SelectedPath;

                _fileService.directoryFullScanAsync(path, (List<FileAnalysisResult> results)=>
                {
                    foreach (var result in results)
                    {

                    }
                });
            }
        }
    }
}
