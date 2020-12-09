using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetBCC.Ctrl
{
    public class CategorieViewModel
    {
        private int id;
        private string nomCategorie;

        public CategorieViewModel() { }

        public CategorieViewModel(int id, string nomCategorie)
        {
            this.id = id;
            this.nomCategorie = nomCategorie;
        }

        public int idProperty
        {
            get { return id; }
            set
            {
                id = value;
            }
        }
        public String nomCategorieProperty
        {
            get { return nomCategorie; }
            set
            {
                nomCategorie = value;
            }

        }
    }
}
