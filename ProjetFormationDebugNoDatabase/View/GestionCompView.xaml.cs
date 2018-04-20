using ProjetFormationDebugNoDatabase.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetFormationDebugNoDatabase.View
{
    /// <summary>
    /// Logique d'interaction pour GestionCompView.xaml
    /// </summary>
    public partial class GestionCompView : UserControl
    {
        public GestionCompView()
        {
            InitializeComponent();



            //MessageBox.Show(ltb.SelectedItem.ToString());
            //MessageBox.Show(ltb.SelectedValue.ToString());


            //var searchBox = VisualTreeHelpers.FindAncestor<TextBox>(myDataGridCell, "SeachTextBox");
            //var specificChild = VisualTreeHelpers.FindChild<Label>(myDataGridCell, "MyCheckBoxLabel");

            //foreach (ListBox Ltb in child)
            //{
            //    if (Ltb.GetType() == typeof(ListBox))
            //    {
            //        var ltb = Ltb as ListBox;
            //        MessageBox.Show(ltb.SelectedItem.ToString());
            //        MessageBox.Show(ltb.SelectedValue.ToString());
            //    }

            //}
        }


        public static void EnumVisual(Visual parent, List<Visual> collection)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                // Get the child visual at specified index value.
                Visual childVisual = (Visual)VisualTreeHelper.GetChild(parent, i);

                // Add the child visual object to the collection.
                collection.Add(childVisual);

                // Recursively enumerate children of the child visual object.
                EnumVisual(childVisual, collection);
            }
        }

        private void GridPrincipal_Loaded(object sender, RoutedEventArgs e)
        {

            //List<Visual> res = new List<Visual>();
            //EnumVisual(GridPrincipal, res);

            //foreach(ListBox lb in res.Where(i=>i.GetType()==typeof(ListBox)))
            //{
            //    MessageBox.Show(lb.SelectedItem.ToString());
            //    MessageBox.Show(lb.SelectedValue.ToString());
            //    MessageBox.Show(lb.SelectedIndex.ToString());
            //}
        }

        //public UIElement GetFirstListBox(UIElement el)
        //{
        //    var test = VisualTreeHelpers.FindChild<ListBox>(el);

        //    if (test==null && VisualTreeHelper.GetChildrenCount(el) > 0)
        //    {
        //        test=GetFirstListBox(el) as ListBox;
        //    }
            
        //    return test;
        //}

    }
}
