
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Detail> Details = new List<Detail>();

        public MainWindow()
        {
            InitializeComponent();

            for(int i = 0; i< 5; i++)
            {
                Details.Add( new Detail());
            }

            grid.ItemsSource = Details;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach(var detail in Details)
            {
                detail.SetValueAtSelected(true);
            }

            UnSelectAll();

            grid.UpdateLayout();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (var detail in Details)
            {
                detail.SetValueAtSelected(false);
            }

            UnSelectAll();

            grid.UpdateLayout();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UnSelectAll();
        }

        private void grid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DeleteAllSelecting();

            foreach (var cellInfo in grid.SelectedCells)
            {
                var detail = cellInfo.Item as Detail;
                detail?.SetSelecting(cellInfo.Column.DisplayIndex);
            }
        }

        private void UnSelectAll()
        {
            foreach(var detail in Details)
            {
                detail.UnSelecteAll();
            }
        }

        private void grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (grid.SelectedCells.Count == 1)
            {
                var detail = grid.SelectedCells[0].Item as Detail;
                detail?.SwitchSelected(grid.SelectedCells[0].Column.DisplayIndex);
            }
            else
            {
                foreach (var cellInfo in grid.SelectedCells)
                {
                    var detail = cellInfo.Item as Detail;
                    detail?.SelectForce(cellInfo.Column.DisplayIndex);
                }
            }

            DeleteAllSelecting();

            grid.UnselectAllCells();

            grid.UpdateLayout();
        }

        private void DeleteAllSelecting()
        {
            foreach (var detail in Details)
            {
                detail.DeleteAllSelecting();
            }
        }
    }

    class Detail : INotifyPropertyChanged
    {
        #region v1
        private bool _v1;

        public bool v1
        {
            get
            { return _v1; }
            set
            { 
                if (_v1 == value)
                    return;
                _v1 = value;
                RaisePropertyChanged();
            }
        }


        private bool _v1Selected;

        public bool v1Selected
        {
            get
            { return _v1Selected; }
            set
            { 
                if (_v1Selected == value)
                    return;
                _v1Selected = value;
                RaisePropertyChanged();
            }
        }


        private bool _v1Selecting;

        public bool v1Selecting
        {
            get
            { return _v1Selecting; }
            set
            {
                if (_v1Selecting == value)
                    return;
                _v1Selecting = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region v2
        private bool _v2;

        public bool v2
        {
            get
            { return _v2; }
            set
            {
                if (_v2 == value)
                    return;
                _v2 = value;
                RaisePropertyChanged();
            }
        }


        private bool _v2Selected;

        public bool v2Selected
        {
            get
            { return _v2Selected; }
            set
            {
                if (_v2Selected == value)
                    return;
                _v2Selected = value;
                RaisePropertyChanged();
            }
        }


        private bool _v2Selecting;

        public bool v2Selecting
        {
            get
            { return _v2Selecting; }
            set
            {
                if (_v2Selecting == value)
                    return;
                _v2Selecting = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region v3
        private bool _v3;

        public bool v3
        {
            get
            { return _v3; }
            set
            {
                if (_v3 == value)
                    return;
                _v3 = value;
                RaisePropertyChanged();
            }
        }


        private bool _v3Selected;

        public bool v3Selected
        {
            get
            { return _v3Selected; }
            set
            {
                if (_v3Selected == value)
                    return;
                _v3Selected = value;
                RaisePropertyChanged();
            }
        }


        private bool _v3Selecting;

        public bool v3Selecting
        {
            get
            { return _v3Selecting; }
            set
            {
                if (_v3Selecting == value)
                    return;
                _v3Selecting = value;
                RaisePropertyChanged();
            }
        }

        #endregion


        public event PropertyChangedEventHandler? PropertyChanged;

        public void SetValueAtSelected(bool value)
        {
            if (v1Selected)
            {
                v1 = value;
            }
            if (v2Selected)
            {
                v2 = value;
            }
            if (v3Selected)
            {
                v3 = value;
            }
        }

        public void UnSelecteAll()
        {
            v1Selected = false;
            v2Selected = false;
            v3Selected = false;
        }

        public void SelectForce(int index)
        {
            switch (index)
            {
                case 0:
                    v1Selected = true;
                    break;
                case 1:
                    v2Selected = true;
                    break;
                case 2:
                    v3Selected = true;
                    break;

                default:
                    throw new ArgumentException("", nameof(index));
            }
        }

        public void SwitchSelected(int index)
        {
            switch (index)
            {
                case 0:
                    v1Selected = !v1Selected;
                    break;
                case 1:
                    v2Selected = !v2Selected;
                    break;
                case 2:
                    v3Selected = !v3Selected;
                    break;

                default:
                    throw new ArgumentException("", nameof(index));
            }
        }

        public void SetSelecting(int index)
        {
            switch (index)
            {
                case 0:
                    v1Selecting = true;
                    break;
                case 1:
                    v2Selecting = true;
                    break;
                case 2:
                    v3Selecting = true;
                    break;

                default:
                    throw new ArgumentException("", nameof(index));
            }
        }

        public void DeleteAllSelecting()
        {
            v1Selecting = false;
            v2Selecting = false;
            v3Selecting = false;
        }

        void RaisePropertyChanged([CallerMemberName] string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
