using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    // Essa classe server para criar a tabela no banco de dados
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User"); // Criar a tabela "ToTable"

            builder.HasKey(u => u.Id); // Atribui uma chave Primaria "HasKey"

            builder.HasIndex(u => u.Email) // Cria um Index para o Email
                   .IsUnique(); // Diz que é um campo unico, dizendo que não pode ter dois e-mails iguais

            builder.Property(u => u.Name)
                   .IsRequired() // Diz que o Nome é Obrigatório
                   .HasMaxLength(60); // Tem no maximo 60 varchar "HasMaxLength"

            builder.Property(u => u.Email)
                   .HasMaxLength(100); // Tem no maximo 100 varchar "HasMaxLength"
        }
    }
}
