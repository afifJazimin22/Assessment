using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace UF.AssessmentProject.Model.Transaction
{
    public class RequestMessage : Model.RequestMessage
    {
        public string partnerrefno { get; set; }
        public long totalamount { get; set; }
        public itemdetail items { get; set; }
    }

    public class itemdetail
    {
        [Required(ErrorMessage = "Cannot be null or empty!")]
        public string partneritemref { get; set; }

        [Required(ErrorMessage = "Cannot be null or empty!")]
        public string name { get; set; }

        [Range(1, 5)]
        public int qty { get; set; }

        [Required]
        public long unitprice { get; set; }

    }

    public class ResponseMessage
    {
        public int result { get; set; }

        public string resultmessage { get; set; }
    }
}
