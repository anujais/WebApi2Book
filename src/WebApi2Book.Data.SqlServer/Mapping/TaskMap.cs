// TaskMap.cs
// Copyright Jamie Kurtz, Brian Wortman 2015.

using WebApi2Book.Data.Entities;

namespace WebApi2Book.Data.SqlServer.Mapping
{
    public class TaskMap : VersionedClassMap<Task>
    {
        public TaskMap()
        {
            HasKey(x => x.TaskId);
            Property(x => x.Subject).IsRequired();
            Property(x => x.StartDate).IsOptional();
            Property(x => x.DueDate).IsOptional();
            Property(x => x.CompletedDate).IsOptional();
            Property(x => x.CreatedDate).IsRequired();

            HasRequired(x => x.Status);
            HasRequired(x => x.CreatedBy);

            HasMany(x => x.Users)
                .WithMany(x => x.Tasks)
                .Map(x =>
                {
                    x.ToTable("TaskUser");
                    x.MapLeftKey("TaskId");
                    x.MapRightKey("UserId");
                });
        }
    }
}