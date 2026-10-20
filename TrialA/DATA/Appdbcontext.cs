using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using TrialA.Models;

namespace TrialA.DATA
{
    public class Appdbcontext : DbContext
    {
        public Appdbcontext(DbContextOptions<Appdbcontext> options) : base(options)
        {

        }
        public DbSet<User>users{get;set;}
        public DbSet<CandidateProfile>candidateProfiles{get;set;}
        public DbSet<Company>companies{get;set;}
        public DbSet<Job>jobs{get;set;}
        public DbSet<Application>applications{get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(a => a.Email)
                .IsUnique();
            ///realtion
            ///1:1
            modelBuilder.Entity<User>().
                 HasOne(a => a.CProfile)
                 .WithOne(a => a.user)
                 .HasForeignKey<CandidateProfile>(a => a.UserID)
                 .OnDelete(DeleteBehavior.NoAction);
            ////1:M
            modelBuilder.Entity<User>()
                .HasMany(a=>a.Company)
                .WithOne(a=>a.user)
                .HasForeignKey(a => a.UserID)
                .OnDelete(DeleteBehavior.NoAction);
            ////1:M

            modelBuilder.Entity<Company>()
                .HasMany(a=>a.jobs)
                .WithOne(a=>a.company)
                .HasForeignKey(a=>a.companyId)
                .OnDelete(DeleteBehavior.NoAction);
            ////1:M

            modelBuilder.Entity<CandidateProfile>()
                .HasMany(a=>a.applications)
                .WithOne(a=>a.candidate)
                .HasForeignKey(a=>a.CandidteId)
                .OnDelete(DeleteBehavior.NoAction);
            ////1:M

            modelBuilder.Entity<Job>()
                .HasMany(a=>a.Application)
                .WithOne(a=>a.job)
                .HasForeignKey(a=>a.JobId)
                .OnDelete(DeleteBehavior.NoAction);


            ////Data Seed
            modelBuilder.Entity<User>().HasData(
                
                new User { Id=1,FullName="Ahmed Hassan",Email="ahmed@example.com", Password = "123456" ,Role="Candidate", CreatedAt=new DateTime(2026,09,01)},
                new User { Id=2,FullName="Sara Mohamed",Email= "sara@example.com", Password = "123456", Role="Employer", CreatedAt=new DateTime(2026, 09, 02) },
                new User { Id=3,FullName="Omer Ali",Email= "omar@example.com", Password = "123456", Role="Admin", CreatedAt=new DateTime(2026, 09, 03) }
              );

            modelBuilder.Entity<CandidateProfile>().HasData(
                
                new CandidateProfile { Id=1,Phone="01012345678",ResumeUrl= "example.com/resume1", Skill="ASP.NET CORE",yearsOfExperience=3,UserID=1},
                new CandidateProfile { Id=2,Phone="010987654321",ResumeUrl= "example.com/resume2", Skill="Java",yearsOfExperience=2,UserID=2}
                 );

            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "Tech Solution", Description = "software development", Wepsite = "TechSolution.example.com", Location = "Cairo", UserID = 1 },
                new Company { Id = 2, Name = "Futur System", Description = "IT consluting ", Wepsite = "https/FuturSystem.example.com", Location = "Giza", UserID = 2 });

            modelBuilder.Entity<Job>().HasData(
                
                new Job { Id=1,Title="Backend",Description="Develop by ASP.Net",Salary=30000,Location= "Cairo", EmployeeTypr="FullTime",PostedDate=new DateTime(2026,10,01),DeadTime=new DateTime(2026, 11, 01),Status="Open",companyId=1},
                new Job { Id=2,Title="Frontend",Description="Develop Wep interface",Salary=25000,Location= "Giza", EmployeeTypr="Fulltime",PostedDate=new DateTime(2026, 10, 02),DeadTime=new DateTime(2026, 11, 01),Status="Open",companyId=2},
                new Job { Id=3,Title="back",Description="Develop Wep interface",Salary=50000,Location= "Giza", EmployeeTypr="Fulltime",PostedDate=new DateTime(2026, 10, 02),DeadTime=new DateTime(2026, 11, 01),Status="Open",companyId=2}
                );

            modelBuilder.Entity<Application>().HasData(
                new Application { Id = 1, ApplicationDate = new DateTime(2026, 10, 05), Status = "Pending", CoverLetter = "interested in Backend", CandidteId = 1, JobId = 2 },
                new Application { Id = 2, ApplicationDate = new DateTime(2026, 10, 06), Status = "UnderReview", CoverLetter = "Experienced in Wep", CandidteId = 2, JobId = 2 }
                );

        }
    }
}
