using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KLTN.Common
{
    //public class TreeNodeBaseViewModel : IEnumerable<TreeNodeBaseViewModel>
    //{
    //    public BaseViewModel Data { get; set; }
    //    public TreeNodeBaseViewModel Parent { get; set; }
    //    public ICollection<TreeNodeBaseViewModel> Child { get; set; }
    //    public string Header { get; set; }
    //    public bool IsRoot => Parent == null;
    //    public bool IsLeadf => Child.Count == 0;
    //    public int Level
    //    {
    //        get
    //        {
    //            if (IsRoot)
    //                return 0;
    //            return Parent.Level + 1;
    //        }
    //    }

    //    private ICollection<TreeNodeBaseViewModel> ElementsIndex { get; set; }

    //    public TreeNodeBaseViewModel(BaseViewModel data)
    //    {
    //        Data = data;
    //        Child = new LinkedList<TreeNodeBaseViewModel>();
    //        ElementsIndex = new LinkedList<TreeNodeBaseViewModel>();
    //        ElementsIndex.Add(this);
    //    }
    //    public override string ToString()
    //    {
    //        return Data != null ? Data.ToString() : "[data null]";
    //    }

    //    private void regisChildForSearch(TreeNodeBaseViewModel nodeBaseViewModel)
    //    {
    //        ElementsIndex.Add(nodeBaseViewModel);
    //        if(Parent != null)
    //        {
    //            Parent.regisChildForSearch(nodeBaseViewModel);
    //        }
    //    }

    //    public IEnumerator<TreeNodeBaseViewModel> GetEnumerator()
    //    {
    //        yield return this;
    //        foreach(var temp in Child)
    //        {
    //            foreach(var anyTemp in temp)
    //            {
    //                yield return anyTemp;
    //            }
    //        }
    //    }

    //    public TreeNodeBaseViewModel AddChild(BaseViewModel child, params BaseViewModel[] others)
    //    {
    //        TreeNodeBaseViewModel childNode = new TreeNodeBaseViewModel(child) { Parent = this };
    //        regisChildForSearch(childNode);
    //        childNode.Header = child.Title;
    //        if(others != null)
    //        {
    //            foreach(var temp in others)
    //            {
    //                childNode.AddChild(temp);
    //            }
    //        }
    //        return childNode;
    //    }
    //}
}
