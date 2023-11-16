
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppTree.Commands;
using WpfAppTree.Models;

namespace WpfAppTree.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TreeNodes> TreeRoot { get; } = new ObservableCollection<TreeNodes>();

        private TreeNodes selectedNode;

        public TreeNodes SelectedNode
        {
            get { return selectedNode; }
            set
            {
                if (selectedNode != value)
                {
                    selectedNode = value;
                    OnPropertyChanged(nameof(SelectedNode));
                }
            }
        }

        public ICommand AddChildCommand { get; }

        public MainViewModel()
        {
            AddChildCommand = new RelayCommand(AddChild, CanAddChild);

            // Load initial data
            //LoadData2();
        }



        public void LoadData()
        {
            // Dummy data for demonstration purposes
            var root = new TreeNodes { Name = "Root" };


            var child1 = new TreeNodes { Name = "Child 1" };
            child1.AddChild(new TreeNodes { Name = "Child 1.1" });
            child1.AddChild(new TreeNodes { Name = "Child 1.2" });

            var child2 = new TreeNodes { Name = "Child 2" };
            child2.AddChild(new TreeNodes { Name = "Child 2.1" });
            child2.AddChild(new TreeNodes { Name = "Child 2.2" });

            root.AddChild(child1);
            root.AddChild(child2);

            TreeRoot.Add(root);
            // Populate TreeRoot with initial data
            // (same as previous examples)
        }

        private bool CanAddChild(object parameter)
        {
            return SelectedNode != null;
        }

        private void AddChild(object parameter)
        {
            if (SelectedNode != null)
            {
                var newChild = new TreeNodes { Name = "New Child" };
                SelectedNode.AddChild(newChild);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
