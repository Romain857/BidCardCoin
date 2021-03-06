﻿using ProjetBCC.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBCC.DAO
{
    public class EnchereDAO
    {
        public int idDAO;
        public string nomEnchereDAO;
        public string heureEnchereDAO;
        public string dateEnchereDAO;
        public int idLieuDAO;
        public int idAdminDAO;

        public EnchereDAO(int idDAO, string nomEnchereDAO, string heureEnchereDAO, string dateEnchereDAO, int idLieuDAO, int idAdminDAO)
        {
            this.idDAO = idDAO;
            this.nomEnchereDAO = nomEnchereDAO;
            this.heureEnchereDAO = heureEnchereDAO;
            this.dateEnchereDAO = dateEnchereDAO;
            this.idLieuDAO = idLieuDAO;
            this.idAdminDAO = idAdminDAO;
        }
        public static ObservableCollection<EnchereDAO> listeEncheres()
        {
            ObservableCollection<EnchereDAO> l = EnchereDAL.selectEnchere();
            return l;
        }

        public static EnchereDAO getEnchere(int id)
        {
            EnchereDAO p = EnchereDAL.getEnchere(id);
            return p;
        }
        public static void updateEnchere(EnchereDAO p)
        {
            EnchereDAL.updateEnchere(p);
        }

        public static void supprimerEnchere(int id)
        {
            EnchereDAL.supprimerEnchere(id);
        }

        public static void insertEnchere(EnchereDAO p)
        {
            EnchereDAL.insertEnchere(p);
        }
    }
}
