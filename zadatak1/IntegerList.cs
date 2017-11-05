using System;

namespace zadatak1
{
    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;
        private int _size;
        private int _lastIndex;

        public IntegerList()
        {
            _size = 4;
            _internalStorage = new int[_size];
            _lastIndex = -1;
        }

        public IntegerList(int InitialSize)
        {
            _size = InitialSize;
            _internalStorage = new int[_size];
            _lastIndex = -1;
        }

        public void Add(int item)
        {
            if (_lastIndex + 1 == _size)
            {
                int[] hepler = _internalStorage;
                _internalStorage = new int[_size * 2];
                _size *= 2;
                _lastIndex = -1;
                foreach (int element in hepler)
                {
                    if (element.Equals(null)) break;
                    _lastIndex++;
                    _internalStorage[_lastIndex] = element;
                }
            }
            _lastIndex++;
            _internalStorage[_lastIndex] = item;
        }

        public bool Remove(int item)
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

        public int GetElement(int index)
        {
            if (index <= _lastIndex && index > -1)
            {
                return _internalStorage[index];
            }
            throw new IndexOutOfRangeException();
        }

        public int IndexOf(int item)
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
            _internalStorage = new int[_size];
            _lastIndex = -1;
        }

        public bool Contains(int item)
        {
            if (IndexOf(item) != -1) return true;
            return false;
        }
    }
}