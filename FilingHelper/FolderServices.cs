using HelperUtils;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilingHelper
{
   public class FolderServices
   {
        private MAPIFolder _baseFolder = null;

        public List<MAPIFolder> Search(string target)
        {
            return search(_baseFolder, target).OrderBy(x=>x.Name).ToList() ;
        }
        private List<MAPIFolder> search(MAPIFolder folder,string target) 
        {
            List<MAPIFolder> results = new List<MAPIFolder>();
            if (folder.Name.CaseInsensitiveContains(target))
                results.Add(folder);

            foreach (MAPIFolder subfolder in folder.Folders)
                results.AddRange(search(subfolder, target));
            return results;
        }

        public List<TreeNode<FolderSelectionNode>> SearchTree(string target,bool fIncludeChildren)
        {
            List<TreeNode<FolderSelectionNode>> results = new List<TreeNode<FolderSelectionNode>>();
            foreach (MAPIFolder subfolder in _baseFolder.Folders)
            {
                TreeNode<FolderSelectionNode> node = searchTree(subfolder, target, fIncludeChildren);
                if (node!=null)
                    results.Add(node);
            }
            return results;
        }

        private TreeNode<FolderSelectionNode> searchTree(MAPIFolder folder, string target, bool fIncludeChildren)
        {

            List<TreeNode<FolderSelectionNode>> children = new List<TreeNode<FolderSelectionNode>>();
            bool found = isMatch(folder, target);
            foreach (MAPIFolder subfolder in folder.Folders)
            {
                TreeNode<FolderSelectionNode> result;
                if (fIncludeChildren && found)
                    result = getChildren(subfolder);
                else
                    result = searchTree(subfolder, target, fIncludeChildren);
                if (result!=null)
                    children.Add(result);
            }
            if (children.Count > 0 || isMatch(folder,target))
                return new TreeNode<FolderSelectionNode>(new FolderSelectionNode(folder, found),children);
            else
                return null;
        }
        private TreeNode<FolderSelectionNode> getChildren(MAPIFolder folder)
        {

            List<TreeNode<FolderSelectionNode>> children = new List<TreeNode<FolderSelectionNode>>();
            foreach (MAPIFolder subfolder in folder.Folders)
            {
                TreeNode<FolderSelectionNode> result = getChildren(subfolder);
                if (result != null)
                    children.Add(result);
            }
            return new TreeNode<FolderSelectionNode>(new FolderSelectionNode(folder,true), children);
        }

        private bool isMatch(MAPIFolder folder,string target)
        {
            return folder.Name.CaseInsensitiveContains(target) || folder.Description.CaseInsensitiveContains(target);
        }

        public FolderServices()
        {
            _baseFolder = Globals.ThisAddIn.Application.Session.GetDefaultFolder(
                Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
        }

        public Boolean isFolderSentMail(MAPIFolder folder)
        {
            MAPIFolder sentMailFolder = Globals.ThisAddIn.Application.Session.GetDefaultFolder(
                Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail);
            string target = sentMailFolder.Name;
            MAPIFolder subfolder = folder;
            while (subfolder.Parent is MAPIFolder && subfolder.Name != target)
            {
                subfolder = subfolder.Parent;
            }
            return subfolder.Name == target;
        }

        public bool isFolderinDefaultInbox(MAPIFolder folder)
        {
            MAPIFolder inboxFolder = Globals.ThisAddIn.Application.Session.GetDefaultFolder(
                Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
            string target = inboxFolder.EntryID;
            MAPIFolder subfolder = folder;
            while (subfolder.Parent is MAPIFolder && subfolder.EntryID != target)
            {
                subfolder = subfolder.Parent;
            }
            return subfolder.EntryID == target;
        }
    }

    public class FolderSelectionNode
    {
        private bool _enabled;
        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        private MAPIFolder _folder;
        public MAPIFolder Folder
        {
            get { return _folder; }
            set { _folder = value; }
        }
        // *****
        public string _path;
        public FolderSelectionNode(MAPIFolder folder,bool enabled)
        {
            _folder = folder;
            _enabled = enabled;
            _path = folder.FullFolderPath;
        }
    }

}
