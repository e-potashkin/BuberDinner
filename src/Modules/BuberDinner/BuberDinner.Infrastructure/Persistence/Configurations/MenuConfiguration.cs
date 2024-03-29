using BuberDinner.Domain.Aggregates.Dinner.ValueObjects;
using BuberDinner.Domain.Aggregates.Host.ValueObjects;
using BuberDinner.Domain.Aggregates.Menu;
using BuberDinner.Domain.Aggregates.Menu.Entities;
using BuberDinner.Domain.Aggregates.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configurations;

internal class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        ConfigureMenusTable(builder);
        ConfigureMenuSectionsTable(builder);
        ConfigureMenuDinnerIdsTable(builder);
        ConfigureMenuReviewIdsTable(builder);

        builder.Ignore(m => m.DomainEvents);
    }

    private static void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
    {
        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => MenuId.Factory.Create(value));

        builder.Property(m => m.HostId)
            .HasConversion(
                id => id.Value,
                value => HostId.Factory.Create(value));

        builder.HasIndex(m => m.Name);

        builder.HasQueryFilter(menu => !menu.IsDeleted);
    }

    private static void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.Sections, sb =>
        {
            sb.ToTable("MenuSections");

            sb.WithOwner().HasForeignKey(nameof(MenuId));

            sb.HasKey(nameof(Menu.Id), nameof(MenuId));

            sb.Property(s => s.Id)
                .HasColumnName(nameof(MenuSectionId))
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => MenuSectionId.Factory.Create(value));

            sb.OwnsMany(s => s.Items, ib =>
            {
                ib.ToTable("MenuItems");

                ib.WithOwner().HasForeignKey(nameof(MenuSectionId), nameof(MenuId));

                ib.HasKey(nameof(MenuItem.Id), nameof(MenuSectionId), nameof(MenuId));

                ib.Property(i => i.Id)
                    .HasColumnName(nameof(MenuItemId))
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => MenuItemId.Factory.Create(value));
            });

            sb.Navigation(s => s.Items).Metadata.SetField("_items");

            sb.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);
        });

        builder.Metadata.FindNavigation(nameof(Menu.Sections))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.DinnerIds, dib =>
        {
            dib.ToTable("MenuDinnerIds");

            dib.WithOwner().HasForeignKey(nameof(MenuId));

            dib.HasKey(nameof(Menu.Id));

            dib.Property(d => d.Value)
                .HasColumnName(nameof(DinnerId))
                .ValueGeneratedNever();
        });

        builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
    {
        builder.OwnsMany(m => m.MenuReviewIds, dib =>
               {
                   dib.ToTable("MenuReviewIds");

                   dib.WithOwner().HasForeignKey(nameof(MenuId));

                   dib.HasKey(nameof(Menu.Id));

                   dib.Property(d => d.Value)
                       .HasColumnName("ReviewId")
                       .ValueGeneratedNever();
               });

        builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}
