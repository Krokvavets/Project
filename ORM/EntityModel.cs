using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public partial class EntityModel : DbContext
    {
        public EntityModel()
           : base("name=EntityModel")
        {
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<PrivateMessage> PrivateMessages { get; set; }
        public virtual DbSet<Section> Sections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Roles);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.User)
                .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Topic>()
               .HasMany(e => e.Messages)
               .WithRequired(e => e.Topic)
            .HasForeignKey(o => o.TopicId);

            modelBuilder.Entity<Section>()
               .HasMany(e => e.Topics)
               .WithRequired(e => e.Section)
               .HasForeignKey(o => o.SectionId);
        }
    }
}
