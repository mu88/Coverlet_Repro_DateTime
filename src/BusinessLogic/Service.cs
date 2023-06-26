namespace BusinessLogic;

public class Service
{
    public IEnumerable<DateTime> Descending(IEnumerable<Dto> dates) => InnerDescending(dates.ToList());

    private static IEnumerable<DateTime> InnerDescending(IReadOnlyCollection<Dto> dates)
    {
        var results = new List<DateTime>();
        
        foreach (Dto dto in dates.OrderByDescending(dto => dto.ActiveFrom))
        {
            results.Add(dto.ActiveFrom);
        }

        return results;
    }
}