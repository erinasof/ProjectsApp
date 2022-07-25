using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProjectsApp.ViewModels
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        private ListViewModel lvm;

        public ListViewModel ListViewModel
        {
            get => lvm;
            set
            {
                if (lvm != value)
                {
                    lvm = value;
                    OnPropertyChanged("ListViewModel");
                }
            }
        }

        public virtual bool IsValid => true;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
