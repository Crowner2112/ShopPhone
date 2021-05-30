namespace Models.EF
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Account")]
    public partial class Account
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Hãy nhập họ tên")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Hãy nhập đúng email")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hãy nhập đúng số điện thoại")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Hãy nhập mật khẩu")]
        [StringLength(50)]
        public string Password { get; set; }

        public bool? Role { get; set; }
    }
}
