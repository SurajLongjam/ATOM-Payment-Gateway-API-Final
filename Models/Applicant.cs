using System;
using System.Collections.Generic;

namespace WebApplication14.Models;

public partial class Applicant
{
    public long AppId { get; set; }

    public string? ApplicationNo { get; set; }

    public string? FullName { get; set; }

    public string? Address { get; set; }

    public string? District { get; set; }

    public string? FatherName { get; set; }

    public string? MotherName { get; set; }

    public DateTime? DoB { get; set; }

    public string? MobileNo { get; set; }

    public string? Category { get; set; }

    public string? Gender { get; set; }

    public string? IsDap { get; set; }

    public string? HandicapCode { get; set; }

    public string? HandicapDegree { get; set; }

    public string? HandicapCertificate { get; set; }

    public string? PassportPhoto { get; set; }

    public string? SignaturePhoto { get; set; }

    public string? FatherOccupation { get; set; }

    public string? MotherOccupation { get; set; }

    public string? Country { get; set; }

    public string? State { get; set; }

    public string? Pincode { get; set; }

    public string? Prc { get; set; }

    public string? AgeProof { get; set; }

    public DateTime? SubmissionDate { get; set; }

    public string? TransactionId { get; set; }

    public string? TransactionStat { get; set; }

    public string? IsEligible { get; set; }

    public string? IsVerified { get; set; }

    public string? VerifiedBy { get; set; }

    public DateTime? VerifiedOn { get; set; }

    public string? AdmitCardDownloaded { get; set; }

    public string? EeregNo { get; set; }

    public string? Eepath { get; set; }

    public string? SelectedPost { get; set; }

    public decimal? Amount { get; set; }

    public string? ScstCert { get; set; }

    public string? IsGovtEmp { get; set; }

    public string? NocCert { get; set; }

    public string? Email { get; set; }

    public string? RazorpayOrderId { get; set; }

    public string? EerequisitionNo { get; set; }

    public string? Daptype { get; set; }

    public string? AgeOn { get; set; }

    public string? SvcRegCert { get; set; }

    public string? DrivingLic { get; set; }

    public string? ExperienceCert { get; set; }

    public string? MailingAddress { get; set; }

    public string? MailingPin { get; set; }

    public string? MaritalStat { get; set; }

    public DateTime? StatusCheckedOn { get; set; }

    public DateTime? ReUpdateOn { get; set; }

    public string? FirstPreference { get; set; }

    public string? SecondPreference { get; set; }

    public string? ThirdPreference { get; set; }
}
