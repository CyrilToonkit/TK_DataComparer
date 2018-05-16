using System;
using System.Collections.Generic;
using System.Text;
using TK.BaseLib;
using TK.BaseLib.CustomData;

namespace TK_DataComparerLib
{
    public class SaveAbleMapping : SaveableData
    {
        KeyValuePreset _mappings = new KeyValuePreset();

        public KeyValuePreset Mappings
        {
            get { return _mappings; }
            set { _mappings = value; }
        }

        public override void Clone(SaveableData Data)
        {
            SaveAbleMapping otherMapping = Data as SaveAbleMapping;
            _mappings = new KeyValuePreset();
            otherMapping.Mappings.SyncDic();

            foreach(string key in otherMapping.Mappings.Keys)
            {
                _mappings.PushItem(key, otherMapping.Mappings.GetValue(key));
            }
        }
    }
}
