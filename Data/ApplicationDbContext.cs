using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProfSpec.Models;
namespace ProfSpec.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public  DbSet<ApplicationCourse> ApplicationCourses{ get; set; }
        public DbSet<ApplicationReclassification> ApplicationReclassifications { get; set; }
        public DbSet<Competence> Competences { get; set; }
        public DbSet<CompetenceCourse> CompetenceCourses { get; set; }
        public DbSet<CompetencePosition> GetCompetencePositions { get; set; }
        public DbSet<CompetenceWorker> CompetenceWorkers { get; set; }
        public  DbSet<Course> Courses { get; set; }
        public DbSet<DirectionsOfTraining> DirectionsOfTrainings { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<HobbyWorker> HobbyWorkers { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<InterestWorker> InterestWorkers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectWorker> ProjectWorkers { get; set; }
        public DbSet<Reclassification> Reclassifications { get; set; }
        public DbSet<RolOfProject> GetRolOfs { get; set; }
        public DbSet<StagesApplication> StagesApplications { get; set; }
        public DbSet<StagesRequalification> stagesRequalifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationCourse>().ToTable("ApplicationCourse");
            modelBuilder.Entity<ApplicationReclassification>().ToTable("ApplicationReclassification");
            modelBuilder.Entity<Competence>().ToTable("Competence");
            modelBuilder.Entity<CompetenceCourse>().ToTable("CompetenceCourse");
            modelBuilder.Entity<CompetencePosition>().ToTable("CompetencePosition");
            modelBuilder.Entity<CompetenceWorker>().ToTable("CompetenceWorker");
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<DirectionsOfTraining>().ToTable("DirectionsOfTraining");
            modelBuilder.Entity<Hobby>().ToTable("Hobby");
            modelBuilder.Entity<HobbyWorker>().ToTable("HobbyWorker");
            modelBuilder.Entity<Interest>().ToTable("Interest");
            modelBuilder.Entity<InterestWorker>().ToTable("InterestWorker");
            modelBuilder.Entity<Position>().ToTable("Position");
            modelBuilder.Entity<ProjectWorker>().ToTable("ProjectWorker");
            modelBuilder.Entity<Reclassification>().ToTable("Reclassification");
            modelBuilder.Entity<RolOfProject>().ToTable("RolOfProject");
            modelBuilder.Entity<StagesApplication>().ToTable("StagesApplication");
            modelBuilder.Entity<StagesRequalification>().ToTable("StagesRequalification");
            modelBuilder.Entity<Worker>().ToTable("Worker");
        }


    }
}
