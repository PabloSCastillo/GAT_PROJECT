using GAT_PROJECT.Entities;

namespace GAT_PROJECT.Repositories
{
    public interface IActivityCollection
    {
        Task InsertActivity( Activity activity);
        Task UpdateActivity(Activity activity);
        Task DeleteActivity(string id);
        Task<List<Activity>> GetAllActivities();
        Task<Activity> GetAcivityById(string id);
    }
}
