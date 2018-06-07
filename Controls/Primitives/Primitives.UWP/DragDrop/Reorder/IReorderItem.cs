using Windows.Foundation;
using Windows.UI.Xaml;

namespace Telerik.UI.Xaml.Controls.Primitives.DragDrop.Reorder
{
    internal interface IReorderItem
    {
        DependencyObject Visual { get; }
        int LogicalIndex { get; set; }
        Point ArrangePosition { get; set; }
        Size ActualSize { get; }
        IReorderItemsCoordinator Coordinator { get; set; }
    }
}
