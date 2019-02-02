using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace BlocksCore.Data.Shell.EntityTypeConfiguration
{
    public class ShellEntityTypeConfiguartionApply
    {
        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new ShellDescriptorEntityTypeConfiguartion());
          //  modelBuilder.ApplyConfiguration(new ShellParameterEntityTypeConfiguration());

        }
        
    }
}