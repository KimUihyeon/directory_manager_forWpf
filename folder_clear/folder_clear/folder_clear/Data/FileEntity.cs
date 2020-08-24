using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace folder_clear.Data
{
    public class FileEntity : ModelBase
    {

        private string _파일명;
        private string _순수파일명;
        private string _주소;
        private string _확장자;
        private string _용량;

        public string 파일명
        {
            get => _파일명; 

            set {
                OnPropertyChanged();
                _파일명 = value;
            }
        }
        public string 주소 { get => _주소;
            set
            {
                OnPropertyChanged();
                _주소 = value;
            } 
        }
        public string 확장자
        {
            get => _확장자;
            set
            {
                OnPropertyChanged();
                _확장자 = value;
            }
        }
        public string 용량
        {
            get => _용량;
            set
            {
                OnPropertyChanged();
                _용량 = value;
            }
        }

        public string 순수파일명
        {
            get => _순수파일명;
            set
            {
                OnPropertyChanged(); _순수파일명 = value;
            }
        }
    }
}
