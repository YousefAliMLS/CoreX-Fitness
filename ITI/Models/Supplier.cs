using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ITI.Models
{
    public class Supplier
    {
        public int id   { get; set; }
        public string name { get; set; } = string.Empty;
        public string contactInfo { get; set; } = string.Empty;

        [ValidateNever]
        public List<Products> Products { get; set; }
    }
}
