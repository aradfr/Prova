using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayCycler<T>
{
    private T[] _items;
    private IEnumerator<T> _enumerator;

    public ArrayCycler(T[] items)
    {
        _items = items;
        _enumerator = GetNextItemEnumerator();
    }

    private IEnumerator<T> GetNextItemEnumerator()
    {
        while (true)
        {
            foreach (var item in _items)
            {
                yield return item;
            }
        }
    }

    public T GetNextItem()
    {
        if (!_enumerator.MoveNext()) 
        {
            _enumerator.Reset();  
            _enumerator.MoveNext();  
        }
        return _enumerator.Current;

    }


}