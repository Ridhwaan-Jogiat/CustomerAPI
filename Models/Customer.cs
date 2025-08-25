using System.ComponentModel.DataAnnotations;

namespace CustomerAPI.Models
{
    //I identified about 6 fields to build the model on:type,first name,surname,email,amount total and cellphone number
    public class Customer
    {
        public int Id { get; set; }

        /*Not sure what types are wanted Im going to go with person or
        company as I think a customer can be a individual person or a company*/
        [Required]
        public string Type { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Range(0, double.MaxValue)]
        public decimal AmountTotal { get; set; }

        [Required]
        [Phone]
        public string Cellphone { get; set; }

    }
}