using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace ProjetFormationDebug.Behaviors
{
    public static class ListBoxHelper
    {
        public static readonly DependencyProperty SelectedItemsProperty =
                            DependencyProperty.RegisterAttached("SelectedItems",
                            typeof(IList),
                            typeof(ListBoxHelper),
                            new PropertyMetadata(new ObservableCollection<object>(), OnSelectedItemsChanged));

        public static IList GetSelectedItems(DependencyObject d)
        {
            return (IList)d.GetValue(SelectedItemsProperty);
        }

        public static void SetSelectedItems(DependencyObject d, IList value)
        {
            d.SetValue(SelectedItemsProperty, value);
        }

        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var listBox = (ListBox)d;
            ReSetSelectedItems(listBox);
            listBox.SelectionChanged += delegate
            {
                ReSetSelectedItems(listBox);
            };
        }

        private static void ReSetSelectedItems(ListBox listBox)
        {
            IList selectedItems = GetSelectedItems(listBox);
            //if (selectedItems != null)
            //{
            selectedItems.Clear();
            if (listBox.SelectedItems != null)
            {
                foreach (var item in listBox.SelectedItems)
                    selectedItems.Add(item);
            }
            //}
        }
    }

    public static class ListBoxBehavior
    {
        public static readonly DependencyProperty SelectedItemsProperty =
                  DependencyProperty.RegisterAttached("SelectedItems",
                  typeof(ObservableCollection<object>),
                  typeof(ListBoxBehavior),
                  new PropertyMetadata(null, OnSelectedItemsChanged));

        public static ObservableCollection<object> GetSelectedItems(DependencyObject d)
        {
            return (ObservableCollection<object>)d.GetValue(SelectedItemsProperty);
        }
        public static void SetSelectedItems(DependencyObject d, ObservableCollection<object> value)
        {
            d.SetValue(SelectedItemsProperty, value);
        }

        private static void OnSelectedItemsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }
    }

    public class MultiSelectionBehavior : Behavior<ListBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            if (SelectedItems != null)
            {
                AssociatedObject.SelectedItems.Clear();
                foreach (var item in SelectedItems)
                {
                    AssociatedObject.SelectedItems.Add(item);
                }
            }
        }

        public IList SelectedItems
        {
            get { return (IList)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemsProperty =
            DependencyProperty.Register("SelectedItems", typeof(IList), typeof(MultiSelectionBehavior), new UIPropertyMetadata(null, SelectedItemsChanged));

        private static void SelectedItemsChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var behavior = o as MultiSelectionBehavior;
            if (behavior == null)
                return;

            var oldValue = e.OldValue as INotifyCollectionChanged;
            var newValue = e.NewValue as INotifyCollectionChanged;

            if (oldValue != null)
            {
                oldValue.CollectionChanged -= behavior.SourceCollectionChanged;
                behavior.AssociatedObject.SelectionChanged -= behavior.ListBoxSelectionChanged;
            }
            if (newValue != null)
            {
                behavior.AssociatedObject.SelectedItems.Clear();
                foreach (var item in (IEnumerable)newValue)
                {
                    behavior.AssociatedObject.SelectedItems.Add(item);
                }

                behavior.AssociatedObject.SelectionChanged += behavior.ListBoxSelectionChanged;
                newValue.CollectionChanged += behavior.SourceCollectionChanged;
            }
        }

        private bool _isUpdatingTarget;
        private bool _isUpdatingSource;

        void SourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (_isUpdatingSource)
                return;

            try
            {
                _isUpdatingTarget = true;

                if (e.OldItems != null)
                {
                    foreach (var item in e.OldItems)
                    {
                        AssociatedObject.SelectedItems.Remove(item);
                    }
                }

                if (e.NewItems != null)
                {
                    foreach (var item in e.NewItems)
                    {
                        AssociatedObject.SelectedItems.Add(item);
                    }
                }

                if (e.Action == NotifyCollectionChangedAction.Reset)
                {
                    AssociatedObject.SelectedItems.Clear();
                }
            }
            finally
            {
                _isUpdatingTarget = false;
            }
        }

        private void ListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_isUpdatingTarget)
                return;

            var selectedItems = this.SelectedItems;
            if (selectedItems == null)
                return;

            try
            {
                _isUpdatingSource = true;

                foreach (var item in e.RemovedItems)
                {
                    selectedItems.Remove(item);
                }

                foreach (var item in e.AddedItems)
                {
                    selectedItems.Add(item);
                }
            }
            finally
            {
                _isUpdatingSource = false;
            }
        }

    }
}
