using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects
{
    public class FridgeForUpdatingDTO
    {
        [Required(ErrorMessage = "Name is a required field.")]
        public string Name { get; set; }
        public string OwnerName { get; set; }

    }
}
