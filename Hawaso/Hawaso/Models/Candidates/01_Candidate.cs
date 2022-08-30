using System.ComponentModel.DataAnnotations;

namespace Hawaso.Models.Candidates
{
    /// <summary>
    /// 후보자, 지원자(Applicant)
    /// </summary>
    public class CandidateBase
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

        public bool IsEnrollment { get; set; }
    }

    public class Candidate : CandidateBase
    {
        // Empty
        [StringLength(35)]
        public string? MiddleName { get; set; }

        public string? DOB { get; set; }

        public string? SSN { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(254)]
        public string? Email { get; set; }

        [StringLength(70)]
        public string? Address { get; set; }

        [StringLength(70)]
        public string? City { get; set; }

        [StringLength(2)]
        public string? State { get; set; }

        [DataType(DataType.PostalCode)]
        [StringLength(35)]
        public string? PostalCode { get; set; }

        [StringLength(35)]
        public string? Gender { get; set; }

        [StringLength(70)]
        public string? BirthCity { get; set; }

        [StringLength(2)]
        public string? BirthState { get; set; }

        [StringLength(70)]
        public string? BirthCountry { get; set; }

        [StringLength(35)]
        public string? DriverLicenseNumber { get; set; }

        [StringLength(2)]
        public string? DriverLicenseState { get; set; }

        public string? Photo { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(35)]
        public string? PrimaryPhone { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(35)]
        public string? SecondaryPhone { get; set; }

        [StringLength(35)]
        public string? LicenseNumber { get; set; }
    }
}
