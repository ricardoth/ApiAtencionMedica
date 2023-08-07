namespace AtencionMedica.Infraestructure.Data.Configurations
{
    public class MedicamentoConfiguration : IEntityTypeConfiguration<Medicamento>
    {
        public void Configure(EntityTypeBuilder<Medicamento> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .HasColumnName("IdMedicamento");

            entity.ToTable("Medicamento");

            entity.Property(e => e.NombreMedicamento)
               .HasMaxLength(150)
               .IsRequired()
               .IsUnicode(false);
        }
    }
}
