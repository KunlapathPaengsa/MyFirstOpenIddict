using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyFirstOpenIddict.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyFirstOpenIddict.Common.Data.EFCore
{
    public class AuditableConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : class
    {
        /// <summary>
        /// Initial class 'AuditableConfiguration' and set maximum length : 256
        /// </summary>
        public int MaxLength { get; private set; }

        /// <summary>
        /// Initial class 'AuditableConfiguration' and set maximum length : 256
        /// </summary>
        public AuditableConfiguration()
          : this(256)
        {
        }

        /// <summary>Initial class 'AuditableConfiguration'</summary>
        /// <param name="maxLength">Maximum length of CreatedBy and UpdatedBy</param>
        public AuditableConfiguration(int maxLength) => this.MaxLength = maxLength;

        /// <summary>Set auditable configure of table.</summary>
        /// <param name="builder">EntityTypeBuilder of entity(Table)</param>
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            Type type = typeof(TEntity);
            if (!((IEnumerable<Type>)type.GetInterfaces()).Any<Type>((Func<Type, bool>)(c => c == typeof(IAuditableEntity))))
                throw new Exception("Class : '" + type.Name + "' not inherited 'IAuditableEntity'.");
            builder.Property("CreatedBy").HasMaxLength(this.MaxLength).IsRequired();
            builder.Property("CreatedDate").IsRequired();
            builder.Property("UpdatedBy").HasMaxLength(this.MaxLength).IsRequired();
            builder.Property("UpdatedDate").IsRequired();
        }
    }
}
