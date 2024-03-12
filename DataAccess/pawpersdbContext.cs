using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Models;

#nullable disable

namespace DataAccess
{
    public partial class PawpersDbContext : DbContext
    {
        public PawpersDbContext()
        {
        }

        public PawpersDbContext(DbContextOptions<PawpersDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Dwelling> Dwellings { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Reply> Replies { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<Dwelling>(entity =>
            {
                entity.ToTable("Dwelling");

                entity.Property(e => e.DwellingId).HasColumnName("dwelling_id");

                entity.Property(e => e.DwellingType)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("dwelling_type");
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.HasKey(e => e.FavId)
                    .HasName("PK__Favorite__9694C47596BC756E");

                entity.ToTable("Favorite");

                entity.Property(e => e.FavId).HasColumnName("fav_id");

                entity.Property(e => e.DogId).HasColumnName("dog_id");

                entity.Property(e => e.IsAvailable).HasColumnName("is_available");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Favorites)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK__Favorite__profil__6E01572D");
            });

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.ToTable("Profile");

                entity.HasIndex(e => e.ProfileEmail, "UQ__Profile__B7578BECA5F10BA7")
                    .IsUnique();

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.ProfileAdoptionreason)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("profile_adoptionreason");

                entity.Property(e => e.ProfileAge).HasColumnName("profile_age");

                entity.Property(e => e.ProfileChildren).HasColumnName("profile_children");

                entity.Property(e => e.ProfileCity)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("profile_city");

                entity.Property(e => e.ProfileDogaggresive)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("profile_dogaggresive");

                entity.Property(e => e.ProfileDogsleepat)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("profile_dogsleepat");

                entity.Property(e => e.ProfileDwellingid).HasColumnName("profile_dwellingid");

                entity.Property(e => e.ProfileEmail)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("profile_email");

                entity.Property(e => e.ProfileFamilyallergies).HasColumnName("profile_familyallergies");

                entity.Property(e => e.ProfileHasyard).HasColumnName("profile_hasyard");

                entity.Property(e => e.ProfileHomephone)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("profile_homephone");

                entity.Property(e => e.ProfileLandlordname)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("profile_landlordname");

                entity.Property(e => e.ProfileLandlordphone)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("profile_landlordphone");

                entity.Property(e => e.ProfileMedfordog)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("profile_medfordog");

                entity.Property(e => e.ProfileName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("profile_name");

                entity.Property(e => e.ProfileNocaredog)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("profile_nocaredog");

                entity.Property(e => e.ProfileOccupation)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("profile_occupation");

                entity.Property(e => e.ProfileOtherpetage).HasColumnName("profile_otherpetage");

                entity.Property(e => e.ProfileOtherpetbreed)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("profile_otherpetbreed");

                entity.Property(e => e.ProfileOtherpetname)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("profile_otherpetname");

                entity.Property(e => e.ProfileOtherpetsex)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("profile_otherpetsex");

                entity.Property(e => e.ProfilePersonalphone)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("profile_personalphone");

                entity.Property(e => e.ProfileResponsiblefordog)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("profile_responsiblefordog");

                entity.Property(e => e.ProfileSpousename)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("profile_spousename");

                entity.Property(e => e.ProfileStateid).HasColumnName("profile_stateid");

                entity.Property(e => e.ProfileStreetaddress)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("profile_streetaddress");

                entity.Property(e => e.ProfileZipcode)
                    .IsRequired()
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("profile_zipcode");

                entity.HasOne(d => d.ProfileDwelling)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.ProfileDwellingid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pro_dwe_FK");

                entity.HasOne(d => d.ProfileState)
                    .WithMany(p => p.Profiles)
                    .HasForeignKey(d => d.ProfileStateid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pro_sta_FK");
            });

            modelBuilder.Entity<Reply>(entity =>
            {
                entity.ToTable("Reply");

                entity.Property(e => e.ReplyId).HasColumnName("reply_id");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.ReplyMessage)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("reply_message");

                entity.Property(e => e.ReplyTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("reply_timestamp");

                entity.Property(e => e.TopicId).HasColumnName("topic_id");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Reply__profile_i__71D1E811");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Replies)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Reply__topic_id__72C60C4A");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state");

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.Property(e => e.StateCode)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("state_code")
                    .IsFixedLength(true);

                entity.Property(e => e.StateName)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("state_name");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");

                entity.Property(e => e.TopicId).HasColumnName("topic_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.PostTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("post_timestamp")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProfileId).HasColumnName("profile_id");

                entity.Property(e => e.TopicBody)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("topic_body");

                entity.Property(e => e.TopicName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("topic_name");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Topic__category___73BA3083");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK__Topic__profile_i__6EF57B66");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
