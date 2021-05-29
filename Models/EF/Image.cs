namespace Models.EF
{
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Image
    {
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        public string Link { get; set; }

        public bool MainPic { get; set; }

        public int? ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}
