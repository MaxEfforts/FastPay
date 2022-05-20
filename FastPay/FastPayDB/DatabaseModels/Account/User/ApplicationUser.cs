namespace FastPayDB.DatabaseModels.Account.User
{
    public class ApplicationUser : IdentityUser<int>, IBaseDataModel
    {
        public ApplicationUser()
        {
            UserGuid = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the user GUID
        /// </summary>
        public Guid UserGuid { get; set; }

        /// <summary>
        /// Gets the user identifier
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new int Id { get; set; }

        /// <summary>
        /// Gets or sets the user name
        /// </summary>
        public override string? UserName { get; set; }

        /// <summary>
        /// Gets or sets the email
        /// </summary>
        public override string? Email { get; set; }

        /// <summary>
        /// Gets or sets the email that should be re-validated. Used in scenarios when a customer is already registered and wants to change an email address.
        /// </summary>
        public string? EmailToRevalidate { get; set; }

        /// <summary>
        /// Gets or sets the phone code
        /// </summary>
        public string? PhoneCode { get; set; }

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        public override string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the first name
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or sets the full name
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// Gets or sets the gander (male/female)
        /// </summary>
        public string? Gander { get; set; }

        /// <summary>
        /// Gets or sets the date of birth
        /// </summary>
        //[DataType(DataType.Date)]
        //public DateTime? DateOfBirth { get; set; } //TODO Ex Attribute

        /// <summary>
        /// Gets or sets a flag indicating if a user has confirmed their email address.
        /// </summary>
        /// <value>True if the email address has been confirmed, otherwise false.</value>
        public override bool EmailConfirmed { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if a user has confirmed their telephone address.
        /// </summary>
        /// <value>True if the telephone number has been confirmed, otherwise false.</value>
        public override bool PhoneNumberConfirmed { get; set; }

        /// <summary>
        /// Gets or sets the password hash
        /// </summary>
        public override string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets if user login using social media or not
        /// </summary>
        public bool IsSocialLogin { get; set; } = false;

        /// <summary>
        /// Gets or sets the social auth id
        /// </summary>
        public string? SocialAuthId { get; set; }

        /// <summary>
        /// Gets or sets social media type
        /// 1- Facebook
        /// 2- Google
        /// 3- Twitter
        /// </summary>
        public int? SocialMediaType { get; set; }

        /// <summary>
        /// Gets or sets if user is active or not
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets company related with this user
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// Gets or sets vendor related with this user
        /// </summary>
        public int? VendorId { get; set; }

        //public string? ProfilePicture { get; set; } //TODO Ex Attribute

        /// <summary>
        /// Gets or sets a value indicating whether this customer has some products in the shopping cart
        /// <remarks>The same as if we run ShoppingCartItems.Count > 0
        /// We use this property for performance optimization:
        /// if this property is set to false, then we do not need to load "ShoppingCartItems" navigation property for each page load
        /// It's used only in a couple of places in the presenation layer
        /// </remarks>
        /// </summary>
        public bool HasShoppingCartItems { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the customer is required to re-login
        /// </summary>
        public bool RequireReLogin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating number of failed login attempts (wrong password)
        /// </summary>
        public int FailedLoginAttempts { get; set; }

        /// <summary>
        /// Gets or sets the date and time until which a customer cannot login (locked out)
        /// </summary>
        public DateTime? CannotLoginUntilDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the last IP address
        /// </summary>
        public string? LastIpAddress { get; set; }

        /// <summary>
        /// Gets or sets the date and time of last login
        /// </summary>
        public DateTime? LastLoginDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of last activity
        /// </summary>
        public DateTime? LastActivityDateUtc { get; set; }

        /// <summary>
        /// Gets or sets if user is published or not
        /// </summary>
        public bool IsPublished { get; set; }  //TODO base entity

        /// <summary>
        /// Gets or sets the date and time of entity creation
        /// </summary>
        public DateTime? CreatedOnUtc { get; set; } //TODO base entity

        /// <summary>
        /// Gets or sets if user is deleted or not
        /// </summary>
        public bool IsDeleted { get; set; } // 


        /*
        /// <summary>
        /// Gets or sets created by user id
        /// </summary>
        public long? CreatedBy { get; set; } //TODO base entity move to log
        
        /// <summary>
        /// Gets or sets updated on date time
        /// </summary>
        public DateTime? UpdatedOn { get; set; } //TODO base entity move to log
        
        /// <summary>
        /// Gets or sets updated by user id
        /// </summary>
        public long? UpdatedBy { get; set; }//TODO base entity move to log*/


    }
}