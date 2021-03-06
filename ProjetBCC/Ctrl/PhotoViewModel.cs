﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ProjetBCC.ORM;

namespace ProjetBCC.Ctrl
{
    public class PhotoViewModel : INotifyPropertyChanged
    {
        private int id;
        private string photo;
        private string nomPhoto;
        private string concat = "Ajouter ";

        public PhotoViewModel() { }

        public PhotoViewModel(int id, string photo, string nomPhoto)
        {
            this.id = id;
            this.photo = photo;
            this.nomPhoto = nomPhoto;
        }

        public int idProperty
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
        public string photoProperty
        {
            get { return photo; }
            set
            {
                photo = value;
            }
        }
        public String nomPhotoProperty
        {
            get { return nomPhoto; }
            set
            {
                nomPhoto = value;
                OnPropertyChanged("nomPhotoProperty");
            }
        }

        public string ConcatProperty
        {
            get { return concat; }
            set
            {
                this.concat = value;
                OnPropertyChanged("ConcatProperty");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                this.PropertyChanged(this, new PropertyChangedEventArgs(info));
                PhotoORM.updatePhoto(this);
            }
        }
    }
}
