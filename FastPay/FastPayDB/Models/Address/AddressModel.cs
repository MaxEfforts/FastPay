using FastPayDB.Models.General;
using FastPayDB.Models.GraphResult;

namespace FastPayDB.Models.Address
{
    public class AddressModel : ResultBase
    {
        public int? Id { get; set; }
        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the country identifier
        /// </summary>
        public int? CountryId { get; set; }

        /// <summary>
        /// Gets or sets the state/province identifier
        /// </summary>
        public int? StateProvinceId { get; set; }

        /// <summary>
        /// Gets or sets the Country
        /// </summary>
        public string? Country { get; set; }

        /// <summary>
        /// Gets or sets the city
        /// </summary>
        public string? City { get; set; }

        /// <summary>
        /// Gets or sets the address 1
        /// </summary>
        public string? Address1 { get; set; }

        /// <summary>
        /// Gets or sets the address 2
        /// </summary>
        public string? Address2 { get; set; }

        /// <summary>
        /// Gets or sets the zip/postal code
        /// </summary>
        public string? ZipPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the PhoneCode
        /// </summary>
        public string? PhoneCode { get; set; }

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the UserId as foreign key for ApplicationUser entity
        /// </summary>
        public int UserId { get; set; }

        /// TODO AddFields
        /*/// <summary>
        /// Gets or sets the Latitude
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the Longitude
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Gets or sets the AddressTypeId
        /// </summary>
        public int AddressTypeId { get; set; }

        /// <summary>
        /// Gets or sets the BlockName
        /// </summary>
        public string BlockName { get; set; }

        /// <summary>
        /// Gets or sets the StreetName
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Gets or sets the AvenueName
        /// </summary>
        public string AvenueName { get; set; }\

        /// <summary>
        /// Gets or sets the BuildingName
        /// </summary>
        public string BuildingName { get; set; }

        /// <summary>
        /// Gets or sets the FloorName
        /// </summary>
        public string FloorName { get; set; }

        /// <summary>
        /// Gets or sets the FlatNo
        /// </summary>
        public string FlatNo { get; set; }

        /// <summary>
        /// Gets or sets the OfficeName
        /// </summary>
        public string OfficeName { get; set; }*/

        /// <summary>
        /// Gets or sets the AdditionalInformation
        /// </summary>
        public string? AdditionalInformation { get; set; }

        /// <summary>
        /// Gets or sets the IsDefault
        /// </summary>
        public bool IsDefault { get; set; }


        public List<AddFieldModel>? AddFieldList { get; set; }
    }
}
