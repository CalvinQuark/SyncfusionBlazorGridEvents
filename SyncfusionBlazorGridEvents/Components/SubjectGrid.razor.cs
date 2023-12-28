using Microsoft.AspNetCore.Components;
using SyncfusionBlazorGridEvents.Models;

namespace SyncfusionBlazorGridEvents.Components;
public partial class SubjectGrid {

    private static readonly JsonSerializerOptions _jsonSerializerOptions = new() { WriteIndented = true };

    public required SfGrid<GeoItem> _grid;

    public List<GeoItem> Items { get; private set; } = default!;

    [CascadingParameter]
    public required List<GridEventNotification> GridEventNotifications { get; set; }

    protected override void OnInitialized() {
        Items = new GeoData().GeographyItems;
        GridEventNotifications.AddRange(_gridEventNotifications);
        WireUpGridEvents();
        base.OnInitialized();
    }

    public void HandleTypeChange() {
        WireUpGridEvents();
    }

    private void WireUpGridEvents() {
        IEnumerable<GridEvent> reportingGridEvents = _gridEventNotifications.Where(_ => _.Type != NotificationType.None).Select(_ => _.Event);
        if (!reportingGridEvents.Any()) {
            return;
        }
        GridEvents<GeoItem> gridEvents = new();
#pragma warning disable BL0005 // Component parameter should not be set outside of its component.
        foreach (GridEvent reportingGridEvent in reportingGridEvents) {
            switch (reportingGridEvent) {
                case GridEvent.BeforeAutoFillCell:
                    gridEvents.BeforeAutoFillCell = EventCallback.Factory.Create<BeforeAutoFillCellEventArgs<GeoItem>>(this, BeforeAutoFillCellHandler);
                    break;
                case GridEvent.BeforeAutoFill:
                    gridEvents.BeforeAutoFill = EventCallback.Factory.Create<BeforeAutoFillEventArgs>(this, BeforeAutoFillHandler);
                    break;
                case GridEvent.BeforeCellPaste:
                    gridEvents.BeforeCellPaste = EventCallback.Factory.Create<BeforeCellPasteEventArgs<GeoItem>>(this, BeforeCellPasteHandler);
                    break;
                case GridEvent.BeforeCopyPaste:
                    gridEvents.BeforeCopyPaste = EventCallback.Factory.Create<BeforeCopyPasteEventArgs>(this, BeforeCopyPasteHandler);
                    break;
                case GridEvent.BeforeOpenColumnChooser:
                    gridEvents.BeforeOpenColumnChooser = EventCallback.Factory.Create<ColumnChooserEventArgs>(this, BeforeOpenColumnChooserHandler);
                    break;
                case GridEvent.CellDeselected:
                    gridEvents.CellDeselected = EventCallback.Factory.Create<CellDeselectEventArgs<GeoItem>>(this, CellDeselectedHandler);
                    break;
                case GridEvent.CellDeselecting:
                    gridEvents.CellDeselecting = EventCallback.Factory.Create<CellDeselectEventArgs<GeoItem>>(this, CellDeselectingHandler);
                    break;
                case GridEvent.CellSaved:
                    gridEvents.CellSaved = EventCallback.Factory.Create<CellSaveArgs<GeoItem>>(this, CellSavedHandler);
                    break;
                case GridEvent.CellSelected:
                    gridEvents.CellSelected = EventCallback.Factory.Create<CellSelectEventArgs<GeoItem>>(this, CellSelectedHandler);
                    break;
                case GridEvent.CellSelecting:
                    gridEvents.CellSelecting = EventCallback.Factory.Create<CellSelectingEventArgs<GeoItem>>(this, CellSelectingHandler);
                    break;
                case GridEvent.CheckboxFilterSearching:
                    gridEvents.CheckboxFilterSearching = EventCallback.Factory.Create<CheckboxFilterSearchingEventArgs>(this, CheckboxFilterSearchingHandler);
                    break;
                case GridEvent.ColumnMenuItemClicked:
                    gridEvents.ColumnMenuItemClicked = EventCallback.Factory.Create<ColumnMenuClickEventArgs>(this, ColumnMenuItemClickedHandler);
                    break;
                case GridEvent.ColumnReordered:
                    gridEvents.ColumnReordered = EventCallback.Factory.Create<ColumnReorderedEventArgs>(this, ColumnReorderedHandler);
                    break;
                case GridEvent.ColumnReordering:
                    gridEvents.ColumnReordering = EventCallback.Factory.Create<ColumnReorderingEventArgs>(this, ColumnReorderingHandler);
                    break;
                case GridEvent.ColumnVisibilityChanged:
                    gridEvents.ColumnVisibilityChanged = EventCallback.Factory.Create<ColumnVisibilityChangedEventArgs>(this, ColumnVisibilityChangedHandler);
                    break;
                case GridEvent.ColumnVisibilityChanging:
                    gridEvents.ColumnVisibilityChanging = EventCallback.Factory.Create<ColumnVisibilityChangingEventArgs>(this, ColumnVisibilityChangingHandler);
                    break;
                case GridEvent.CommandClicked:
                    gridEvents.CommandClicked = EventCallback.Factory.Create<CommandClickEventArgs<GeoItem>>(this, CommandClickedHandler);
                    break;
                case GridEvent.ContextMenuItemClicked:
                    gridEvents.ContextMenuItemClicked = EventCallback.Factory.Create<ContextMenuClickEventArgs<GeoItem>>(this, ContextMenuItemClickedHandler);
                    break;
                case GridEvent.ContextMenuOpen:
                    gridEvents.ContextMenuOpen = EventCallback.Factory.Create<ContextMenuOpenEventArgs<GeoItem>>(this, ContextMenuOpenHandler);
                    break;
                case GridEvent.Created:
                    gridEvents.Created = EventCallback.Factory.Create<object>(this, CreatedHandler);
                    break;
                case GridEvent.DataBound:
                    gridEvents.DataBound = EventCallback.Factory.Create<object>(this, DataBoundHandler);
                    break;
                case GridEvent.Destroyed:
                    gridEvents.Destroyed = EventCallback.Factory.Create<object>(this, DestroyedHandler);
                    break;
                case GridEvent.DetailDataBound:
                    gridEvents.DetailDataBound = EventCallback.Factory.Create<DetailDataBoundEventArgs<GeoItem>>(this, DetailDataBoundHandler);
                    break;
                case GridEvent.DetailsCollapsed:
                    gridEvents.DetailsCollapsed = EventCallback.Factory.Create<DetailsCollapsedEventArgs<GeoItem>>(this, DetailsCollapsedHandler);
                    break;
                case GridEvent.DetailsCollapsing:
                    gridEvents.DetailsCollapsing = EventCallback.Factory.Create<DetailsCollapsingEventArgs<GeoItem>>(this, DetailsCollapsingHandler);
                    break;
                case GridEvent.DetailsExpanded:
                    gridEvents.DetailsExpanded = EventCallback.Factory.Create<DetailsExpandedEventArgs<GeoItem>>(this, DetailsExpandedHandler);
                    break;
                case GridEvent.DetailsExpanding:
                    gridEvents.DetailsExpanding = EventCallback.Factory.Create<DetailsExpandingEventArgs<GeoItem>>(this, DetailsExpandingHandler);
                    break;
                case GridEvent.EditCanceled:
                    gridEvents.EditCanceled = EventCallback.Factory.Create<EditCanceledEventArgs<GeoItem>>(this, EditCanceledHandler);
                    break;
                case GridEvent.EditCanceling:
                    gridEvents.EditCanceling = EventCallback.Factory.Create<EditCancelingEventArgs<GeoItem>>(this, EditCancelingHandler);
                    break;
                case GridEvent.ExcelAggregateTemplateInfo:
                    gridEvents.ExcelAggregateTemplateInfo = ExcelAggregateTemplateInfoHandler;
                    break;
                case GridEvent.ExcelGroupCaptionTemplateInfo:
                    gridEvents.ExcelGroupCaptionTemplateInfo = ExcelGroupCaptionTemplateInfoHandler;
                    break;
                case GridEvent.ExcelHeaderQueryCellInfoEvent:
                    gridEvents.ExcelHeaderQueryCellInfoEvent = ExcelHeaderQueryCellInfoEventHandler;
                    break;
                case GridEvent.ExcelQueryCellInfoEvent:
                    gridEvents.ExcelQueryCellInfoEvent = ExcelQueryCellInfoEventHandler;
                    break;
                case GridEvent.ExportComplete:
                    gridEvents.ExportComplete = ExportCompleteHandler;
                    break;
                case GridEvent.FilterDialogOpened:
                    gridEvents.FilterDialogOpened = EventCallback.Factory.Create<FilterDialogOpenedEventArgs>(this, FilterDialogOpenedHandler);
                    break;
                case GridEvent.FilterDialogOpening:
                    gridEvents.FilterDialogOpening = EventCallback.Factory.Create<FilterDialogOpeningEventArgs>(this, FilterDialogOpeningHandler);
                    break;
                case GridEvent.Filtered:
                    gridEvents.Filtered = EventCallback.Factory.Create<FilteredEventArgs>(this, FilteredHandler);
                    break;
                case GridEvent.Filtering:
                    gridEvents.Filtering = EventCallback.Factory.Create<FilteringEventArgs>(this, FilteringHandler);
                    break;
                case GridEvent.FreezeLineMoved:
                    gridEvents.FreezeLineMoved = EventCallback.Factory.Create<FreezeLineMovedEventArgs>(this, FreezeLineMovedHandler);
                    break;
                case GridEvent.FreezeLineMoving:
                    gridEvents.FreezeLineMoving = EventCallback.Factory.Create<FreezeLineMovingEventArgs>(this, FreezeLineMovingHandler);
                    break;
                case GridEvent.Grouped:
                    gridEvents.Grouped = EventCallback.Factory.Create<GroupedEventArgs>(this, GroupedHandler);
                    break;
                case GridEvent.Grouping:
                    gridEvents.Grouping = EventCallback.Factory.Create<GroupingEventArgs>(this, GroupingHandler);
                    break;
                case GridEvent.HeaderCellInfo:
                    gridEvents.HeaderCellInfo = EventCallback.Factory.Create<HeaderCellInfoEventArgs>(this, HeaderCellInfoHandler);
                    break;
                case GridEvent.OnActionBegin:
                    gridEvents.OnActionBegin = EventCallback.Factory.Create<ActionEventArgs<GeoItem>>(this, OnActionBeginHandler);
                    break;
                case GridEvent.OnActionComplete:
                    gridEvents.OnActionComplete = EventCallback.Factory.Create<ActionEventArgs<GeoItem>>(this, OnActionCompleteHandler);
                    break;
                case GridEvent.OnActionFailure:
                    gridEvents.OnActionFailure = EventCallback.Factory.Create<FailureEventArgs>(this, OnActionFailureHandler);
                    break;
                case GridEvent.OnBatchAdd:
                    gridEvents.OnBatchAdd = EventCallback.Factory.Create<BeforeBatchAddArgs<GeoItem>>(this, OnBatchAddHandler);
                    break;
                case GridEvent.OnBatchCancel:
                    gridEvents.OnBatchCancel = EventCallback.Factory.Create<BeforeBatchCancelArgs<GeoItem>>(this, OnBatchCancelHandler);
                    break;
                case GridEvent.OnBatchDelete:
                    gridEvents.OnBatchDelete = EventCallback.Factory.Create<BeforeBatchDeleteArgs<GeoItem>>(this, OnBatchDeleteHandler);
                    break;
                case GridEvent.OnBatchSave:
                    gridEvents.OnBatchSave = EventCallback.Factory.Create<BeforeBatchSaveArgs<GeoItem>>(this, OnBatchSaveHandler);
                    break;
                case GridEvent.OnBeginEdit:
                    gridEvents.OnBeginEdit = EventCallback.Factory.Create<BeginEditArgs<GeoItem>>(this, OnBeginEditHandler);
                    break;
                case GridEvent.OnCellEdit:
                    gridEvents.OnCellEdit = EventCallback.Factory.Create<CellEditArgs<GeoItem>>(this, OnCellEditHandler);
                    break;
                case GridEvent.OnCellSave:
                    gridEvents.OnCellSave = EventCallback.Factory.Create<CellSaveArgs<GeoItem>>(this, OnCellSaveHandler);
                    break;
                case GridEvent.OnColumnMenuOpen:
                    gridEvents.OnColumnMenuOpen = EventCallback.Factory.Create<ColumnMenuOpenEventArgs>(this, OnColumnMenuOpenHandler);
                    break;
                case GridEvent.OnDataBound:
                    gridEvents.OnDataBound = EventCallback.Factory.Create<BeforeDataBoundArgs<GeoItem>>(this, OnDataBoundHandler);
                    break;
                case GridEvent.OnExcelExport:
                    gridEvents.OnExcelExport = OnExcelExportHandler;
                    break;
                case GridEvent.OnLoad:
                    gridEvents.OnLoad = EventCallback.Factory.Create<object>(this, OnLoadHandler);
                    break;
                case GridEvent.OnPdfExport:
                    gridEvents.OnPdfExport = OnPdfExportHandler;
                    break;
                case GridEvent.OnRecordClick:
                    gridEvents.OnRecordClick = EventCallback.Factory.Create<RecordClickEventArgs<GeoItem>>(this, OnRecordClickHandler);
                    break;
                case GridEvent.OnRecordDoubleClick:
                    gridEvents.OnRecordDoubleClick = EventCallback.Factory.Create<RecordDoubleClickEventArgs<GeoItem>>(this, OnRecordDoubleClickHandler);
                    break;
                case GridEvent.OnResizeStart:
                    gridEvents.OnResizeStart = EventCallback.Factory.Create<ResizeArgs>(this, OnResizeStartHandler);
                    break;
                case GridEvent.OnRowEditStart:
                    gridEvents.OnRowEditStart = EventCallback.Factory.Create<OnRowEditStartEventArgs>(this, OnRowEditStartHandler);
                    break;
                case GridEvent.OnToolbarClick:
                    gridEvents.OnToolbarClick = EventCallback.Factory.Create<SN.ClickEventArgs>(this, OnToolbarClickHandler);
                    break;
                case GridEvent.PageChanged:
                    gridEvents.PageChanged = EventCallback.Factory.Create<GridPageChangedEventArgs>(this, PageChangedHandler);
                    break;
                case GridEvent.PageChanging:
                    gridEvents.PageChanging = EventCallback.Factory.Create<GridPageChangingEventArgs>(this, PageChangingHandler);
                    break;
                case GridEvent.PdfAggregateTemplateInfo:
                    gridEvents.PdfAggregateTemplateInfo = PdfAggregateTemplateInfoHandler;
                    break;
                case GridEvent.PdfGroupCaptionTemplateInfo:
                    gridEvents.PdfGroupCaptionTemplateInfo = PdfGroupCaptionTemplateInfoHandler;
                    break;
                case GridEvent.PdfHeaderQueryCellInfoEvent:
                    gridEvents.PdfHeaderQueryCellInfoEvent = PdfHeaderQueryCellInfoEventHandler;
                    break;
                case GridEvent.PdfQueryCellInfoEvent:
                    gridEvents.PdfQueryCellInfoEvent = PdfQueryCellInfoEventHandler;
                    break;
                case GridEvent.QueryCellInfo:
                    gridEvents.QueryCellInfo = EventCallback.Factory.Create<QueryCellInfoEventArgs<GeoItem>>(this, QueryCellInfoHandler);
                    break;
                case GridEvent.ResizeStopped:
                    gridEvents.ResizeStopped = EventCallback.Factory.Create<ResizeArgs>(this, ResizeStoppedHandler);
                    break;
                case GridEvent.RowCreated:
                    gridEvents.RowCreated = EventCallback.Factory.Create<RowCreatedEventArgs<GeoItem>>(this, RowCreatedHandler);
                    break;
                case GridEvent.RowCreating:
                    gridEvents.RowCreating = EventCallback.Factory.Create<RowCreatingEventArgs<GeoItem>>(this, RowCreatingHandler);
                    break;
                case GridEvent.RowDataBound:
                    gridEvents.RowDataBound = EventCallback.Factory.Create<RowDataBoundEventArgs<GeoItem>>(this, RowDataBoundHandler);
                    break;
                case GridEvent.RowDeleted:
                    gridEvents.RowDeleted = EventCallback.Factory.Create<RowDeletedEventArgs<GeoItem>>(this, RowDeletedHandler);
                    break;
                case GridEvent.RowDeleting:
                    gridEvents.RowDeleting = EventCallback.Factory.Create<RowDeletingEventArgs<GeoItem>>(this, RowDeletingHandler);
                    break;
                case GridEvent.RowDeselected:
                    gridEvents.RowDeselected = EventCallback.Factory.Create<RowDeselectEventArgs<GeoItem>>(this, RowDeselectedHandler);
                    break;
                case GridEvent.RowDeselecting:
                    gridEvents.RowDeselecting = EventCallback.Factory.Create<RowDeselectEventArgs<GeoItem>>(this, RowDeselectingHandler);
                    break;
                case GridEvent.RowDragStarting:
                    gridEvents.RowDragStarting = EventCallback.Factory.Create<RowDragStartingEventArgs<GeoItem>>(this, RowDragStartingHandler);
                    break;
                case GridEvent.RowDropped:
                    gridEvents.RowDropped = EventCallback.Factory.Create<RowDroppedEventArgs<GeoItem>>(this, RowDroppedHandler);
                    break;
                case GridEvent.RowDropping:
                    gridEvents.RowDropping = EventCallback.Factory.Create<RowDroppingEventArgs<GeoItem>>(this, RowDroppingHandler);
                    break;
                case GridEvent.RowEdited:
                    gridEvents.RowEdited = EventCallback.Factory.Create<RowEditedEventArgs<GeoItem>>(this, RowEditedHandler);
                    break;
                case GridEvent.RowEditing:
                    gridEvents.RowEditing = EventCallback.Factory.Create<RowEditingEventArgs<GeoItem>>(this, RowEditingHandler);
                    break;
                case GridEvent.RowSelected:
                    gridEvents.RowSelected = EventCallback.Factory.Create<RowSelectEventArgs<GeoItem>>(this, RowSelectedHandler);
                    break;
                case GridEvent.RowSelecting:
                    gridEvents.RowSelecting = EventCallback.Factory.Create<RowSelectingEventArgs<GeoItem>>(this, RowSelectingHandler);
                    break;
                case GridEvent.RowUpdated:
                    gridEvents.RowUpdated = EventCallback.Factory.Create<RowUpdatedEventArgs<GeoItem>>(this, RowUpdatedHandler);
                    break;
                case GridEvent.RowUpdating:
                    gridEvents.RowUpdating = EventCallback.Factory.Create<RowUpdatingEventArgs<GeoItem>>(this, RowUpdatingHandler);
                    break;
                case GridEvent.Searched:
                    gridEvents.Searched = EventCallback.Factory.Create<SearchedEventArgs>(this, SearchedHandler);
                    break;
                case GridEvent.Searching:
                    gridEvents.Searching = EventCallback.Factory.Create<SearchingEventArgs>(this, SearchingHandler);
                    break;
                case GridEvent.Sorted:
                    gridEvents.Sorted = EventCallback.Factory.Create<SortedEventArgs>(this, SortedHandler);
                    break;
                case GridEvent.Sorting:
                    gridEvents.Sorting = EventCallback.Factory.Create<SortingEventArgs>(this, SortingHandler);
                    break;
                default:
                    break;
            }
        }
        _grid.GridEvents = gridEvents;
#pragma warning restore BL0005 // Component parameter should not be set outside of its component.
    }

