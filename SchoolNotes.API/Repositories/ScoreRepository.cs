using SchoolNotes.API.Database;
using SchoolNotes.API.Models;

namespace SchoolNotes.API.Repositories;

public class ScoreRepository(DBPostgreSQL dbContext) : Repository<Score, Guid>(dbContext)
{
}
