namespace SyncfusionBlazorGridEvents.Models; 
public class GridEventNotification {
    public required GridEvent Event { get; init; }
    public required NotificationType Type { get; set; }

}
