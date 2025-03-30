using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GESTOCKTIPAM.BLL
{
    // Définition d'une classe appelée UserBLL (Business Logic Layer) pour représenter un utilisateur.
    public class UserBLL
    {
        // Déclaration de propriétés pour stocker les informations de l'utilisateur.

        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        // La propriété "photo" représente une image (sous forme de tableau de bytes) associée à l'utilisateur.
        public byte[] photo { get; set; }
    }

}
