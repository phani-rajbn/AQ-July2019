using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class DataCollection<T> : IEnumerable<T> where T : class 
    {
        private List<T> _data = new List<T>();

        public void AddRecord(T item)
        {
            if (item == null) throw new Exception("Invalid Object");
            _data.Add(item);
        }

        public void DeleteRecord(T item)
        {
            _data.Remove(item);
        }

        public void UpdateRecord(T item)
        {
            for (int i = 0; i < _data.Count; i++)
            {
                if (_data[i].Equals(item))
                {
                    _data[i] = item;
                    return;
                }
            }
            throw new Exception("No record found to update");
        }

        public T[] GetAllRecords()
        {
            foreach(var emp in _data)
            {

            }
            return _data.ToArray();
        }


        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_data).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)_data).GetEnumerator();
        }
    }
}
