using System;
using Common.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class setDiscrimnatorRanges : Migration
    {
        /// <inheritdoc />
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add constraints for inheritance discriminators & Add constraints for Enums
            MigrationConstraintsHelper.AddCheckConstraint(migrationBuilder, "Users", "Role", ["Admin", "Instructor", "Student"]);
            MigrationConstraintsHelper.AddCheckConstraint(migrationBuilder, "Users", "Gender", ["Male", "Female"]);
            MigrationConstraintsHelper.AddCheckConstraint(migrationBuilder, "Exams", "Type", ["Practice", "Final"]);
            MigrationConstraintsHelper.AddCheckConstraint(migrationBuilder, "Exams", "Status", ["Queued", "Started", "Finished", "Cancelled"]);
            MigrationConstraintsHelper.AddCheckConstraint(migrationBuilder, "Questions", "Type", ["TrueFalse", "ChooseOne", "ChooseAll"]);
            MigrationConstraintsHelper.AddCheckConstraint(migrationBuilder, "Applicants", "Status", ["Pending", "Accepted", "Rejected", "UnderReview"]);
            MigrationConstraintsHelper.AddCheckConstraint(migrationBuilder, "Applicants", "Gender", ["Male", "Female"]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop all constraints if rolling back
            MigrationConstraintsHelper.DropCheckConstraint(migrationBuilder, "Users", "Role");
            MigrationConstraintsHelper.DropCheckConstraint(migrationBuilder, "Users", "Gender");
            MigrationConstraintsHelper.DropCheckConstraint(migrationBuilder, "Exams", "Type");
            MigrationConstraintsHelper.DropCheckConstraint(migrationBuilder, "Exams", "Status");
            MigrationConstraintsHelper.DropCheckConstraint(migrationBuilder, "Questions", "Type");
            MigrationConstraintsHelper.DropCheckConstraint(migrationBuilder, "Applicants", "Status");
            MigrationConstraintsHelper.DropCheckConstraint(migrationBuilder, "Applicants", "Gender");
        }

    }
}
