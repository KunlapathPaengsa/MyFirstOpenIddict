using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MyFirstOpenIddict.Common.Data.EFCore
{
    public class SchemaTableConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : class
    {
        /// <summary>Database schema</summary>
        public string Schema { get; }

        /// <summary>Initial class schema table configuration</summary>
        /// <param name="schema">Database schema</param>
        public SchemaTableConfiguration(string schema) => this.Schema = !string.IsNullOrEmpty(schema) ? schema : throw new ArgumentNullException(nameof(schema));

        /// <inheritdoc />
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            string name = typeof(TEntity).Name;
            builder.ToTable<TEntity>(name, this.Schema);
        }
    }
}