using System;
using System.Collections.Generic;


public class GenericList<T>
{
    private T[] elements;
    private int counter = 0;

    public GenericList(int capacity)
    {
        this.elements = new T[capacity];
    }

    public T[] Elements 
    { 
        get 
        {
            return this.elements;
        }
        set
        {
            this.elements = value;
        }
    }

    public int Counter 
    { 
        get 
        {
            return this.counter;
        }
    }

    public void AddElement(T element)
    {
        if (counter < elements.Length)
        {
            elements[counter] = element;
            counter++;
        }
        else
        {
            MakeArrayDoubleSize(this.elements);
            elements[counter] = element;
            counter++;
        }
    }

    public T AccessElement(int index)
    {
        return elements[index];
    }

    public void RemoveElement(int index)
    {
        T[] removedElementArr = new T[elements.Length-1];
        Array.Copy(this.elements, 0, removedElementArr, 0, index);
        Array.Copy(this.elements, index + 1, removedElementArr, index, elements.Length - index - 1);
        this.Elements = removedElementArr;
        counter--;
    }

    public void InsertElement(int index, T element)
    {

        T[] insertElementArr = new T[elements.Length + 1];
        Array.Copy(this.elements, 0, insertElementArr, 0, index);
        insertElementArr[index] = element;
        Array.Copy(this.elements, index, insertElementArr, index+1, elements.Length - index);
        this.Elements = insertElementArr;
    }

    public T[] MakeArrayDoubleSize(T[] elements)
    {
        int doubleCapacity = elements.Length * 2;
        T[] doubleSizeArr = new T[doubleCapacity];
        Array.Copy(this.elements, 0, doubleSizeArr, 0, elements.Length);
        this.Elements = doubleSizeArr;
        return doubleSizeArr;
    }

    public void ClearElements()
    {
        this.elements = null;
    }

    public int FindElement(T element)
    {
        int index = 0;
        foreach (T item in this.elements)
        {
            if (item.ToString() == element.ToString())
            {
                return index;
            }
            index++;
        }
        throw new ArgumentException("There is no such value!");
    }

    public T this[int indexer]
    {
        get
        {
            if (indexer >= this.counter)
            {
                throw new IndexOutOfRangeException(String.Format(
                "Invalid index: {0}", indexer));
            }
            T result = elements[indexer];
            return result;
        }
    }

    public T Min<T>(T[] elements) where T : System.IComparable<T>, IComparable
    {
        dynamic min = this.elements[0];
        for (int i = 1; i < Counter; i++)
        {
            T listElement = (dynamic)this.elements[i];
            if (listElement.CompareTo(min) < 0)
            {
                min = this.elements[i];
            }
        }
        return min;
    }

    public T Max<T>(T[] elements) where T : System.IComparable<T>, IComparable
    {
        dynamic max = this.elements[0];
        for (int i = 1; i < Counter; i++)
        {
            T listElement = (dynamic)this.elements[i];
            if (listElement.CompareTo(max) > 0)
            {
                max = this.elements[i];
            }
        }
        return max;
    }
}
