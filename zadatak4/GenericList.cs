using System;
using System.Collections;
using System.Collections.Generic;

namespace zadatak4
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;
        private int _size;
        private int _lastIndex;

        public GenericList()
        {
            _size = 4;
            _internalStorage = new X[_size];
            _lastIndex = -1;
        }

        public GenericList(int InitialSize)
        {
            _size = InitialSize;
            _internalStorage = new X[_size];
            _lastIndex = -1;
        }

        public void Add(X item)
        {
            if (_lastIndex + 1 == _size)
            {
                X[] hepler = _internalStorage;
                _internalStorage = new X[_size*2];
                _lastIndex = -1;

                foreach (X element in hepler)
                {
                    _lastIndex++;
                    _internalStorage[_lastIndex] = element;
            
                }
            }

            _lastIndex++;
            _internalStorage[_lastIndex] = item;
        }

        public bool Remove(X item)
        {
            int i = -1;
            foreach (X element in _internalStorage)
            {
                i++;
                if (element.Equals(item))
                {
                    return RemoveAt(i);
                }
            }

            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index + 1 >= _size)
            {
                throw new IndexOutOfRangeException();
            }
            X[] helper = _internalStorage;
            for (int i = index + 1; i < _size; i++)
            {
                _internalStorage[index] = helper[i];
                index++;
            }
            return true;
        }

        public X GetElement(int index)
        {
            if (index < _size && index >= -1)
            {
                return _internalStorage[index];
            }
            throw new IndexOutOfRangeException();
        }

        public int IndexOf(X item)
        {
            int i = -1;
            foreach (X element in _internalStorage)
            {
                i++;
                if (element.Equals(item)) return i;
            }
            return -1;
        }

        public int Count => _lastIndex + 1;

        public void Clear()
        {
            _internalStorage = new X[_size];
            _lastIndex = -1;
        }

        public bool Contains(X item)
        {
            if (IndexOf(item) != -1) return true;
            return false;
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

