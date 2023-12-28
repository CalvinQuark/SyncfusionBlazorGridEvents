using Microsoft.AspNetCore.Components;
using SyncfusionBlazorGridEvents.Components;

namespace SyncfusionBlazorGridEvents.Pages;
public partial class Home {
    private readonly List<GridEventNotification> _gridEventNotifications = [];
    public required SubjectGrid _subjectGrid;
    public required GridEventsNotificationList _gridEventsNotificationList;

    protected override void OnAfterRender(bool firstRender) {
        if (firstRender) {
#pragma warning disable BL0005 // Component parameter should not be set outside of its component.
            _gridEventsNotificationList.OnTypeChanged = EventCallback.Factory.Create(this, _subjectGrid.HandleTypeChange);
#pragma warning restore BL0005 // Component parameter should not be set outside of its component.
        }
        base.OnAfterRender(firstRender);
    }

}
