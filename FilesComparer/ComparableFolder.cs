using System;
using System.Collections.Generic;

using System.Text;
using TK_DataComparerLib;
using System.Windows.Forms;
using System.IO;

namespace FilesComparer
{
    public class ComparableFolder : ComparableData
    {
        public ComparableFolder()
        {
        }

        public ComparableFolder(string path)
        {
            _name = path;
        }

        public override void CollectEntities()
        {
            _entities = new List<DataEntity>();

            if (_name != "")
            {
                DirectoryInfo info = new DirectoryInfo(_name);

                if (info.Exists)
                {
                    FileInfo[] files = info.GetFiles("*", SearchOption.AllDirectories);

                    foreach (FileInfo finfo in files)
                    {
                        AddEntity(new ComparableFile(finfo));
                    }
                }
            }
        }

        public override bool Pick()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult rslt = fbd.ShowDialog();

            if (rslt == DialogResult.OK)
            {
                _name = fbd.SelectedPath;
                return true;
            }

            return false;
        }
    }
}
