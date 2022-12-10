using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UF.AssessmentProject.Controllers
{


    [Produces("application/json"),
        Route("api/[action]"),
        ApiController]
    [SwaggerTag("Transaction Middleware Controller to keep transactional data in Log Files")]

    public class TransactionController : ControllerBase
    {

        /// <summary>
        /// Submit Transaction data
        /// </summary>
        /// <remarks>
        /// Ensure all parameter needed and responded as per IDD
        /// Ensure all posible validation is done
        /// API purpose: To ensure all data is validated and only valid partner with valid signature are able to access to this API
        /// </remarks>
        /// <param name="req">language:en-US(English), ms-MY(BM)</param>  
        /// <returns></returns>
        [HttpPut]
        [SwaggerResponse(StatusCodes.Status200OK, "Submit Transaction Message successfully", typeof(Model.Transaction.ResponseMessage))]
        [SwaggerResponse(StatusCodes.Status401Unauthorized, "Unauthorized, Request")]
        [SwaggerResponse(StatusCodes.Status500InternalServerError, "Oops! Can't get your Post right now")]
        public ActionResult<Model.Transaction.ResponseMessage> SubmitTRansaction(Model.Transaction.RequestMessage requestsubmit)
        {
            // Model.Transaction.ResponseMessage results = new Model.Transaction.ResponseMessage();

            Model.Transaction.RequestMessage request = new Model.Transaction.RequestMessage()
            {
                partnerkey = requestsubmit.partnerkey,
                partnerpassword = requestsubmit.partnerpassword,
                partnerrefno = requestsubmit.partnerrefno,
                totalamount = requestsubmit.totalamount,
                items = new Model.Transaction.itemdetail()
                {
                    partneritemref = requestsubmit.items.partneritemref,
                    name = requestsubmit.items.name,
                    qty = requestsubmit.items.qty,
                    unitprice = requestsubmit.items.unitprice
                },
                timestamp = requestsubmit.timestamp,
                sig = requestsubmit.sig,

            };
            if ((request.partnerkey == "FAKEGOOGLE" && request.partnerpassword == "FAKEPASSWORD1234") || (request.partnerkey == "FAKEPEOPLE" && request.partnerpassword == "FAKEPASSWORD4578"))
            {
                return new Model.Transaction.ResponseMessage()
                {
                    result = 1,
                    resultmessage = "Request data is valid."
                };
            }
            else
            {
                return new Model.Transaction.ResponseMessage()
                {
                    result = 0,
                    resultmessage = "Access Denied!"
                };

            }



            // Your Code here

            // return Ok(results);
        }

        /// <summary>
        /// Test this controller is active
        /// </summary>
        /// <remarks>
        /// Test API to check API is Alive or not
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<string> TestAPI()
        {
            string result = "Hello World!";
            return Ok(result);
        }

        // [HttpPost]
        // public ActionResult<Model.Transaction.ResponseMessage> submittrxmessage()
        // {
        //     return Isubmittrx.submit();
        // }
    }
}
