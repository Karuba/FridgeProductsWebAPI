using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeProducts.Contracts.Dto
{
    public class FridgeForUpdatingDTO
    {
        [Required(ErrorMessage = "Name is a required field.")]
        public string Name { get; set; }
        public string OwnerName { get; set; }

    }
}
