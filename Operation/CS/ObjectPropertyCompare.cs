using System;
using System.ComponentModel;

namespace excel_operation1
{

    public class ObjectPropertyCompare<T>// : System.Collections.Generic.IComparer<T>
    {
        //private PropertyDescriptor property;
        //private ListSortDirection direction;

        //public ObjectPropertyCompare(PropertyDescriptor property, ListSortDirection direction)
        //{
        //    this.property = property;
        //    this.direction = direction;
        //}

        //#region IComparer<T>

        ///// <summary>
        ///// 比较方法
        ///// </summary>
        ///// <param name="x">相对属性x</param>
        ///// <param name="y">相对属性y</param>
        ///// <returns></returns>
        //public int Compare(T x, T y)
        //{
        //    int returnValue = 0;
        //    try
        //    {
        //        object xValue = x.GetType().GetProperty(property.Name).GetValue(x, null);
        //        object yValue = y.GetType().GetProperty(property.Name).GetValue(y, null);



        //        if (xValue is IComparable)
        //        {
        //            returnValue = ((IComparable)xValue).CompareTo(yValue);
        //        }
        //        else if (xValue.Equals(yValue))
        //        {
        //            returnValue = 0;
        //        }
        //        else
        //        {
        //            returnValue = xValue.ToString().CompareTo(yValue.ToString());
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Diagnostics.Debug.WriteLine("ObjectPropertyCompare类，排序出错" + ex.ToString());
        //    }
        //    if (direction == ListSortDirection.Ascending)
        //    {
        //        return returnValue;
        //    }
        //    else
        //    {
        //        return returnValue * -1;
        //    }
        //}

        //public bool Equals(T xWord, T yWord)
        //{
        //    return xWord.Equals(yWord);
        //}

        //public int GetHashCode(T obj)
        //{
        //    return obj.GetHashCode();
        //}

        //#endregion
    }
}
