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
        public DbSet<ProfSpec.Models.Interest> Interest { get; set; }
        public DbSet<ProfSpec.Models.Hobby> Hobby { get; set; }
        public DbSet<ProfSpec.Models.DirectionsOfTraining> DirectionsOfTraining { get; set; }
        public DbSet<ProfSpec.Models.Competence> Competence { get; set; }
        public DbSet<ProfSpec.Models.Course> Course { get; set; }
        public DbSet<ProfSpec.Models.Position> Position { get; set; }
        public DbSet<ProfSpec.Models.RolOfProject> RolOfProject { get; set; }
        public DbSet<ProfSpec.Models.CompetencePosition> CompetencePosition { get; set; }
        public DbSet<ProfSpec.Models.CompetenceCourse> CompetenceCourse { get; set; }
        public DbSet<ProfSpec.Models.Worker> Worker { get; set; }
        public DbSet<ProfSpec.Models.CompetenceWorker> CompetenceWorker { get; set; }
        public DbSet<ProfSpec.Models.HobbyWorker> HobbyWorker { get; set; }
        public DbSet<ProfSpec.Models.InterestWorker> InterestWorker { get; set; }
        public DbSet<ProfSpec.Models.Project> Project { get; set; }
        public DbSet<ProfSpec.Models.ProjectWorker> ProjectWorker { get; set; }
        public DbSet<ProfSpec.Models.StagesApplication> StagesApplication { get; set; }
        public DbSet<ProfSpec.Models.StagesRequalification> StagesRequalification { get; set; }
        public DbSet<ProfSpec.Models.ApplicationReclassification> ApplicationReclassification { get; set; }
        public DbSet<ProfSpec.Models.ApplicationCourse> ApplicationCourse { get; set; }
        public DbSet<ProfSpec.Models.ReclassificationMentor> ReclassificationMentor { get; set; }
        public DbSet<ProfSpec.Models.Reclassification> Reclassification { get; set; }
        //public  DbSet<ApplicationCourse> ApplicationCourses{ get; set; }
        //public DbSet<ApplicationReclassification> ApplicationReclassifications { get; set; }
        //public DbSet<Competence> Competences { get; set; }
        //public DbSet<CompetenceCourse> CompetenceCourses { get; set; }
        //public DbSet<CompetencePosition> GetCompetencePositions { get; set; }
        //public DbSet<CompetenceWorker> CompetenceWorkers { get; set; }
        //public  DbSet<Course> Courses { get; set; }
        //public DbSet<DirectionsOfTraining> DirectionsOfTrainings { get; set; }
        //public DbSet<Hobby> Hobbies { get; set; }
        //public DbSet<HobbyWorker> HobbyWorkers { get; set; }
        //public DbSet<Interest> Interests { get; set; }
        //public DbSet<InterestWorker> InterestWorkers { get; set; }
        //public DbSet<Position> Positions { get; set; }
        //public DbSet<Project> Projects { get; set; }
        //public DbSet<ProjectWorker> ProjectWorkers { get; set; }
        //public DbSet<Reclassification> Reclassifications { get; set; }
        //public DbSet<RolOfProject> GetRolOfs { get; set; }
        //public DbSet<StagesApplication> StagesApplications { get; set; }
        //public DbSet<StagesRequalification> stagesRequalifications { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<ApplicationCourse>().ToTable("ApplicationCourse");
        //    //modelBuilder.Entity<ApplicationReclassification>().ToTable("ApplicationReclassification");
        //    //modelBuilder.Entity<Competence>().ToTable("Competence");
        //    //modelBuilder.Entity<CompetenceCourse>().ToTable("CompetenceCourse");
        //    //modelBuilder.Entity<CompetencePosition>().ToTable("CompetencePosition");
        //    //modelBuilder.Entity<CompetenceWorker>().ToTable("CompetenceWorker");
        //    //modelBuilder.Entity<Course>().ToTable("Course");
        //    //modelBuilder.Entity<DirectionsOfTraining>().ToTable("DirectionsOfTraining");
        //    //modelBuilder.Entity<Hobby>().ToTable("Hobby");
        //    //modelBuilder.Entity<HobbyWorker>().ToTable("HobbyWorker");
        //    //modelBuilder.Entity<Interest>().ToTable("Interest");
        //    //modelBuilder.Entity<InterestWorker>().ToTable("InterestWorker");
        //    //modelBuilder.Entity<Position>().ToTable("Position");
        //    //modelBuilder.Entity<ProjectWorker>().ToTable("ProjectWorker");
        //    //modelBuilder.Entity<Reclassification>().ToTable("Reclassification");
        //    //modelBuilder.Entity<RolOfProject>().ToTable("RolOfProject");
        //    //modelBuilder.Entity<StagesApplication>().ToTable("StagesApplication");
        //    //modelBuilder.Entity<StagesRequalification>().ToTable("StagesRequalification");
        //    //modelBuilder.Entity<Worker>().ToTable("Worker");

        //    //modelBuilder.Entity<CompetenceCourse>().HasKey(c => new { c.CompetenceID, c.CourseID });
        //    //modelBuilder.Entity<CompetencePosition>().HasKey(c => new { c.CompetenceID, c.PositionID });
        //    //modelBuilder.Entity<CompetenceWorker>().HasKey(c => new { c.CompetenceID, c.Worker });
        //    //modelBuilder.Entity<HobbyWorker>().HasKey(c => new { c.HobbyID, c.WorkerID });
        //    //modelBuilder.Entity<InterestWorker>().HasKey(c => new { c.InterestID, c.WorkerID });
        //    //modelBuilder.Entity<ProjectWorker>().HasKey(c => new { c.ProjectID, c.WorkerID });

        //}


    }
}
