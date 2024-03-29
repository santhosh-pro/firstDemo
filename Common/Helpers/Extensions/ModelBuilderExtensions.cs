using Microsoft.EntityFrameworkCore;

namespace firstDemo.Common.Helpers.Extensions
{
    public static class ModelBuilderExtensions {
        public static void ToSnakeCase (this ModelBuilder modelBuilder) {
            foreach (var entity in modelBuilder.Model.GetEntityTypes ()) {
                // Replace table names
                entity.SetTableName (entity.GetTableName ().ToSnakeCase ());

                // Replace column names            
                foreach (var property in entity.GetProperties ()) {
                    property.SetColumnName (property.GetColumnName ().ToSnakeCase ());
                }

                foreach (var key in entity.GetKeys ()) {
                    key.SetName (key.GetName ().ToSnakeCase ());
                }

                foreach (var key in entity.GetForeignKeys ()) {
                    key.SetConstraintName (key.GetConstraintName ().ToSnakeCase ());
                }

                foreach (var index in entity.GetIndexes ()) {
                    index.SetName (index.GetName ().ToSnakeCase ());
                }
            }
        }
    }
}