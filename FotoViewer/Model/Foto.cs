using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoViewer.Helpers;

namespace FotoViewer.Model
{
    public class Foto: ObservableObject
    {
        private string filename;

        public string Filename
        {
            get { return filename; }
            set {
                filename = value;
                OnPropertyChanged("Filename");
            }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }
        private string filepath;

        public string Filepath
        {
            get { return filepath; }
            set
            {
                filepath = value;
                OnPropertyChanged("Filepath");
            }
        }

        private int filesize;

        public int Filesize
        {
            get { return filesize; }
            set
            {
                filesize = value;
                OnPropertyChanged("Filesize");
            }
        }



    }
}
