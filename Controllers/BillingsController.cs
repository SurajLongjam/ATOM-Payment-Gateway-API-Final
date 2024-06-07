using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication14.Models;
using WebApplication14.App_Code;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using WebApplication14.Models;

namespace WebApplication14.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingsController : ControllerBase
    {
        private readonly AtomAES _atomAES;
        private readonly LandRecruitDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public BillingsController(AtomAES atomAES, LandRecruitDbContext context, IConfiguration configuration, IWebHostEnvironment env)
        {
            _atomAES = atomAES;
            _context = context;
            _configuration = configuration;
            _env = env;
        }

        //        // GET: api/Billings
        //        [HttpGet]
        //        public async Task<ActionResult<IEnumerable<Billing>>> GetBillings()
        //        {
        //          if (_context.Billings == null)
        //          {
        //              return NotFound();
        //          }
        //            return await _context.Billings.ToListAsync();
        //        }

        //        // GET: api/Billings/5
        //        [HttpGet("{id}")]
        //        public async Task<ActionResult<Billing>> GetBilling(int id)
        //        {
        //          if (_context.Billings == null)
        //          {
        //              return NotFound();
        //          }
        //            var billing = await _context.Billings.FindAsync(id);

        //            if (billing == null)
        //            {
        //                return NotFound();
        //            }

        //            return billing;
        //        }

        //        // PUT: api/Billings/5
        //        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //        [HttpPut("{id}")]
        //        public async Task<IActionResult> PutBilling(int id, Billing billing)
        //        {
        //            if (id != billing.BillingId)
        //            {
        //                return BadRequest();
        //            }

        //            _context.Entry(billing).State = EntityState.Modified;

        //            try
        //            {
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!BillingExists(id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }

        //            return NoContent();
        //        }

        //        // POST: api/Billings
        //        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //        [HttpPost]
        //        public async Task<ActionResult<Billing>> PostBilling(Billing billing)
        //        {
        //          if (_context.Billings == null)
        //          {
        //              return Problem("Entity set 'LandRecruitDbContext.Billings'  is null.");
        //          }
        //            _context.Billings.Add(billing);
        //            try
        //            {
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateException)
        //            {
        //                if (BillingExists(billing.BillingId))
        //                {
        //                    return Conflict();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }

        //            return CreatedAtAction("GetBilling", new { id = billing.BillingId }, billing);
        //        }

        //        // DELETE: api/Billings/5
        //        [HttpDelete("{id}")]
        //        public async Task<IActionResult> DeleteBilling(int id)
        //        {
        //            if (_context.Billings == null)
        //            {
        //                return NotFound();
        //            }
        //            var billing = await _context.Billings.FindAsync(id);
        //            if (billing == null)
        //            {
        //                return NotFound();
        //            }

        //            _context.Billings.Remove(billing);
        //            await _context.SaveChangesAsync();

        //            return NoContent();
        //        }

        //        private bool BillingExists(int id)
        //        {
        //            return (_context.Billings?.Any(e => e.BillingId == id)).GetValueOrDefault();
        //        }
        //    }
        //}
        #region Verify payment and return values
        [HttpPost("ReturnUrl")]
        public async Task<ActionResult<Billing>> ReturnUrl([FromForm] string encData)
        {
            byte[] bt;
            string strClientCode, strClientCodeEncoded;
            string postingmmp_txn = "";
            string postingmer_txn = "";
            string postinamount = "";
            string postingprod = "";
            string postingdate = "";
            string postingbank_txn = "";
            string postingf_code = "";
            string postingbank_name = "";
            string signature = "";
            string postingdiscriminator = "";
            string postingdesc = "";
            string postingCC = "";
            try
            {
                byte[] iv = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
                int iterations = 65536;
                int keysize = 256;

                // Reading form data
                var formCollection = await Request.ReadFormAsync();

                // Building query string from form data
                var queryParams = string.Join("&", formCollection.Select(item => $"{item.Key}={HttpUtility.UrlEncode(item.Value)}"));
                var uri = new Uri("http://atom.in?" + queryParams);

                // Now you can use HttpUtility.ParseQueryString
                var query = HttpUtility.ParseQueryString(uri.Query);

                string passphrase1 = "19DE2650AF672D308C508346BDDE0B32"; /*_configuration.GetValue<string>("RETURNHASH");*/
                string salt1 = "19DE2650AF672D308C508346BDDE0B32";
                string Decryptval = _atomAES.decrypt(encData, passphrase1, salt1, iv, iterations);

                var test = new Uri("http://atom.in?" + Decryptval);
                var querydata = HttpUtility.ParseQueryString(test.Query);
                string date = querydata.Get("date");


                if (querydata.Get("mmp_txn") != null)
                {
                    postingmmp_txn = querydata.Get("mmp_txn"); //atomtxn id
                    postingmer_txn = querydata.Get("mer_txn").ToString();//mertxnid
                    postinamount = querydata.Get("amt").ToString();//totalamount
                    postingprod = querydata.Get("prod").ToString();
                    postingdate = querydata.Get("date").ToString();//txndate
                    postingbank_txn = querydata.Get("bank_txn").ToString();//banktxnid
                    postingf_code = querydata.Get("f_code").ToString();//txnstatus
                    postingbank_name = querydata.Get("bank_name").ToString();
                    signature = querydata.Get("signature").ToString();
                    postingdiscriminator = querydata.Get("discriminator").ToString();
                    postingdesc = querydata.Get("desc").ToString();//statustext : success or failed
                    postingCC = querydata.Get("clientcode").ToString();

                    string ClientCode = "";
                    bt = Encoding.UTF8.GetBytes(postingCC);
                    strClientCode = Convert.ToBase64String(bt);
                    strClientCodeEncoded = HttpUtility.UrlEncode(strClientCode);


                    string respHashKey = "4fdbdb5dccac783ab0";
                    string ressignature = "";
                    string strsignature = postingmmp_txn + postingmer_txn + postingf_code + postingprod + postingdiscriminator + postinamount + postingbank_txn;
                    //string strsignature = postingmmp_txn + postingmer_txn1 + postingf_code + postingprod + discriminator + postinamount + postingbank_txn;
                    byte[] bytes = Encoding.UTF8.GetBytes(respHashKey);
                    byte[] b = new HMACSHA512(bytes).ComputeHash(Encoding.UTF8.GetBytes(strsignature));
                    ressignature = byteToHexString(b).ToLower();


                    ActionResult finalResult = Ok(new { Message = "Payment processed successfully" }); // Default response

                    if (signature == ressignature)
                    {
                        string remark;
                        if (postingf_code == "Ok")
                        {
                            remark = "Success";

                        }
                        else if (postingf_code == "F")
                        {
                            remark = "Failed";
                        }
                        else
                        {
                            remark = "Canceled";
                        }

                        // Update Billing record using Entity Framework Core
                        var billingRecord = await _context.Billings.FirstOrDefaultAsync(b => b.Transactionid == postingmer_txn);
                        if (billingRecord != null)
                        {
                            billingRecord.Remark = remark;
                            billingRecord.Entereddate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                            billingRecord.Transactiondate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                            _context.Billings.Update(billingRecord);
                            await _context.SaveChangesAsync();
                        }
                    }
                    else
                    {
                        String remark = "Signature Mismatched...";
                        // Update Billing record using Entity Framework Core
                        var billingRecord = await _context.Billings.FirstOrDefaultAsync(b => b.Transactionid == postingmer_txn);
                        if (billingRecord != null)
                        {
                            billingRecord.Remark = remark;
                            billingRecord.Entereddate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                            billingRecord.Transactiondate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                            _context.Billings.Update(billingRecord);
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                else
                {
                    String remark = "Somthing went wrong.";
                    // Update Billing record using Entity Framework Core
                    var billingRecord = await _context.Billings.FirstOrDefaultAsync(b => b.Transactionid == postingmer_txn);
                    if (billingRecord != null)
                    {
                        billingRecord.Remark = remark;
                        billingRecord.Entereddate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                        billingRecord.Transactiondate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                        _context.Billings.Update(billingRecord);
                        await _context.SaveChangesAsync();
                    }
                }
                // Verification Step: Retrieve the updated record to verify the changes
                var updatedRecord = await _context.Billings.AsNoTracking().FirstOrDefaultAsync(b => b.Transactionid == postingmer_txn);
                if (updatedRecord != null && updatedRecord.Remark == "Success")
                {
                    //// Logic to download the Gazette, similar to what's in the GazetteDownload action.
                    //var gazette = await _context.Gazettes.FirstOrDefaultAsync(g => g.GazetteId == updatedRecord.GazetteId);
                    //if (gazette == null)
                    //{
                    //    return NotFound("Requested file not found.");
                    //}

                    //var filePath = Path.Combine(_env.WebRootPath, gazette.Gazettedoc.TrimStart('\\'));
                    //if (!System.IO.File.Exists(filePath))
                    //{
                    //    return NotFound("File does not exist.");
                    //}

                    //var memory = new MemoryStream();
                    //using (var stream = new FileStream(filePath, FileMode.Open))
                    //{
                    //    await stream.CopyToAsync(memory);
                    //}
                    //memory.Position = 0;

                    //var contentType = "APPLICATION/octet-stream";
                    //var fileName = Path.GetFileName(gazette.Gazettedoc);
                    //return File(memory, contentType, fileName);
                }
                return Ok(new { Message = "Payment processed successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        #endregion



        #region Payment in repository class
        [HttpPost("MakePayment")]
        public async Task<IActionResult> MakePayment([FromBody] Billing billing)
        {
            try
            {
                byte[] b;
                string MID = "9273";
                string TransactionID = RandomID(10, false);
                string strClientCode, strClientCodeEncoded;
                string MerchantLogin = MID;
                string MerchantPass = "Test@123";
                string TransactionType = "NBFundTransfer";
                string ProductID = "NSE";
                string TransactionAmount = billing.Totalprice.ToString();
                string TransactionCurrency = "INR";
                string BankID = "2001";
                string ufd21 = "9399" + "~REVENUE DEPARTMENT MANIPUR~https://localhost:7084";
                //string ufd21 = "9399" + "~DIRECTORATE OF PRINTING AND STATIONERY MANIPUR~http://10.10.139:8099";

                string TransactionServiceCharge = "";
                string TransactionDateTime = DateTime.Now.ToString("yyyy-MM-dd");
                string ClientCode = "01950075";
                string ru = "https://localhost:7084/api/Billings/ReturnUrl";
                //string ru = "http://10.10.1.139:8099/api/Billings/ReturnUrl";

                b = Encoding.UTF8.GetBytes(ClientCode);
                strClientCode = Convert.ToBase64String(b);
                strClientCodeEncoded = HttpUtility.UrlEncode(strClientCode);

                string passphrase = "83D1E1EC3DEE483BB698935F9B312A82";
                string salt = "83D1E1EC3DEE483BB698935F9B312A82";
                byte[] iv = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
                int iterations = 65536;
                int keysize = 256;

                string CustomerAccountNo = "0123456789";
                string MerchantDiscretionaryData = "";
                //  string reqHashKey = requestkey;
                string reqHashKey = "1b5120f34ab09977b2";
                string signature = "";
                string strsignature = MerchantLogin + MerchantPass + TransactionType + ProductID + TransactionID + TransactionAmount + TransactionCurrency;
                byte[] bytes = Encoding.UTF8.GetBytes(reqHashKey);
                //byte[] bt = new HMACSHA512(bytes).ComputeHash(Encoding.UTF8.GetBytes(strsignature));
                byte[] strsignatureBytes = Encoding.UTF8.GetBytes(strsignature);
                byte[] bt = new HMACSHA512(bytes).ComputeHash(strsignatureBytes);

                signature = byteToHexString(bt).ToLower();

                string postData = "login=" + MerchantLogin + "&pass=" + MerchantPass + "&ttype=" + TransactionType + "&prodid=" + ProductID + "&amt=" + TransactionAmount + "&txncurr=" + TransactionCurrency + "&txnscamt=" + TransactionServiceCharge + "&clientcode=" + strClientCodeEncoded + "&txnid=" + TransactionID + "&date=" + TransactionDateTime + "&custacc=" + CustomerAccountNo + "&mdd=" + MerchantDiscretionaryData + "&ru=" + ru + "&udf21=" + ufd21 + "&signature=" + signature;

                string Encryptval = _atomAES.Encrypt(postData, passphrase, salt, iv, iterations);

                string hexURL = "https://paynetzuat.atomtech.in/paynetz/epi/fts" + "?login=" + MerchantLogin + "&encdata=" + Encryptval;

                // Check if the model state is valid
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                billing.Totalprice = Convert.ToInt32(TransactionAmount);
                billing.Entereddate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                billing.Transactionid = TransactionID;
                billing.Transactiondate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                billing.Remark = "Initiated";

                // Add the Billing object to the context and save changes
                await _context.Billings.AddAsync(billing);
                await _context.SaveChangesAsync();

                return Ok(hexURL);

            }
            catch (Exception ex)
            {
                // Consider logging the exception details
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        private readonly Random _random = new Random();

        [NonAction]
        public string RandomID(int size, bool lowerCase = false)
        {

            var builder = new StringBuilder(size);

            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        [NonAction]
        public static string byteToHexString(byte[] byData)
        {
            StringBuilder sb = new StringBuilder((byData.Length * 2));
            for (int i = 0; (i < byData.Length); i++)
            {
                int v = (byData[i] & 255);
                if ((v < 16))
                {
                    sb.Append('0');
                }

                sb.Append(v.ToString("X"));

            }

            return sb.ToString();
        }
        #endregion


    }
}

