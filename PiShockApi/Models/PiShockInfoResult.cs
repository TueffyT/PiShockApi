namespace PiShockApi.Models {
    public record PiShockInfoResult( int Id, int ClientId, string Name, bool Paused, int MaxIntensity, int MaxDuration, bool Online );
}