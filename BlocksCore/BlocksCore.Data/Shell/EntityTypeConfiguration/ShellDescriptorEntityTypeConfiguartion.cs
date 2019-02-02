using BlocksCore.Loader.Abstractions.Shell.Descriptor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlocksCore.Data.Shell.EntityTypeConfiguration
{
    public class ShellDescriptorEntityTypeConfiguartion : IEntityTypeConfiguration<ShellDescriptor>
    {
        public void Configure(EntityTypeBuilder<ShellDescriptor> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasMany(b => b.Features);
            builder.HasMany(b => b.Parameters);
            
   
        }
    }
}