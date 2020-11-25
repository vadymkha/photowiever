using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FotoViewer.Helpers;
using FotoViewer.Model;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.IO;

namespace FotoViewer.ViewModel
{
    public class MainWindowVM: ObservableObject
    {
        public ObservableCollection<Foto> Album { get; set; }

        private Foto selectedFoto;
        public Foto SelectedFoto
        {
            get { return selectedFoto; }
            set
            {
                selectedFoto = value;
                OnPropertyChanged("SelectedFoto");
            }
        }

        public MainWindowVM()
        {
            Album = new ObservableCollection<Foto>();
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand(
                    obj =>
                    {
                        OpenFileDialog openDialog = new OpenFileDialog();
                        openDialog.Filter = "JPEG files (*.JPEG)|*.JPEG|All files (*.*)|*.*||";
                        if(openDialog.ShowDialog() == true)
                        {
                            FileInfo file = new FileInfo(openDialog.FileName);
                            Foto foto = new Foto { Filepath = openDialog.FileName, Filename = file.Name, Filesize = (int)file.Length };
                            Album.Add(foto);
                            SelectedFoto = foto;
                        }
                    }
                    ));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ?? (removeCommand = new RelayCommand(
                    obj =>
                    {
                        Foto foto = obj as Foto;
                        Album.Remove(foto);
                    },
                    (obj)=>
                    {
                        return Album.Count > 0;
                    }
                    ));
            }
        }
    }
}
