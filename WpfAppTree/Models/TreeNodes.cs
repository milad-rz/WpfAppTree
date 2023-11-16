using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfAppTree.Models
{
    public class TreeNodes
    {
        public string Name { get; set; }
        public ObservableCollection<TreeNodes> Children { get; } = new ObservableCollection<TreeNodes>();

        public void AddChild(TreeNodes child)
        {
            Children.Add(child);
        }
    }
}
