using HelperUtils;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailboxAngel.OutlookCommon
{
    /// <summary>
    /// Util class for handling Outlook mail folders
    /// </summary>
   public class FolderServices
   {
        private MAPIFolder _baseFolder = null;
        private Microsoft.Office.Interop.Outlook.NameSpace _session;

        public List<MAPIFolder> Search(string target)
        {
            return search(_baseFolder, target).OrderBy(x=>x.Name).ToList() ;
        }
        /// <summary>
        /// Recursive method for searching Outlook folder by name
        /// </summary>
        /// <param name="folder">Folder to start searching from</param>
        /// <param name="target">Strign to search in name</param>
        /// <returns></returns>
        private List<MAPIFolder> search(MAPIFolder folder,string target) 
        {
            List<MAPIFolder> results = new List<MAPIFolder>();
            if (folder.Name.CaseInsensitiveContains(target))
                results.Add(folder);

            foreach (MAPIFolder subfolder in folder.Folders)
                results.AddRange(search(subfolder, target));
            return results;
        }
        /// <summary>
        /// Entry point for searching a TreeView with folderinformation for a name that include a string
        /// </summary>
        /// <param name="target">String to search</param>
        /// <param name="fIncludeChildren">True if child folders should be incluided</param>
        /// <returns>List of TreeNodes containing the matching folder information</returns>
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
        /// <summary>
        /// Recursive method for searching a TreeView with folders information for a name containig a string
        /// </summary>
        /// <param name="folder">Folder parent to start from</param>
        /// <param name="target">String to search</param>
        /// <param name="fIncludeChildren">True if subfolders should also be searched</param>
        /// <returns>matching Treenode folder information</returns>
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
        /// <summary>
        /// Get children of a TreeNode representing a specific folder
        /// </summary>
        /// <param name="folder">Folder to search</param>
        /// <returns>TreeNode with the child folders</returns>
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

        /// <summary>
        /// Check if folder name/description matched a string
        /// </summary>
        /// <param name="folder">Folder to check</param>
        /// <param name="target">String to match</param>
        /// <returns>True if matches </returns>
        private bool isMatch(MAPIFolder folder,string target)
        {
            return folder.Name.CaseInsensitiveContains(target) || folder.Description.CaseInsensitiveContains(target);
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="session">Current outlook session</param>
        public FolderServices(Microsoft.Office.Interop.Outlook.NameSpace session)
        {
            _session = session;
            _baseFolder = _session.GetDefaultFolder(
                Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
        }
        /// <summary>
        /// Check if folder is sent mail folder (and therefore should be excluded from search)
        /// </summary>
        /// <param name="folder">Folder to check</param>
        /// <returns>True if folder is sent mail</returns>
        public Boolean isFolderSentMail(MAPIFolder folder)
        {
            MAPIFolder sentMailFolder = _session.GetDefaultFolder(
                Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderSentMail);
            string target = sentMailFolder.Name;
            MAPIFolder subfolder = folder;
            while (subfolder.Parent is MAPIFolder && subfolder.Name != target)
            {
                subfolder = subfolder.Parent;
            }
            return subfolder.Name == target;
        }
        /// <summary>
        /// Check if folder is the default inbox (and therefore should be the base folder for any search)
        /// </summary>
        /// <param name="folder">Folder to check</param>
        /// <returns>True if default inbox</returns>
        public bool isFolderinDefaultInbox(MAPIFolder folder)
        {
            MAPIFolder inboxFolder = _session.GetDefaultFolder(
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
