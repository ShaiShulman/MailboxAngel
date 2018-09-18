using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilingHelper
{
    public class FolderNavigator
    {
        private Stack<string> getSubFolders(MAPIFolder targetFolder)
        {
            bool isRoot = false;
            MAPIFolder folder = targetFolder;
            Stack<string> subfolders = new Stack<string>();
            do
            {
                subfolders.Push(folder.Name);
                if (folder.Parent is MAPIFolder)
                    folder = folder.Parent;
                else
                    isRoot = true;
            } while (!isRoot);
            return subfolders;
        }


        private MAPIFolder folderFromName(string folderName)
        {
            try
            {
                MAPIFolder folder = ((MAPIFolder)Globals.ThisAddIn.Application.Session.Folders[folderName]);
                return folder;
            }
            catch (System.Exception)
            {
                return null;
            }
        }


        private MAPIFolder folderFromName(Stack<String> folderNames, MAPIFolder baseFolder)
        {
            Stack<String> subfolders = new Stack<String>(folderNames.Reverse());
            try
            {
                MAPIFolder folder = baseFolder;
                while (subfolders.Count > 0)
                {
                    folder = folder.Folders[subfolders.Pop()];
                }
                return folder;
            }
            catch (System.Exception)
            {
                return null;
            }
        }


        private int baseFolderNumber(MAPIFolder folder)
        {
            int i = 1;
            NameSpace NS = Globals.ThisAddIn.Application.Session;
            while (i<NS.Folders.Count)
            {
                if (((MAPIFolder)NS.Folders[i]).EntryID == folder.EntryID)
                    return i;
                i++;
            }
            return 0;
        }

        private MAPIFolder incrementFolder(NameSpace NS, int index, int increment, Stack<string> subfolder)
        {
            int newIndex = index;
            int cycles = 0;
            MAPIFolder result;
            do
            {
                newIndex +=increment;
                //if (NS.Folders[newIndex].DefaultItemType != )
                //    newIndex =+increment;
                if (newIndex > NS.Folders.Count)
                    newIndex = 1;
                if (newIndex < 1)
                    newIndex = NS.Folders.Count - 1;
                cycles++;
            } while ((result = folderFromName(subfolder, NS.Folders[newIndex])) == null
                && cycles<=NS.Folders.Count);
            if (cycles > NS.Folders.Count)
                return null;
            else
                return result;
        }

        public void NavigateSimilarFolder(Explorer explorer,int increment)
        {
            MAPIFolder currentFolder = explorer.CurrentFolder;
            if (currentFolder == null)
                return;
            Stack<string> subfolders = getSubFolders(currentFolder);
            if (subfolders.Count == 0)
                return;
            MAPIFolder baseFolder = folderFromName(subfolders.Pop());
            NameSpace NS = Globals.ThisAddIn.Application.Session;
            MAPIFolder target = incrementFolder(NS, baseFolderNumber(baseFolder), increment, subfolders);
            if (target!=null)
                Globals.ThisAddIn.NavigateFolder(explorer, target);
        }

    }
}
