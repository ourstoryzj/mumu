using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excel_operation.CS1
{
    /// <summary>
    /// 提供支持数据绑定的泛型集合
    /// 使用方法dataGridView1.DataSource = new BindingCollection<Person>(people);
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BindingCollection1<T> : BindingList<T>
    {
        private bool _isSortedCore = true;
        private ListSortDirection _sortDirectionCore = ListSortDirection.Ascending;
        private PropertyDescriptor _sortPropertyCore = null;

        /// <summary>
        /// 是否已排序
        /// </summary>
        protected override bool IsSortedCore
        {
            get { return _isSortedCore; }
        }
        /// <summary>
        /// 获取列表的排序方向
        /// </summary>
        protected override ListSortDirection SortDirectionCore
        {
            get { return _sortDirectionCore; }
        }
        /// <summary>
        /// 获取用于对列表排序的属性说明符
        /// </summary>
        protected override PropertyDescriptor SortPropertyCore
        {
            get { return _sortPropertyCore; }
        }
        /// <summary>
        /// 是否支持排序
        /// </summary>
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }
        /// <summary>
        /// 是否支持搜索
        /// </summary>
        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BindingCollection1()
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="list"></param>
        public BindingCollection1(IList<T> list)
            : base(list)
        { }

        /// <summary>
        /// 对项排序
        /// </summary>
        /// <param name="property"></param>
        /// <param name="direction"></param>
        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            List<T> items = this.Items as List<T>;

            if (items != null)
            {
                ObjectPropertyCompare<T> pc = new ObjectPropertyCompare<T>(property, direction);
                items.Sort(pc);
                _isSortedCore = true;
                _sortDirectionCore = direction;
                _sortPropertyCore = property;
            }
            else
            {
                _isSortedCore = false;
            }

            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        /// <summary>
        /// 移除排序
        /// </summary>
        protected override void RemoveSortCore()
        {
            _isSortedCore = false;
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
    }

    public class ObjectPropertyCompare<T> : IComparer<T>
    {
        /// <summary>
        /// 属性
        /// </summary>
        public PropertyDescriptor Property { get; set; }
        /// <summary>
        /// 排序方向
        /// </summary>
        public ListSortDirection Direction { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ObjectPropertyCompare()
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="property"></param>
        /// <param name="direction"></param>
        public ObjectPropertyCompare(PropertyDescriptor property, ListSortDirection direction)
        {
            Property = property;
            Direction = direction;
        }

        /// <summary>
        /// 比较两个对象
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(T x, T y)
        {
            object xValue = x.GetType().GetProperty(Property.Name).GetValue(x, null);
            object yValue = y.GetType().GetProperty(Property.Name).GetValue(y, null);

            int returnValue;

            if (xValue == null && yValue == null)
            {
                returnValue = 0;
            }
            else if (xValue == null)
            {
                returnValue = -1;
            }
            else if (yValue == null)
            {
                returnValue = 1;
            }
            else if (xValue is IComparable)
            {
                returnValue = ((IComparable)xValue).CompareTo(yValue);
            }
            else if (xValue.Equals(yValue))
            {
                returnValue = 0;
            }
            else
            {
                returnValue = xValue.ToString().CompareTo(yValue.ToString());
            }

            if (Direction == ListSortDirection.Ascending)
            {
                return returnValue;
            }
            else
            {
                return returnValue * -1;
            }
        }
    }
}
