using System;
using System.Collections.Generic;

using System.Text;

namespace TK_DataComparerLib
{
    public class EntityProperty
    {
        public EntityProperty(string inName, string inType, object inValue, bool inTransferable, bool inMandatory, double inCoeff)
        {
            _name = inName;
            _type = inType;
            _value = inValue;
            _mandatory = inMandatory;
            _transferable = inTransferable;
            _coeff = inCoeff;
        }

        public EntityProperty(string inName, string inType, object inValue)
            : this(inName, inType, inValue, false, true, 1.0)
        {

        }

        public EntityProperty(string inName, string inType, object inValue, bool inTransferable)
            : this(inName, inType, inValue, inTransferable, true, 1.0)
        {

        }

        protected DataEntity _entity;

        protected string _name = "Name";
        protected bool _active = true;
        protected string _type = "String";
        protected object _value = "EntityName";
        protected bool _mandatory = true;
        protected bool _transferable = false;
        protected double _coeff = 1.0;
        
        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public virtual bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public virtual string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public virtual object Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public virtual bool Mandatory
        {
            get { return _mandatory; }
            set { _mandatory = value; }
        }

        public bool Transferable
        {
            get { return _transferable; }
            set { _transferable = value; }
        }

        public double Coeff
        {
            get { return _coeff; }
            set { _coeff = value; }
        }

        public DataEntity Entity
        {
            get { return _entity; }
            set { _entity = value; }
        }

        public virtual string GetStringValue()
        {
            return _value.ToString();
        }

        public virtual double Compare(EntityProperty entityProperty, ComparisonBoard comparison)
        {
            if (_coeff <= 0.0)
            {
                return 0.0;
            }

            if (_value.Equals(entityProperty.Value))
            {
                return 1.0;
            }

            switch (_type)
            {
                case "Int":
                    return comparison.GetCorrelation((int)_value, (int)entityProperty.Value);
                    break;
                case "String":
                    return comparison.GetCorrelation((string)_value, (string)entityProperty.Value);
                    break;
                case "Serialized":
                    return (string)_value == (string)entityProperty.Value ? 1.0 : 0.0;
                break;
                /*case "Double":

                    break;*/
            }

            return 0.0;
        }

        public virtual bool Transfer(DataEntity dataEntity)
        {
            return false;
        }
    }
}
