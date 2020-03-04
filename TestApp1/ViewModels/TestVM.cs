using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

using Prism.Commands;

namespace TestApp1.ViewModels
{
    class TestVM : INotifyPropertyChanged
    {
        #region Constructor/INotify
        public TestVM()
        {
            ClearCommand = new DelegateCommand(OnClear, CanClear);
            Select2Command = new DelegateCommand(OnSelect2, CanSelect2);
            RefreshCommand = new DelegateCommand(OnRefresh, CanRefresh);
        }

        private static volatile TestVM instance;
        public static TestVM Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestVM();
                }
                return instance;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion Constructor/INotify

        #region Properties
        private ObservableCollection<String> items;
        public ObservableCollection<String> Items
        {
            get
            {
                if (items != null)
                    return items;

                items = new ObservableCollection<string>();
                items.Add("test 1");
                items.Add("test 2");
                items.Add("test 3");
                items.Add("test x");
                return items;
            }
        }

        private String testSelected;
        private String selectedItem;
        public String SelectedItem
        {
            get
            {
                return Items.FirstOrDefault(x =>
                x == selectedItem);
            }
            set
            {
                testSelected = value;
                selectedItem = value;

                //items = null;
                NotifyPropertyChanged("Items");
                NotifyPropertyChanged();

            }
        }
        #endregion Properties

        #region Commands
        public DelegateCommand ClearCommand { get; private set; }
        private void OnClear()
        {
            items = null;
        }
        private bool CanClear() { return true; }

        public DelegateCommand Select2Command { get; private set; }
        private void OnSelect2()
        {
            SelectedItem = items.FirstOrDefault(x => x == "test 2");
        }
        private bool CanSelect2()
        {
            return items.Contains("test 2");
        }

        public DelegateCommand RefreshCommand { get; private set; }
        private void OnRefresh()
        {
            NotifyPropertyChanged("Items");
        }
        private bool CanRefresh() { return true; }

        #endregion Commands

    }
}
