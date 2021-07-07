using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperUtils
{
    /// <summary>
    /// Class  representing a node in a TreeView control that contain and present another object
    /// </summary>
    /// <typeparam name="T">Type of object being reprresented by each TreeView node</typeparam>
    public class TreeNode<T>:IEnumerable<TreeNode<T>>
    {
        private readonly T _value;
        private readonly List<TreeNode<T>> _children = new List<TreeNode<T>>();

        /// <summary>
        /// Constructor for initiating a node without children
        /// </summary>
        /// <param name="value">object being represented in the node</param>
        public TreeNode(T value)
        {
            _value = value;
        }
        /// <summary>
        /// Constructor for initiating a node with object and children
        /// </summary>
        /// <param name="value">object being represented in the node</param>
        /// <param name="children">List of TreeNode children</param>
        public TreeNode(T value, List<TreeNode<T>> children)
        {
            _value = value;
            _children = children;
        }

        public TreeNode<T> this[int i]
        {
            get { return _children[i]; }
        }

        public TreeNode<T> Parent { get; private set; }

        public T Value { get { return _value; } }

        /// <summary>
        /// Get children of a specific node
        /// </summary>
        public ReadOnlyCollection<TreeNode<T>> Children
        {
            get { return _children.AsReadOnly(); }
        }

        /// <summary>
        /// Create child for a specific nide
        /// </summary>
        /// <param name="value">Object represented by the new node</param>
        /// <returns></returns>
        public TreeNode<T> AddChild(T value)
        {
            var node = new TreeNode<T>(value) { Parent = this };
            _children.Add(node);
            return node;
        }

        /// <summary>
        /// Add list of objects as child nodes to a specific node
        /// </summary>
        /// <param name="Values">Objects to be added as new children</param>
        /// <returns></returns>
        public TreeNode<T>[] AddChildren(params T[] Values)
        {
            return Values.Select(AddChild).ToArray();
        }

        public bool RemoveChild(TreeNode<T> node)
        {
            return _children.Remove(node);
        }

        /// <summary>
        /// Perform a function on a node and all child nodes recursively
        /// </summary>
        /// <param name="action">Function accepting the data type for the object contained in the nodes as parameter</param>
        public void Traverse(Action<T> action)
        {
            action(Value);
            foreach (var child in _children)
                child.Traverse(action);
        }

        public IEnumerable<T> Flatten()
        {
            return new[] { Value }.Union(_children.SelectMany(x => x.Flatten()));
        }

        public IEnumerator<TreeNode<T>> GetEnumerator()
        {
            return ((IEnumerable<TreeNode<T>>)_children).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<TreeNode<T>>)_children).GetEnumerator();
        }
    }
}
