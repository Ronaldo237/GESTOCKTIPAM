using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace GESTOCKTIPAM.BLL
{
    public class StocksBLL
    {
        // Propriété pour l'identifiant du produit
        [ForeignKey("Products")] // Annotation indiquant que prodid est une clé étrangère vers la table Products importer System.ComponentModel.DataAnnotations.Schema;
        public int prodid { get; set; }

        // Propriété pour le nom du produit
        public string prodname { get; set; }

        // Propriété pour la date de transaction
        public DateTime transdate { get; set; }

        // Propriété pour la quantité
        public int quantity { get; set; }

        // Propriété pour le code du produit
        public string prodcode { get; set; }

        // Propriété pour le code du status
        public bool prodstatus{ get; set; }
    }


}
