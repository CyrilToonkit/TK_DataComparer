using System;
using System.Collections.Generic;

using System.Text;

namespace TK_DataComparerLib
{
    public class DataEntity
    {
        protected ComparableData _comparable;

        protected List<EntityProperty> _properties = new List<EntityProperty>();

        private DataEntity _associatedEntity = null;

        protected int decimals = 3;
        public int Decimals
        {
            get
            {
                return decimals;
            }
            set
            {
                decimals = value;
            }
        }

        private bool _dontAssociate = false;
        public bool DontAssociate
        {
            get { return _dontAssociate; }
            set { _dontAssociate = value; }
        }

        public ComparableData Comparable
        {
            get { return _comparable; }
            set { _comparable = value; }
        }

        public List<EntityProperty> Properties
        {
            get { return _properties; }
        }

        public DataEntity AssociatedEntity
        {
            get { return _associatedEntity; }
            set { _associatedEntity = value; }
        }

        public string Id
        {
            get { return _properties[0].GetStringValue(); }
        }

        public string[] GetValues()
        {
            int propCount = _comparable.GetActivePropertiesCount();
            string[] values = new string[propCount];
            int i = 0;
            foreach(EntityProperty prop in _properties)
            {
                if (prop.Active)
                {
                    values[i] = prop.GetStringValue();
                    i++;
                }
            }

            return values;
        }

        public EntityProperty GetProperty(string inPropName)
        {
            foreach (EntityProperty prop in _properties)
            {
                if (prop.Name == inPropName)
                {
                    return prop;
                }
            }

            return null;
        }

        public void AddProperty(EntityProperty inProp)
        {
            _properties.Add(inProp);
            inProp.Entity = this;
        }

        public virtual void CreateProperties()
        {

        }

        public virtual void BeginHighlight()
        {

        }

        public virtual void Highlight()
        {

        }

        public virtual void EndHighlight()
        {

        }

        public virtual void Copy(ComparableData comparableData)
        {
            
        }
    }
}
