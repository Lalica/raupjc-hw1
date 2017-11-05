using System;
using System.Collections;
using System.Collections.Generic;

namespace zad2zad3
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
                _internalStorage = new X[_size * 2];
                _size *= 2;
                _lastIndex = -1;
                foreach (X element in hepler)
                {
                    if (element.Equals(null)) break;
                    _lastIndex++;
                    _internalStorage[_lastIndex] = element;
                }
            }
            _lastIndex++;
            _internalStorage[_lastIndex] = item;
        }

        public bool Remove(X item)
        {
            try
            {
                return RemoveAt(IndexOf(item));
            }
            catch (IndexOutOfRangeException ex)
            {
                return false;
            }
        }

        public bool RemoveAt(int index)
        {
            if (index > _lastIndex || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = index + 1; i <= _lastIndex; i++)
            {
                _internalStorage[i - 1] = _internalStorage[i];
            }
            _lastIndex--;
            return true;
        }

        public X GetElement(int index)
        {
            if (index <= _lastIndex && index > -1)
            {
                return _internalStorage[index];
            }
            throw new IndexOutOfRangeException();
        }

        public int IndexOf(X item)
        {
            if (_lastIndex == -1) return -1;
            for (int j = 0; j <= _lastIndex; j++)
            {
                if (_internalStorage[j].Equals(item)) return j;
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