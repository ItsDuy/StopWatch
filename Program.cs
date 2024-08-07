using System.Diagnostics;
namespace ClassStopWatch;
public class StopWatch
{
    private DateTime startTime;
    private DateTime endTime;

    public DateTime StartTime
    {
        get { return startTime; }
    }

    public DateTime EndTime
    {
        get { return endTime; }
    }

    public StopWatch()
    {
        startTime = DateTime.Now;
    }

    public void Start()
    {
        startTime = DateTime.Now;
    }

    public void Stop()
    {
        endTime = DateTime.Now;
    }

    public long GetElapsedTime()
    {
        return (long)(endTime - startTime).TotalMilliseconds;
    }
}
class Program
{
    static void Main(string[] args)
    {
        int[] array = new int[100000];
        Random rand = new Random();

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(1, 100000);
        }

        StopWatch stopWatch = new StopWatch();
        stopWatch.Start();

        SelectionSort(array);

        stopWatch.Stop();
        Console.WriteLine($"Elapsed time: {stopWatch.GetElapsedTime()} milliseconds");
    }

    static void SelectionSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (array[j] < array[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = array[minIndex];
            array[minIndex] = array[i];
            array[i] = temp;
        }
    }
}
