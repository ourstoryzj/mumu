using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operation.CS
{


    /// <summary>
    /// List与DataTable互换
    /// 使用方法dataGridView1.DataSource = people.ToDataTable();
    /// </summary>
    public static class DataTableExtensions
    {
        /// <summary>
        /// List<T>转DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this List<T> list)
        {
            DataTable result = new DataTable();
            List<PropertyInfo> pList = new List<PropertyInfo>();
            Type type = typeof(T);
            Array.ForEach<PropertyInfo>(type.GetProperties(), prop => { pList.Add(prop); result.Columns.Add(prop.Name, prop.PropertyType); });
            foreach (var item in list)
            {
                DataRow row = result.NewRow();
                pList.ForEach(p => row[p.Name] = p.GetValue(item, null));
                result.Rows.Add(row);
            }
            return result;
        }

        /// <summary>
        /// List<T>转DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IList<T> list)
        {
            DataTable result = new DataTable();
            List<PropertyInfo> pList = new List<PropertyInfo>();
            Type type = typeof(T);
            Array.ForEach<PropertyInfo>(type.GetProperties(), prop => { pList.Add(prop); result.Columns.Add(prop.Name, prop.PropertyType); });
            foreach (var item in list)
            {
                DataRow row = result.NewRow();
                pList.ForEach(p => row[p.Name] = p.GetValue(item, null));
                result.Rows.Add(row);
            }
            return result;
        }

        /// <summary>
        /// DataTable转List<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataTable table) where T : class, new()
        {
            List<T> result = new List<T>();
            if (table != null)
            {
                List<PropertyInfo> pList = new List<PropertyInfo>();
                Type type = typeof(T);
                Array.ForEach<PropertyInfo>(type.GetProperties(), prop => { if (table.Columns.IndexOf(prop.Name) != -1) pList.Add(prop); });
                foreach (DataRow row in table.Rows)
                {
                    T obj = new T();
                    pList.ForEach(prop => { if (row[prop.Name] != DBNull.Value) prop.SetValue(obj, row[prop.Name], null); });
                    result.Add(obj);
                }
            }
            return result;
        }
        public static bool ToShowImage(this ListView listView1)
        {
            return false;
        }

        /// <summary>
        /// DataRow转换成实体类
        /// 使用方法(dgv_lh_hangye.Rows[e.RowIndex].DataBoundItem as DataRowView).Row.ToModel<lh_hangye>()
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static T ToModel<T>(this DataRow dr) where T : class, new()
        {
            //实体类属性集合
            List<PropertyInfo> pList = new List<PropertyInfo>();
            //获取实体类类型
            Type type = typeof(T);
            //映射实体类属性
            Array.ForEach<PropertyInfo>(type.GetProperties(), prop =>
            {
                if (dr.Table.Columns.IndexOf(prop.Name) != -1)
                    pList.Add(prop);
            });
            //生成实体类
            T obj = new T();
            //给实体类映射赋值
            pList.ForEach(prop =>
            {
                if (dr[prop.Name] != DBNull.Value)
                    prop.SetValue(obj, dr[prop.Name], null);
            });
            return obj;
        }

        /// <summary>
        /// List<T>中筛选包含关键词的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        //public static List<T> ToHasKeyList<T>(this List<T> list,string key)
        //{
        ////DataTable result = new DataTable();
        //List<PropertyInfo> pList = new List<PropertyInfo>();
        //Type type = typeof(T);
        ////Array.ForEach<PropertyInfo>(type.GetProperties(), prop => { pList.Add(prop); result.Columns.Add(prop.Name, prop.PropertyType); });
        //Array.ForEach<PropertyInfo>(
        //    type.GetProperties(), prop => 
        //    {
        //        pList.Add(prop);
        //        //result.Columns.Add(prop.Name, prop.PropertyType);
        //    } );
        //foreach (var item in list)
        //{
        //    //DataRow row = result.NewRow();
        //    pList.ForEach(
        //        p => row[p.Name] = p.GetValue(item, null)
        //        );
        //    //result.Rows.Add(row);

        //}
        //return result;
        //}

        #region 简便方法



        /// <summary>
        /// 简便方法： 直接用DataGridViewRow 转换成实体类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T ToModel<T>(this DataGridViewRow row) where T : class, new()
        {
            return (row.DataBoundItem as DataRowView).Row.ToModel<T>();
        }

        /// <summary>
        /// 简便方法： DataGridView转List<T>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<T> ToList<T>(this DataGridView dgv) where T : class, new()
        {
            if (dgv.DataSource != null)
                return (dgv.DataSource as DataTable).ToList<T>();
            return null;
        }
       

        #endregion


    }
}
