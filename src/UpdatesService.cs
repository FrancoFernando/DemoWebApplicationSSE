using System.Threading.Tasks;
using System;

public record Update(string Message, string Date);

public class UpdatesService
{
    private TaskCompletionSource<Update?> _tcs = new();
    private long _id = 0;

    public void Reset()
    {
        _tcs = new TaskCompletionSource<Update?>();
    }
         
    public void NotifyNewItemAvailable()
    {
        const string DefaultDateFormatString = "yyyy-MM-ddTHH:mm:ss:ffff";
        _tcs.TrySetResult(new Update($"Update number {_id++}", DateTimeOffset.Now.ToString(DefaultDateFormatString)));
    }

    public Task<Update?> WaitForNewItem()
    {
        // Simulate some delay between Update notifications
        Task.Run(async () =>
        {
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            NotifyNewItemAvailable();
        });

        return _tcs.Task;
    }
}

