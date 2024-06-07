using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication14.Models;

public partial class LandRecruitDbContext : DbContext
{
    public LandRecruitDbContext()
    {
    }

    public LandRecruitDbContext(DbContextOptions<LandRecruitDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Applicant> Applicants { get; set; }

    public virtual DbSet<ApplicantEdu> ApplicantEdus { get; set; }

    public virtual DbSet<ApplicantLanguage> ApplicantLanguages { get; set; }

    public virtual DbSet<ApplicationStatus> ApplicationStatuses { get; set; }

    public virtual DbSet<ApprovedCandidate> ApprovedCandidates { get; set; }

    public virtual DbSet<AspnetApplication> AspnetApplications { get; set; }

    public virtual DbSet<AspnetMembership> AspnetMemberships { get; set; }

    public virtual DbSet<AspnetPath> AspnetPaths { get; set; }

    public virtual DbSet<AspnetPersonalizationAllUser> AspnetPersonalizationAllUsers { get; set; }

    public virtual DbSet<AspnetPersonalizationPerUser> AspnetPersonalizationPerUsers { get; set; }

    public virtual DbSet<AspnetProfile> AspnetProfiles { get; set; }

    public virtual DbSet<AspnetRole> AspnetRoles { get; set; }

    public virtual DbSet<AspnetSchemaVersion> AspnetSchemaVersions { get; set; }

    public virtual DbSet<AspnetUser> AspnetUsers { get; set; }

    public virtual DbSet<AspnetWebEventEvent> AspnetWebEventEvents { get; set; }

    public virtual DbSet<Billing> Billings { get; set; }

    public virtual DbSet<CanMark> CanMarks { get; set; }

    public virtual DbSet<CanNeetmark> CanNeetmarks { get; set; }

    public virtual DbSet<CandidateApp> CandidateApps { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<PostName> PostNames { get; set; }

    public virtual DbSet<VwAspnetApplication> VwAspnetApplications { get; set; }

    public virtual DbSet<VwAspnetMembershipUser> VwAspnetMembershipUsers { get; set; }

    public virtual DbSet<VwAspnetProfile> VwAspnetProfiles { get; set; }

    public virtual DbSet<VwAspnetRole> VwAspnetRoles { get; set; }

    public virtual DbSet<VwAspnetUser> VwAspnetUsers { get; set; }

    public virtual DbSet<VwAspnetUsersInRole> VwAspnetUsersInRoles { get; set; }

    public virtual DbSet<VwAspnetWebPartStatePath> VwAspnetWebPartStatePaths { get; set; }

    public virtual DbSet<VwAspnetWebPartStateShared> VwAspnetWebPartStateShareds { get; set; }

    public virtual DbSet<VwAspnetWebPartStateUser> VwAspnetWebPartStateUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = IO-sys\\SQLEXPRESS;Database=LandRecruitDB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.HasKey(e => e.AppId);

            entity.Property(e => e.AppId).HasColumnName("AppID");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.AdmitCardDownloaded)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.AgeOn)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.AgeProof)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ApplicationNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Daptype)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DAPtype");
            entity.Property(e => e.District)
                .HasMaxLength(90)
                .IsUnicode(false);
            entity.Property(e => e.DoB).HasColumnType("datetime");
            entity.Property(e => e.DrivingLic)
                .HasMaxLength(450)
                .IsUnicode(false);
            entity.Property(e => e.Eepath)
                .HasMaxLength(350)
                .IsUnicode(false)
                .HasColumnName("EEPath");
            entity.Property(e => e.EeregNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EERegNo");
            entity.Property(e => e.EerequisitionNo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EERequisitionNo");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.ExperienceCert)
                .HasMaxLength(450)
                .IsUnicode(false);
            entity.Property(e => e.FatherName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FatherOccupation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstPreference)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Preference");
            entity.Property(e => e.FullName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HandicapCertificate)
                .HasMaxLength(350)
                .IsUnicode(false)
                .HasColumnName("Handicap_Certificate");
            entity.Property(e => e.HandicapCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Handicap_Code");
            entity.Property(e => e.HandicapDegree)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Handicap_Degree");
            entity.Property(e => e.IsDap)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Is_DAP");
            entity.Property(e => e.IsEligible)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsGovtEmp)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IsVerified)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MailingAddress)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.MailingPin)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MailingPIN");
            entity.Property(e => e.MaritalStat)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MobileNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MotherName)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.MotherOccupation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NocCert)
                .HasMaxLength(350)
                .IsUnicode(false)
                .HasColumnName("NOC_Cert");
            entity.Property(e => e.PassportPhoto)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Pincode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PINCode");
            entity.Property(e => e.Prc)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("PRC");
            entity.Property(e => e.RazorpayOrderId)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("razorpay_order_id");
            entity.Property(e => e.ReUpdateOn).HasColumnType("datetime");
            entity.Property(e => e.ScstCert)
                .HasMaxLength(350)
                .IsUnicode(false)
                .HasColumnName("SCST_Cert");
            entity.Property(e => e.SecondPreference)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Second_Preference");
            entity.Property(e => e.SelectedPost)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SelectedPOST");
            entity.Property(e => e.SignaturePhoto)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StatusCheckedOn).HasColumnType("datetime");
            entity.Property(e => e.SubmissionDate).HasColumnType("datetime");
            entity.Property(e => e.SvcRegCert)
                .HasMaxLength(450)
                .IsUnicode(false)
                .HasColumnName("SVC_RegCert");
            entity.Property(e => e.ThirdPreference)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Third_Preference");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("TransactionID");
            entity.Property(e => e.TransactionStat)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VerifiedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VerifiedOn).HasColumnType("datetime");
        });

        modelBuilder.Entity<ApplicantEdu>(entity =>
        {
            entity.HasKey(e => e.EduId);

            entity.ToTable("Applicant_Edu");

            entity.Property(e => e.EduId).HasColumnName("EduID");
            entity.Property(e => e.AppId).HasColumnName("AppID");
            entity.Property(e => e.BoardName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.CertificatePath)
                .HasMaxLength(350)
                .IsUnicode(false);
            entity.Property(e => e.CourseName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.DivGrade)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MarkSheetPath)
                .HasMaxLength(350)
                .IsUnicode(false);
            entity.Property(e => e.YearofPassing)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ApplicantLanguage>(entity =>
        {
            entity.HasKey(e => e.LangId);

            entity.ToTable("Applicant_Language");

            entity.Property(e => e.LangId).HasColumnName("LangID");
            entity.Property(e => e.AppId).HasColumnName("AppID");
            entity.Property(e => e.Language)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.States)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ApplicationStatus>(entity =>
        {
            entity.HasKey(e => e.StatId);

            entity.ToTable("ApplicationStatus");

            entity.Property(e => e.StatId).HasColumnName("StatID");
            entity.Property(e => e.AppId).HasColumnName("AppID");
            entity.Property(e => e.AppState)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApplicationStatus1)
                .HasMaxLength(250)
                .IsUnicode(false)
                .HasColumnName("ApplicationStatus");
            entity.Property(e => e.DoE).HasColumnType("datetime");
            entity.Property(e => e.EntryBy)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ApprovedCandidate>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Acdownloaded)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ACDownloaded");
            entity.Property(e => e.Acdownloadedon)
                .HasColumnType("datetime")
                .HasColumnName("ACDownloadedon");
            entity.Property(e => e.AppId).HasColumnName("AppID");
            entity.Property(e => e.CenterName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ExamTime)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.PostCode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<AspnetApplication>(entity =>
        {
            entity.HasKey(e => e.ApplicationId)
                .HasName("PK__aspnet_A__C93A4C98AFEE30B8")
                .IsClustered(false);

            entity.ToTable("aspnet_Applications");

            entity.HasIndex(e => e.LoweredApplicationName, "UQ__aspnet_A__17477DE43C3A1BF5").IsUnique();

            entity.HasIndex(e => e.ApplicationName, "UQ__aspnet_A__3091033113D0471F").IsUnique();

            entity.HasIndex(e => e.LoweredApplicationName, "aspnet_Applications_Index").IsClustered();

            entity.Property(e => e.ApplicationId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ApplicationName).HasMaxLength(256);
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.LoweredApplicationName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspnetMembership>(entity =>
        {
            entity.HasKey(e => e.UserId)
                .HasName("PK__aspnet_M__1788CC4D69C9B5DC")
                .IsClustered(false);

            entity.ToTable("aspnet_Membership");

            entity.HasIndex(e => new { e.ApplicationId, e.LoweredEmail }, "aspnet_Membership_index").IsClustered();

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");
            entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");
            entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");
            entity.Property(e => e.LoweredEmail).HasMaxLength(256);
            entity.Property(e => e.MobilePin)
                .HasMaxLength(16)
                .HasColumnName("MobilePIN");
            entity.Property(e => e.Password).HasMaxLength(128);
            entity.Property(e => e.PasswordAnswer).HasMaxLength(128);
            entity.Property(e => e.PasswordQuestion).HasMaxLength(256);
            entity.Property(e => e.PasswordSalt).HasMaxLength(128);

            entity.HasOne(d => d.Application).WithMany(p => p.AspnetMemberships)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Me__Appli__31EC6D26");

            entity.HasOne(d => d.User).WithOne(p => p.AspnetMembership)
                .HasForeignKey<AspnetMembership>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Me__UserI__32E0915F");
        });

        modelBuilder.Entity<AspnetPath>(entity =>
        {
            entity.HasKey(e => e.PathId)
                .HasName("PK__aspnet_P__CD67DC58399BD941")
                .IsClustered(false);

            entity.ToTable("aspnet_Paths");

            entity.HasIndex(e => new { e.ApplicationId, e.LoweredPath }, "aspnet_Paths_index")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.PathId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LoweredPath).HasMaxLength(256);
            entity.Property(e => e.Path).HasMaxLength(256);

            entity.HasOne(d => d.Application).WithMany(p => p.AspnetPaths)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Pa__Appli__6383C8BA");
        });

        modelBuilder.Entity<AspnetPersonalizationAllUser>(entity =>
        {
            entity.HasKey(e => e.PathId).HasName("PK__aspnet_P__CD67DC59C311450D");

            entity.ToTable("aspnet_PersonalizationAllUsers");

            entity.Property(e => e.PathId).ValueGeneratedNever();
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.PageSettings).HasColumnType("image");

            entity.HasOne(d => d.Path).WithOne(p => p.AspnetPersonalizationAllUser)
                .HasForeignKey<AspnetPersonalizationAllUser>(d => d.PathId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Pe__PathI__693CA210");
        });

        modelBuilder.Entity<AspnetPersonalizationPerUser>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__aspnet_P__3214EC06D7426218")
                .IsClustered(false);

            entity.ToTable("aspnet_PersonalizationPerUser");

            entity.HasIndex(e => new { e.PathId, e.UserId }, "aspnet_PersonalizationPerUser_index1")
                .IsUnique()
                .IsClustered();

            entity.HasIndex(e => new { e.UserId, e.PathId }, "aspnet_PersonalizationPerUser_ncindex2").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.PageSettings).HasColumnType("image");

            entity.HasOne(d => d.Path).WithMany(p => p.AspnetPersonalizationPerUsers)
                .HasForeignKey(d => d.PathId)
                .HasConstraintName("FK__aspnet_Pe__PathI__6D0D32F4");

            entity.HasOne(d => d.User).WithMany(p => p.AspnetPersonalizationPerUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__aspnet_Pe__UserI__6E01572D");
        });

        modelBuilder.Entity<AspnetProfile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__aspnet_P__1788CC4CF5E094FB");

            entity.ToTable("aspnet_Profile");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.PropertyNames).HasColumnType("ntext");
            entity.Property(e => e.PropertyValuesBinary).HasColumnType("image");
            entity.Property(e => e.PropertyValuesString).HasColumnType("ntext");

            entity.HasOne(d => d.User).WithOne(p => p.AspnetProfile)
                .HasForeignKey<AspnetProfile>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Pr__UserI__46E78A0C");
        });

        modelBuilder.Entity<AspnetRole>(entity =>
        {
            entity.HasKey(e => e.RoleId)
                .HasName("PK__aspnet_R__8AFACE1BE8A0701B")
                .IsClustered(false);

            entity.ToTable("aspnet_Roles");

            entity.HasIndex(e => new { e.ApplicationId, e.LoweredRoleName }, "aspnet_Roles_index1")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.LoweredRoleName).HasMaxLength(256);
            entity.Property(e => e.RoleName).HasMaxLength(256);

            entity.HasOne(d => d.Application).WithMany(p => p.AspnetRoles)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Ro__Appli__5070F446");
        });

        modelBuilder.Entity<AspnetSchemaVersion>(entity =>
        {
            entity.HasKey(e => new { e.Feature, e.CompatibleSchemaVersion }).HasName("PK__aspnet_S__5A1E6BC19978DE6A");

            entity.ToTable("aspnet_SchemaVersions");

            entity.Property(e => e.Feature).HasMaxLength(128);
            entity.Property(e => e.CompatibleSchemaVersion).HasMaxLength(128);
        });

        modelBuilder.Entity<AspnetUser>(entity =>
        {
            entity.HasKey(e => e.UserId)
                .HasName("PK__aspnet_U__1788CC4D2425C929")
                .IsClustered(false);

            entity.ToTable("aspnet_Users");

            entity.HasIndex(e => new { e.ApplicationId, e.LoweredUserName }, "aspnet_Users_Index")
                .IsUnique()
                .IsClustered();

            entity.HasIndex(e => new { e.ApplicationId, e.LastActivityDate }, "aspnet_Users_Index2");

            entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LastActivityDate).HasColumnType("datetime");
            entity.Property(e => e.LoweredUserName).HasMaxLength(256);
            entity.Property(e => e.MobileAlias).HasMaxLength(16);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasOne(d => d.Application).WithMany(p => p.AspnetUsers)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Us__Appli__21B6055D");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspnetUsersInRole",
                    r => r.HasOne<AspnetRole>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__aspnet_Us__RoleI__5535A963"),
                    l => l.HasOne<AspnetUser>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__aspnet_Us__UserI__5441852A"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK__aspnet_U__AF2760AD66B3E463");
                        j.ToTable("aspnet_UsersInRoles");
                        j.HasIndex(new[] { "RoleId" }, "aspnet_UsersInRoles_index");
                    });
        });

        modelBuilder.Entity<AspnetWebEventEvent>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__aspnet_W__7944C810CC5DDC52");

            entity.ToTable("aspnet_WebEvent_Events");

            entity.Property(e => e.EventId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ApplicationPath).HasMaxLength(256);
            entity.Property(e => e.ApplicationVirtualPath).HasMaxLength(256);
            entity.Property(e => e.Details).HasColumnType("ntext");
            entity.Property(e => e.EventOccurrence).HasColumnType("decimal(19, 0)");
            entity.Property(e => e.EventSequence).HasColumnType("decimal(19, 0)");
            entity.Property(e => e.EventTime).HasColumnType("datetime");
            entity.Property(e => e.EventTimeUtc).HasColumnType("datetime");
            entity.Property(e => e.EventType).HasMaxLength(256);
            entity.Property(e => e.ExceptionType).HasMaxLength(256);
            entity.Property(e => e.MachineName).HasMaxLength(256);
            entity.Property(e => e.Message).HasMaxLength(1024);
            entity.Property(e => e.RequestUrl).HasMaxLength(1024);
        });

        modelBuilder.Entity<Billing>(entity =>
        {
            entity.ToTable("Billing");

            entity.Property(e => e.BillingId).ValueGeneratedNever();
            entity.Property(e => e.Entereddate).HasColumnType("datetime");
            entity.Property(e => e.Remark)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Transactiondate).HasColumnType("datetime");
            entity.Property(e => e.Transactionid)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CanMark>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.CanMarksId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CanMarksID");
            entity.Property(e => e.MarkAllotted).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.MarksObtained).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Percentage).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.SubjectName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CanNeetmark>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Biology).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CanAppId).HasColumnName("CanAppID");
            entity.Property(e => e.CanNeetId).HasColumnName("CanNeetID");
            entity.Property(e => e.Chemistry).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Physics).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<CandidateApp>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Age)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BoardName)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.CanId)
                .ValueGeneratedOnAdd()
                .HasColumnName("CanID");
            entity.Property(e => e.Category)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.DoB).HasColumnType("date");
            entity.Property(e => e.FatherName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName).HasMaxLength(150);
            entity.Property(e => e.Gender)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.InstitutionAddress)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.InstitutionName)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.MotherName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MotherTongue)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Nationality)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NotificationId).HasColumnName("NotificationID");
            entity.Property(e => e.PermAddress)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.PermMobile)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PermPin)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("PermPIN");
            entity.Property(e => e.PhotoPath)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.PreAddress).HasMaxLength(400);
            entity.Property(e => e.PreMobile)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.PrePin)
                .HasMaxLength(10)
                .HasColumnName("PrePIN");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Notification");

            entity.Property(e => e.Lastdate)
                .HasColumnType("datetime")
                .HasColumnName("lastdate");
            entity.Property(e => e.NotificationCopy)
                .HasMaxLength(350)
                .IsUnicode(false)
                .HasColumnName("notificationCopy");
            entity.Property(e => e.NotificationId).HasColumnName("NotificationID");
            entity.Property(e => e.NotificationSubject)
                .HasMaxLength(350)
                .IsUnicode(false)
                .HasColumnName("notificationSubject");
        });

        modelBuilder.Entity<PostName>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Post_Names");

            entity.Property(e => e.MinQualification)
                .HasMaxLength(450)
                .IsUnicode(false)
                .HasColumnName("Min_Qualification");
            entity.Property(e => e.ObcageLimit).HasColumnName("OBCAgeLimit");
            entity.Property(e => e.PostName1)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("PostName");
            entity.Property(e => e.PwdobcageLimit).HasColumnName("PWDOBCageLimit");
            entity.Property(e => e.PwdscageLimit).HasColumnName("PWDSCAgeLimit");
            entity.Property(e => e.PwdurageLimit).HasColumnName("PWDURageLimit");
            entity.Property(e => e.ScStFee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("SC_ST_fee");
            entity.Property(e => e.ScageLimit).HasColumnName("SCAgeLimit");
            entity.Property(e => e.UrObcFee)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("UR_OBC_Fee");
        });

        modelBuilder.Entity<VwAspnetApplication>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_Applications");

            entity.Property(e => e.ApplicationName).HasMaxLength(256);
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.LoweredApplicationName).HasMaxLength(256);
        });

        modelBuilder.Entity<VwAspnetMembershipUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_MembershipUsers");

            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");
            entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");
            entity.Property(e => e.LastActivityDate).HasColumnType("datetime");
            entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");
            entity.Property(e => e.LoweredEmail).HasMaxLength(256);
            entity.Property(e => e.MobileAlias).HasMaxLength(16);
            entity.Property(e => e.MobilePin)
                .HasMaxLength(16)
                .HasColumnName("MobilePIN");
            entity.Property(e => e.PasswordAnswer).HasMaxLength(128);
            entity.Property(e => e.PasswordQuestion).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<VwAspnetProfile>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_Profiles");

            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwAspnetRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_Roles");

            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.LoweredRoleName).HasMaxLength(256);
            entity.Property(e => e.RoleName).HasMaxLength(256);
        });

        modelBuilder.Entity<VwAspnetUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_Users");

            entity.Property(e => e.LastActivityDate).HasColumnType("datetime");
            entity.Property(e => e.LoweredUserName).HasMaxLength(256);
            entity.Property(e => e.MobileAlias).HasMaxLength(16);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<VwAspnetUsersInRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_UsersInRoles");
        });

        modelBuilder.Entity<VwAspnetWebPartStatePath>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_WebPartState_Paths");

            entity.Property(e => e.LoweredPath).HasMaxLength(256);
            entity.Property(e => e.Path).HasMaxLength(256);
        });

        modelBuilder.Entity<VwAspnetWebPartStateShared>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_WebPartState_Shared");

            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwAspnetWebPartStateUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_WebPartState_User");

            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
