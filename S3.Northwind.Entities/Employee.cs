namespace S3.Northwind.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            Employees1 = new HashSet<Employee>();
            Orders = new HashSet<Order>();
            Territories = new HashSet<Territory>();
        }

        private string lastName;
        private string firstname;
        private string title;
        private string titleOfCourtesy;
        private DateTime birthDate;
        private DateTime hireDate;
        private string address;
        private string city;
        private string region;
        private string postalCode;
        private string country;
        private string homePhone;
        private string extension;
        private int reportsTo;
        private string initials;
        private string notes;

        public int EmployeeID { get; set; }

        [Required]
        [StringLength(20)]
        public string LastName
        {
            get => lastName;
            set
            {
                var validationResult = ValidateLastName(value);
                if (!validationResult.isValid)
                {
                    throw new ArgumentException(validationResult.errorMessage, nameof(LastName));
                }
                if (lastName != value)
                {
                    lastName = value;
                }
            }
        }

        [Required]
        [StringLength(10)]
        public string FirstName { get; set; }

        [StringLength(30)]
        public string Title { get; set; }

        [StringLength(25)]
        public string TitleOfCourtesy { get; set; }

        public DateTime? BirthDate { get; set; }

        public DateTime? HireDate { get; set; }

        [StringLength(60)]
        public string Address { get; set; }

        [StringLength(15)]
        public string City { get; set; }

        [StringLength(15)]
        public string Region { get; set; }

        [StringLength(10)]
        public string PostalCode { get; set; }

        [StringLength(15)]
        public string Country { get; set; }

        [StringLength(24)]
        public string HomePhone { get; set; }

        [StringLength(4)]
        public string Extension { get; set; }

        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }

        [Column(TypeName = "ntext")]
        public string Notes { get; set; }

        public int? ReportsTo { get; set; }

        [StringLength(255)]
        public string PhotoPath { get; set; }

        [StringLength(4)]
        public string Initials { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees1 { get; set; }

        public virtual Employee Employee1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Territory> Territories { get; set; }


        public static (bool isValid, string errorMessage) ValidateLastName(string lastName)
        {
            if (lastName.Any(char.IsDigit))
                return (false, "Efternavn må ikke indeholde tal");
            else if (lastName.Length > 20)
                return (false, "Efternavn må ikke være længere end 20 tegn");
            else if (lastName == "" || lastName is null)
                return (false, "Efternavn skal udfyldes");
            return (true, String.Empty);
        }
        public static (bool isValid, string errorMessage) ValidateFirstName(string firstName)
        {
            if (firstName.Any(char.IsDigit))
                return (false, "Fornavn må ikke indeholde tal");
            else if (firstName.Length > 20)
                return (false, "Fornavn må ikke være længere end 10 tegn");
            else if (firstName == "" || firstName is null)
                return (false, "Fornavn skal udfyldes");
            return (true, String.Empty);
        }
        public static (bool isValid, string errorMessage) ValidateTitle(string title)
        {
            if (title.Length > 30)
                return (false, "Job titlen må højest være 30 tegn langt");
            if(title.Any(char.IsDigit))
                return (false, "Job titlen må ikke indeholde tal");
            return (true, String.Empty);
        }
        public static (bool isValid, string errorMessage) ValidateTitleOfCourtesy(string titleOfCourtesy)
        {
            if (titleOfCourtesy.Length > 30)
                return (false, "Titlen må højest være 30 tegn langt");
            if (titleOfCourtesy.Any(char.IsDigit))
                return (false, "Titlen må ikke indeholde tal");
            return (true, String.Empty);
        }
        public static (bool isValid, string errorMessage) ValidateBirthDate(DateTime birthDate)
        {
            if (birthDate > DateTime.Today)
                return (false, "Fødselsdagen kan ikke være i fremtiden");

            return (true, String.Empty);
        }
        public static (bool isValid, string errorMessage) ValidateHireDate(DateTime hiredate)
        {
            return (true, String.Empty);
        }
        public static (bool isValid, string errorMessage) ValidateAddress(string address)
        {
            if (address.Length > 60)
                return (false, "Adressen må ikke være længere end 60 tegn");

            return (true, String.Empty);
        }
        public static (bool isValid, string errorMessage) ValidateCity(string city)
        {
            if (city.Length > 15)
                return (false, "Bynavn må ikke være længere end 15 tegn");
            if (city.Any(char.IsDigit))
                return (false, "Bynavn må ikke indeholde tal");

            return (true, String.Empty);
        }

    }
}
