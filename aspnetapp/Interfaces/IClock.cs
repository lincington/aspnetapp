namespace aspnetapp.Interfaces
{
    public interface IClock
    {
        Task ShowTime(DateTime currentTime);
    }
}
