using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace signformApi.Models
{
    public class sItemData
    {
        public Dictionary<string, object> items { get; set; }
    }

    public class sItemModels
    {
        [Required]
        public Dictionary<string, object> items { get; set; }
        [Required]
        public string status { get; set; }
    }

    public class statusModels
    {
        [Required]
        public string status { get; set; }
    }
}