using ProjetBCC.Ctrl;
using ProjetBCC.DAO;
using ProjetBCC.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBCC.ORM
{
    public class PhotoORM
    {
        public static PhotoViewModel getPhoto(int id)
        {
            PhotoDAO pDAO = PhotoDAO.getPhoto(id);
            PhotoViewModel p = new PhotoViewModel(pDAO.idDAO, pDAO.photoDAO, pDAO.nomPhotoDAO);
            return p;
        }

        public static ObservableCollection<PhotoViewModel> listePhoto()
        {
            ObservableCollection<PhotoDAO> lDAO = PhotoDAO.listePhoto();
            ObservableCollection<PhotoViewModel> l = new ObservableCollection<PhotoViewModel>();
            foreach (PhotoDAO element in lDAO)
            {
                PhotoViewModel p = new PhotoViewModel(element.idDAO, element.photoDAO, element.nomPhotoDAO);
                l.Add(p);
            }
            return l;
        }
        public static void updatePhoto(PhotoViewModel p)
        {
            PhotoDAO.updatePhoto(new PhotoDAO(p.idProperty, p.photoProperty, p.nomPhotoProperty));
        }

        public static void supprimerPhoto(int id)
        {
            PhotoDAO.supprimerPhoto(id);
        }

        public static void insertPhoto(PhotoViewModel p)
        {
            PhotoDAO.insertPhoto(new PhotoDAO(p.idProperty, p.photoProperty, p.nomPhotoProperty));
        }
    }
}
