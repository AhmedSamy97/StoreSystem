using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreSystem.Dtos
{
    public class EditItemDto
    {
        public int subcategoryId { get; set; }
        public int[] qtysArr { get; set; }
            
    }
}
