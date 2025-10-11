using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Helpers
{
    public static class MigrationConstraintsHelper
    {
        public static void AddCheckConstraint(MigrationBuilder migrationBuilder, string table, string column, string[] allowedValues)
        {
            var constraintName = $"CK_{table}_{column}";
            var allowedValuesSql = string.Join(", ", allowedValues.Select(v => $"'{v}'"));
            var sql = $@"
            ALTER TABLE [{table}]
            ADD CONSTRAINT {constraintName}
            CHECK ([{column}] IN ({allowedValuesSql}))
        ";
            migrationBuilder.Sql(sql);
        }

        public static void DropCheckConstraint(MigrationBuilder migrationBuilder, string table, string column)
        {
            var constraintName = $"CK_{table}_{column}";
            var sql = $@"
            ALTER TABLE [{table}]
            DROP CONSTRAINT {constraintName}
        ";
            migrationBuilder.Sql(sql);
        }
    }

}
