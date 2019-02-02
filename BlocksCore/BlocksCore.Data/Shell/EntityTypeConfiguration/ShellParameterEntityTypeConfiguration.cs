using BlocksCore.Loader.Abstractions.Shell.Descriptor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlocksCore.Data.Shell.EntityTypeConfiguration
{
    public class ShellParameterEntityTypeConfiguration: IEntityTypeConfiguration<ShellParameter>
    {
        public void Configure(EntityTypeBuilder<ShellParameter> builder)
        {

        }
    }
}