    private static void NotifyGridEvent<TArgs>(GridEvent gridEvent, TArgs args) {
        GridEventNotification? gridEventNotification = _gridEventNotifications.Where(_ => _.Event == gridEvent).FirstOrDefault();
        if (gridEventNotification is null) {
            throw new ApplicationException($"GridEventNotification for `{gridEvent}` not found");
        } else if (gridEventNotification.Type == NotificationType.None) {
            return;
        } else {
            WriteEventName(gridEvent);
            if (gridEventNotification.Type == NotificationType.NameAndArguments) {
                WriteEventArguments(args);
            }
        }

        static void WriteEventName(GridEvent gridEvent) {
            Console.WriteLine(gridEvent.ToString());
        }

        static void WriteEventArguments(TArgs args) {
            Console.WriteLine(JsonSerializer.Serialize<TArgs>(args, _jsonSerializerOptions));
        }
    }

    private static void BeforeAutoFillCellHandler(BeforeAutoFillCellEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.BeforeAutoFillCell, args); }
    private static void BeforeAutoFillHandler(BeforeAutoFillEventArgs args) { NotifyGridEvent(GridEvent.BeforeAutoFill, args); }
    private static void BeforeCellPasteHandler(BeforeCellPasteEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.BeforeCellPaste, args); }
    private static void BeforeCopyPasteHandler(BeforeCopyPasteEventArgs args) { NotifyGridEvent(GridEvent.BeforeCopyPaste, args); }
    private static void BeforeOpenColumnChooserHandler(ColumnChooserEventArgs args) { NotifyGridEvent(GridEvent.BeforeOpenColumnChooser, args); }
    private static void CellDeselectedHandler(CellDeselectEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.CellDeselected, args); }
    private static void CellDeselectingHandler(CellDeselectEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.CellDeselecting, args); }
    private static void CellSavedHandler(CellSaveArgs<GeoItem> args) { NotifyGridEvent(GridEvent.CellSaved, args); }
    private static void CellSelectedHandler(CellSelectEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.CellSelected, args); }
    private static void CellSelectingHandler(CellSelectingEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.CellSelecting, args); }
    private static void CheckboxFilterSearchingHandler(CheckboxFilterSearchingEventArgs args) { NotifyGridEvent(GridEvent.CheckboxFilterSearching, args); }
    private static void ColumnMenuItemClickedHandler(ColumnMenuClickEventArgs args) { NotifyGridEvent(GridEvent.ColumnMenuItemClicked, args); }
    private static void ColumnReorderedHandler(ColumnReorderedEventArgs args) { NotifyGridEvent(GridEvent.ColumnReordered, args); }
    private static void ColumnReorderingHandler(ColumnReorderingEventArgs args) { NotifyGridEvent(GridEvent.ColumnReordering, args); }
    private static void ColumnVisibilityChangedHandler(ColumnVisibilityChangedEventArgs args) { NotifyGridEvent(GridEvent.ColumnVisibilityChanged, args); }
    private static void ColumnVisibilityChangingHandler(ColumnVisibilityChangingEventArgs args) { NotifyGridEvent(GridEvent.ColumnVisibilityChanging, args); }
    private static void CommandClickedHandler(CommandClickEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.CommandClicked, args); }
    private static void ContextMenuItemClickedHandler(ContextMenuClickEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.ContextMenuItemClicked, args); }
    private static void ContextMenuOpenHandler(ContextMenuOpenEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.ContextMenuOpen, args); }
    private static void CreatedHandler(object args) { NotifyGridEvent(GridEvent.Created, args); }
    private static void DataBoundHandler(object args) { NotifyGridEvent(GridEvent.DataBound, args); }
    private static void DestroyedHandler(object args) { NotifyGridEvent(GridEvent.Destroyed, args); }
    private static void DetailDataBoundHandler(DetailDataBoundEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.DetailDataBound, args); }
    private static void DetailsCollapsedHandler(DetailsCollapsedEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.DetailsCollapsed, args); }
    private static void DetailsCollapsingHandler(DetailsCollapsingEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.DetailsCollapsing, args); }
    private static void DetailsExpandedHandler(DetailsExpandedEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.DetailsExpanded, args); }
    private static void DetailsExpandingHandler(DetailsExpandingEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.DetailsExpanding, args); }
    private static void EditCanceledHandler(EditCanceledEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.EditCanceled, args); }
    private static void EditCancelingHandler(EditCancelingEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.EditCanceling, args); }
    private static void ExcelAggregateTemplateInfoHandler(ExcelAggregateEventArgs args) { NotifyGridEvent(GridEvent.ExcelAggregateTemplateInfo, args); }
    private static void ExcelGroupCaptionTemplateInfoHandler(ExcelCaptionTemplateArgs args) { NotifyGridEvent(GridEvent.ExcelAggregateTemplateInfo, args); }
    private static void ExcelHeaderQueryCellInfoEventHandler(ExcelHeaderQueryCellInfoEventArgs args) { NotifyGridEvent(GridEvent.ExcelHeaderQueryCellInfoEvent, args); }
    private static void ExcelQueryCellInfoEventHandler(ExcelQueryCellInfoEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.ExcelQueryCellInfoEvent, args); }
    private static void ExportCompleteHandler(object args) { NotifyGridEvent(GridEvent.ExportComplete, args); }
    private static void FilterDialogOpenedHandler(FilterDialogOpenedEventArgs args) { NotifyGridEvent(GridEvent.FilterDialogOpened, args); }
    private static void FilterDialogOpeningHandler(FilterDialogOpeningEventArgs args) { NotifyGridEvent(GridEvent.FilterDialogOpening, args); }
    private static void FilteredHandler(FilteredEventArgs args) { NotifyGridEvent(GridEvent.Filtered, args); }
    private static void FilteringHandler(FilteringEventArgs args) { NotifyGridEvent(GridEvent.Filtering, args); }
    private static void FreezeLineMovedHandler(FreezeLineMovedEventArgs args) { NotifyGridEvent(GridEvent.FreezeLineMoved, args); }
    private static void FreezeLineMovingHandler(FreezeLineMovingEventArgs args) { NotifyGridEvent(GridEvent.FreezeLineMoving, args); }
    private static void GroupedHandler(GroupedEventArgs args) { NotifyGridEvent(GridEvent.Grouped, args); }
    private static void GroupingHandler(GroupingEventArgs args) { NotifyGridEvent(GridEvent.Grouping, args); }
    private static void HeaderCellInfoHandler(HeaderCellInfoEventArgs args) { NotifyGridEvent(GridEvent.HeaderCellInfo, args); }
    private static void OnActionBeginHandler(ActionEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.OnActionBegin, args); }
    private static void OnActionCompleteHandler(ActionEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.OnActionComplete, args); }
    private static void OnActionFailureHandler(FailureEventArgs args) { NotifyGridEvent(GridEvent.OnActionFailure, args); }
    private static void OnBatchAddHandler(BeforeBatchAddArgs<GeoItem> args) { NotifyGridEvent(GridEvent.OnBatchAdd, args); }
    private static void OnBatchCancelHandler(BeforeBatchCancelArgs<GeoItem> args) { NotifyGridEvent(GridEvent.OnBatchCancel, args); }
    private static void OnBatchDeleteHandler(BeforeBatchDeleteArgs<GeoItem> args) { NotifyGridEvent(GridEvent.OnBatchDelete, args); }
    private static void OnBatchSaveHandler(BeforeBatchSaveArgs<GeoItem> args) { NotifyGridEvent(GridEvent.OnBatchSave, args); }
    private static void OnBeginEditHandler(BeginEditArgs<GeoItem> args) { NotifyGridEvent(GridEvent.OnBeginEdit, args); }
    private static void OnCellEditHandler(CellEditArgs<GeoItem> args) { NotifyGridEvent(GridEvent.OnCellEdit, args); }
    private static void OnCellSaveHandler(CellSaveArgs<GeoItem> args) { NotifyGridEvent(GridEvent.OnCellSave, args); }
    private static void OnColumnMenuOpenHandler(ColumnMenuOpenEventArgs args) { NotifyGridEvent(GridEvent.OnColumnMenuOpen, args); }
    private static void OnDataBoundHandler(BeforeDataBoundArgs<GeoItem> args) { NotifyGridEvent(GridEvent.OnDataBound, args); }
    private static void OnExcelExportHandler(object args) { NotifyGridEvent(GridEvent.OnExcelExport, args); }
    private static void OnLoadHandler(object args) { NotifyGridEvent(GridEvent.OnLoad, args); }
    private static void OnPdfExportHandler(object args) { NotifyGridEvent(GridEvent.OnPdfExport, args); }
    private static void OnRecordClickHandler(RecordClickEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.OnRecordClick, args); }
    private static void OnRecordDoubleClickHandler(RecordDoubleClickEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.OnRecordDoubleClick, args); }
    private static void OnResizeStartHandler(ResizeArgs args) { NotifyGridEvent(GridEvent.OnResizeStart, args); }
    private static void OnRowEditStartHandler(OnRowEditStartEventArgs args) { NotifyGridEvent(GridEvent.OnRowEditStart, args); }
    private static void OnToolbarClickHandler(SN.ClickEventArgs args) { NotifyGridEvent(GridEvent.OnToolbarClick, args); }
    private static void PageChangedHandler(GridPageChangedEventArgs args) { NotifyGridEvent(GridEvent.PageChanged, args); }
    private static void PageChangingHandler(GridPageChangingEventArgs args) { NotifyGridEvent(GridEvent.PageChanging, args); }
    private static void PdfAggregateTemplateInfoHandler(PdfAggregateEventArgs args) { NotifyGridEvent(GridEvent.PdfAggregateTemplateInfo, args); }
    private static void PdfGroupCaptionTemplateInfoHandler(PdfCaptionTemplateArgs args) { NotifyGridEvent(GridEvent.PdfGroupCaptionTemplateInfo, args); }
    private static void PdfHeaderQueryCellInfoEventHandler(PdfHeaderQueryCellInfoEventArgs args) { NotifyGridEvent(GridEvent.PdfHeaderQueryCellInfoEvent, args); }
    private static void PdfQueryCellInfoEventHandler(PdfQueryCellInfoEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.PdfQueryCellInfoEvent, args); }
    private static void QueryCellInfoHandler(QueryCellInfoEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.QueryCellInfo, args); }
    private static void ResizeStoppedHandler(ResizeArgs args) { NotifyGridEvent(GridEvent.ResizeStopped, args); }
    private static void RowCreatedHandler(RowCreatedEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.RowCreated, args); }
    private static void RowCreatingHandler(RowCreatingEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.RowCreating, args); }
    private static void RowDataBoundHandler(RowDataBoundEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.RowDataBound, args); }
    private static void RowDeletedHandler(RowDeletedEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.RowDeleted, args); }
    private static void RowDeletingHandler(RowDeletingEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.RowDeleting, args); }
    private static void RowDeselectedHandler(RowDeselectEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.RowDeselected, args); }
    private static void RowDeselectingHandler(RowDeselectEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.RowDeselecting, args); }
    private static void RowDragStartingHandler(RowDragStartingEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.RowDragStarting, args); }
    private static void RowDroppedHandler(RowDroppedEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.RowDropped, args); }
    private static void RowDroppingHandler(RowDroppingEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.RowDropping, args); }
    private static void RowEditedHandler(RowEditedEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.RowEdited, args); }
    private static void RowEditingHandler(RowEditingEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.RowEditing, args); }
    private static void RowSelectedHandler(RowSelectEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.RowSelected, args); }
    private static void RowSelectingHandler(RowSelectingEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.RowSelecting, args); }
    private static void RowUpdatedHandler(RowUpdatedEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.RowUpdated, args); }
    private static void RowUpdatingHandler(RowUpdatingEventArgs<GeoItem> args) { NotifyGridEvent(GridEvent.RowUpdating, args); }
    private static void SearchedHandler(SearchedEventArgs args) { NotifyGridEvent(GridEvent.Searched, args); }
    private static void SearchingHandler(SearchingEventArgs args) { NotifyGridEvent(GridEvent.Searching, args); }
    private static void SortedHandler(SortedEventArgs args) { NotifyGridEvent(GridEvent.Sorted, args); }
    private static void SortingHandler(SortingEventArgs args) { NotifyGridEvent(GridEvent.Sorting, args); }

    public static List<GridEventNotification> _gridEventNotifications = [
        new GridEventNotification() { Event = GridEvent.BeforeAutoFill, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.BeforeAutoFillCell, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.BeforeCellPaste, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.BeforeCopyPaste, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.BeforeOpenColumnChooser, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.CellDeselected, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.CellDeselecting, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.CellSaved, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.CellSelected, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.CellSelecting, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.CheckboxFilterSearching, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.ColumnMenuItemClicked, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.ColumnReordered, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.ColumnReordering, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.ColumnVisibilityChanged, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.ColumnVisibilityChanging, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.CommandClicked, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.ContextMenuItemClicked, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.ContextMenuOpen, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.Created, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.DataBound, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.Destroyed, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.DetailDataBound, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.DetailsCollapsed, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.DetailsCollapsing, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.DetailsExpanded, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.DetailsExpanding, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.EditCanceled, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.EditCanceling, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.ExcelAggregateTemplateInfo, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.ExcelGroupCaptionTemplateInfo, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.ExcelHeaderQueryCellInfoEvent, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.ExcelQueryCellInfoEvent, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.ExportComplete, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.FilterDialogOpened, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.FilterDialogOpening, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.Filtered, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.Filtering, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.FreezeLineMoved, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.FreezeLineMoving, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.Grouped, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.Grouping, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.HeaderCellInfo, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.OnActionBegin, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.OnActionComplete, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.OnActionFailure, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.OnBatchAdd, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.OnBatchCancel, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.OnBatchDelete, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.OnBatchSave, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.OnBeginEdit, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.OnCellEdit, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.OnCellSave, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.OnColumnMenuOpen, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.OnDataBound, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.OnExcelExport, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.OnLoad, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.OnPdfExport, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.OnRecordClick, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.OnRecordDoubleClick, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.OnResizeStart, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.OnRowDragStart, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.OnRowEditStart, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.OnToolbarClick, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.PageChanged, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.PageChanging, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.PdfAggregateTemplateInfo, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.PdfGroupCaptionTemplateInfo, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.PdfHeaderQueryCellInfoEvent, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.PdfQueryCellInfoEvent, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.QueryCellInfo, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.ResizeStopped, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.RowCreated, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.RowCreating, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.RowDataBound, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.RowDeleted, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.RowDeleting, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.RowDeselected, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.RowDeselecting, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.RowDragStarting, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.RowDropped, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.RowDropping, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.RowEdited, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.RowEditing, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.RowSelected, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.RowSelecting, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.RowUpdated, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.RowUpdating, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.Searched, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.Searching, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.Sorted, Type = NotificationType.None },
        new GridEventNotification() { Event = GridEvent.Sorting, Type = NotificationType.None }
    ];

}
