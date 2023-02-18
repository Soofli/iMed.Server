namespace iMed.Repos.Repositories.Contracts;

public interface ICourseRepository : IWriteRepository<Course> , IReadRepository<Course> , IScopedDependency
{
    
}