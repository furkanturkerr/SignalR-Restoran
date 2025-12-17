namespace SignalRWebUI.Dtos.FoodRapidApiDtos;

public class RootTastyApi
{
    public List<ResultTastyApi> results { get; set; }
}
public class ResultTastyApi
{
    public string Name { get; set; }
    public string original_video_url{ get; set; }
    public string total_time_minutes { get; set; }
    public string thumbnail_url { get; set; }
}