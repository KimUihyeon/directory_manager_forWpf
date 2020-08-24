using folder_clear.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        private List<FileAnalysisResult> _searchDatas;


        public FileSearchControl()
        {
            InitializeComponent();
            this._fileService = new FileService();
        }

        #region 해더
        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            var reulst = dlg.ShowDialog();
            if (reulst == DialogResult.OK)
            {
                this._searchDatas = _fileService.directoryFullScanAsync(dlg.SelectedPath);

                this.cb_extension.Items.Clear();
                this.cb_extension.Items.Add("전체");

                _fileService.directoryFullScanAsync(dlg.SelectedPath).ForEach(x => {
                    if (!this.cb_extension.Items.Contains(x.Data.확장자))
                        this.cb_extension.Items.Add(x.Data.확장자);
                });
            }
            this.cb_extension.SelectedIndex = 0;
        }

        private void btn_list_delete_Click(object sender, RoutedEventArgs e)
        {
            var datas = this.dg_files.SelectedItems;
            ObservableCollection<FileAnalysisResult> bindingCollectionTemp = new ObservableCollection<FileAnalysisResult>();

            if (datas.Count == 0)
            return;

            for (int i = 0; i < datas.Count; i++)
                bindingCollectionTemp.Add((FileAnalysisResult)datas[i]);

            foreach(var selectedData in bindingCollectionTemp)
            {
                (this.dg_files.ItemsSource as List<FileAnalysisResult>).Remove(selectedData);
                this._searchDatas.Remove(selectedData);
                bool isDeleted = this._fileService.delete(selectedData.Path);
                this.cb_extension_SelectionChanged(null, null);
            }
        }
        private void cb_extension_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string filter = (this.cb_extension.SelectedValue as String); 

            if (filter == "전체")
                this.dg_files.ItemsSource = this._searchDatas;
            else
                this.dg_files.ItemsSource = this._searchDatas
                    .Where(t => t.Data != null && t.Data.확장자 == filter).ToList();

        }

        #endregion

        private void btn_open_file_Click(object sender, RoutedEventArgs e)
        {
            FileAnalysisResult selectedObject = ((sender as System.Windows.Controls.Button).DataContext as FileAnalysisResult);
            Process.Start(selectedObject.Path);
        }

        private void btn_open_explore_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
