namespace GESTOCKTIPAM.BLL
{
  public class ProductsBLL
  {
    public int id { get; set; }
    public string code { get; set; }
    public string name { get; set; }
    public bool status { get; set; }

        #region Constructeurs par défaut et d'initialisation
        public ProductsBLL() { }

        public ProductsBLL(int id, string name, string code, bool status)
        {
            this.id = id;
            this.name = name;
            this.status = status;
            this.code = this.code;
        }

        #endregion
    }

}
