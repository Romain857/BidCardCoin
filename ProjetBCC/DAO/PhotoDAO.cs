using ProjetBCC.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBCC.DAO
{
    public class PhotoDAO
    {
        public int idDAO;
        public string photoDAO;
        public string nomPhotoDAO;

        public PhotoDAO(int idDAO, string photoDAO, string nomPhotoDAO)
        {
            this.idDAO = idDAO;
            this.photoDAO = photoDAO;
            this.nomPhotoDAO = nomPhotoDAO;
        }

        public static ObservableCollection<PhotoDAO> listePhoto()
        {
            ObservableCollection<PhotoDAO> l = PhotoDAL.selectPhoto();
            return l;
        }

        public static PhotoDAO getPhoto(int id)
        {
            PhotoDAO p = PhotoDAL.getPhoto(id);
            return p;
        }
        public static void updatePhoto(PhotoDAO p)
        {
            PhotoDAL.updatePhoto(p);
        }

        public static void supprimerPhoto(int id)
        {
            PhotoDAL.supprimerPhoto(id);
        }

        public static void insertPhoto(PhotoDAO p)
        {
            PhotoDAL.insertPhoto(p);
        }
    }
}
