using System;
using System.Collections.Generic;
using System.Text;

namespace TK_DataComparerLib
{
    public class ComparableData
    {
        protected string _name = "";
        public virtual string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        protected List<DataEntity> _entities = new List<DataEntity>();

        public List<DataEntity> Entities
        {
            get { return _entities; }
        }

        public void AddEntity(DataEntity inEntity)
        {
            _entities.Add(inEntity);
            inEntity.Comparable = this;
        }

        public DataEntity GetEntity(string id)
        {
            foreach (DataEntity entity in _entities)
            {
                if (entity.Id == id)
                {
                    return entity;
                }
            }

            return null;
        }

        public virtual void CollectEntities()
        {
            _entities = new List<DataEntity>();
        }

        public virtual bool Pick()
        {
            return false;
        }

        public virtual List<string> PickBoth()
        {
            return new List<string>();
        }

        public override string ToString()
        {
            return _name;
        }

        internal int GetActivePropertiesCount()
        {
            int count = 0;

            if(Entities.Count > 0 && Entities[0].Properties.Count > 0)
            {
                foreach(EntityProperty prop in Entities[0].Properties)
                {
                    if (prop.Active)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
