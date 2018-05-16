using System;
using System.Collections.Generic;

using System.Text;
using TK_DataComparerLib;
using System.IO;

namespace FilesComparer
{
    public class ComparableFile : DataEntity
    {
        public ComparableFile()
        {

        }

        public ComparableFile(FileInfo info)
        {
            CreateProperties(info);
        }

        public void CreateProperties(FileInfo info)
        {
            _properties.Clear();

            _properties.Add(new EntityProperty("Name", "String", info.Name));
            _properties.Add(new EntityProperty("Path", "String", info.FullName, false, false, .5));
            _properties.Add(new EntityProperty("Size", "Int", (int)info.Length, true));
        }
    }
}
