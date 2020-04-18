using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Employees.WebApi.View_Models
{
    public class NewOrUpdateEmployeeVM
    {
        [Required]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [Required]
        [JsonProperty("address")]
        public string Address { get; set; }

        [Required]
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [JsonProperty("specialty")]
        public string Specialty { get; set; }
    }
}