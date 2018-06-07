namespace Telerik.UI.Xaml.Controls.Primitives.DragDrop.Reorder
{
    internal interface IReorderItemsCoordinator
    {
        IReorderItemsHost Host { get; }

        int ReorderItem(int sourceIndex, IReorderItem destinationItem);
        void CommitReorderOperation(int sourceIndex, int destinationIndex);
        void CancelReorderOperation(IReorderItem sourceItem, int initialSourceIndex);
    }
}
