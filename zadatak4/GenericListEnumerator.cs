using System;
using System.Collections;
using System.Collections.Generic;

namespace zadatak4
{
    public class GenericListEnumerator<T> : IEnumerator<T>
    {
        private GenericList<T> _genericList;
        private int _atm;
        private T _current;
        public GenericListEnumerator(GenericList<T> genericList)
        {
            this._genericList = genericList;
            _current = default(T);
            _atm = -1;
        }

        public T Current{get{return _current;}set{_current = value;}}

        object IEnumerator.Current => _current;

        public void Dispose()
        {
            this._genericList = null;
            _current = default(T);
            _atm = -1;
        }

        public bool MoveNext()
        {
            if (++_atm >= _genericList.Count) return false;
            _current = _genericList.GetElement(_atm);
            return true;
        }

        public void Reset()
        {
            _current = default(T);
            _atm = -1;
        }
    }

}
