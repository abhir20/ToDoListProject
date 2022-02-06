using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using To_doProject.DAL;

namespace To_doProject.Business.Entitites
{
    public class ToDoList

    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string IsCompletedFlag { get; set; }

        public DateTime CreatedDate { get; set; }

        public int SerialNo { get; set; }

        //title, description, iscompleted flag, date and a unique serial number
    }

    public class ToDoListConfiguration : IEntityTypeConfiguration<ToDoList>
    {
        public void Configure(EntityTypeBuilder<ToDoList> builder)
        {
            // Set configuration for entity
            builder.ToTable("StockItems", "Warehouse");

            // Set key for entity
            builder.HasKey(p => p.Id);

            // Set configuration for columns

            builder.Property(p => p.Title).HasColumnType("nvarchar(200)").IsRequired();
            builder.Property(p => p.SerialNo).HasColumnType("int").IsRequired();
            builder.Property(p => p.Description).HasColumnType("nvarchar(100)");
            builder.Property(p => p.IsCompletedFlag).HasColumnType("char");
            builder.Property(p => p.CreatedDate).HasColumnType("date");


        }
    }
}