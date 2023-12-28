using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace SyncfusionBlazorGridEvents.Components;
public partial class GridEventsNotificationList {

    [Inject]
    public required IJSRuntime JSRuntime { get; set; }

    [CascadingParameter]
    public required List<GridEventNotification> GridEventNotifications { get; set; }

    [Parameter]
    public EventCallback OnTypeChanged { get; set; }
    private void NotifyTypeChange() {
        OnTypeChanged.InvokeAsync();
    }

    private SfGrid<GridEventNotification> _grid = default!;

    private NotificationType? _notificationType;

    public static List<DropdownItem> NotificationTypes => Enum.GetNames(typeof(NotificationType))
                                                              .Select(name => new DropdownItem { Text = name, Value = (NotificationType)Enum.Parse(typeof(NotificationType), name) })
                                                              .ToList();

    public class DropdownItem {
        public required string Text { get; init; }
        public required NotificationType Value { get; set; }
    }

    private void OnValueChanged(NotificationType notificationType) {
        _notificationType = notificationType;
    }

    private async Task OnActionCompleteHandlerAsync(ActionEventArgs<GridEventNotification> args) {
        if (args.RequestType == SG.Action.Save && _notificationType.HasValue) {
            List<GridEventNotification> selectedGridEventNotifications = await _grid.GetSelectedRecordsAsync();
            foreach (GridEventNotification gridEventNotification in selectedGridEventNotifications) {
                if (gridEventNotification.Type != _notificationType.Value) {
                    gridEventNotification.Type = _notificationType.Value;
                }
            }
            NotifyTypeChange();
            _notificationType = null;
            await _grid.Refresh();
        } else if (args.RequestType == SG.Action.BeginEdit) {
            await FocusAndOpenDropdownAsync();
        }
    }

    private async Task OnActionBeginHandlerAsync(ActionEventArgs<GridEventNotification> args) {
        if (args.RequestType == SG.Action.BeginEdit) {
            await JSRuntime.InvokeVoidAsync("addClassWhenDialogVisible", "eventnotifications-grid_dialogEdit_wrapper", "hidden-first-row");
            await UpdateDialogTitleAsync(_grid.SelectedRecords.Count);
        }
    }

    public async Task UpdateDialogTitleAsync(int eventCount) {
        string title = $"Notification Type for {eventCount} event{(eventCount > 1 ? "s" : "")}";
        await JSRuntime.InvokeVoidAsync("updateDialogTitleWhenAvailable", "eventnotifications-grid_dialogEdit_wrapper_title", title);
    }

    public async Task FocusAndOpenDropdownAsync() {
        await JSRuntime.InvokeVoidAsync("focusAndOpenDropdownWhenVisible");
    }

}
