using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Operation.Test
{
    public partial class test_delegate : Form
    {
        /// <summary>
        /// 自定义委托
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public delegate double Calc(double x, double y);

        public test_delegate()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calculator calcu = new Calculator();
            Action action = new Action(calcu.Report);
            calcu.Report();//直接调用
            action.Invoke();//利用委托指针间接调用
            action();//委托的简便调用方法



            //下面是带参数的委托
            Func<int, int, int> func_add = new Func<int, int, int>(calcu.Add);
            Func<int, int, int> func_sub = new Func<int, int, int>(calcu.Sub);

            int x = 100;
            int y = 200;
            int z = 0;

            z = func_add.Invoke(x, y);
            z.ToString().ToShow();
            z = func_sub.Invoke(x, y);
            z.ToString().ToShow();
            z = func_sub(x, y);//简便方法
            z.ToString().ToShow();
        }


        //typeof int(*Calc)(int a,int b);

        int Add(int x, int y)
        {
            return x + y;
        }

        int Sub(int x, int y)
        {
            return x - y;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Calculator2 c2 = new Calculator2();
            Calc ca1 = new Calc(c2.Add);
            Calc ca2 = new Calc(c2.Sub);
            Calc ca3 = new Calc(c2.Mul);
            Calc ca4 = new Calc(c2.Div);

            double a = 100;
            double b = 200;
            double c = 0;

            c = ca1(a, b);
            textBox1.Text = c.ToString() + "\r\n";

            c = ca2(a, b);
            textBox1.Text += c.ToString() + "\r\n";

            c = ca3(a, b);
            textBox1.Text += c.ToString() + "\r\n";

            c = ca4(a, b);
            textBox1.Text += c.ToString() + "\r\n";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductFactory pf = new ProductFactory();
            WrapFactory wf = new WrapFactory();

            Box box = wf.WrapProduct(new Func<Product>(pf.MakePizza));
            textBox1.Text = box.product.Name;

            Box box2 = wf.WrapProduct(new Func<Product>(pf.MakeCar));
            textBox1.Text += box2.product.Name;

            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            duobo db1 = new duobo() { ID = 1 };
            duobo db2 = new duobo() { ID = 2 };
            duobo db3 = new duobo() { ID = 3};
            Action action1 = new Action(db1.dohomework);
            Action action2 = new Action(db2.dohomework);
            Action action3 = new Action(db3.dohomework);

            //action1 += action2;
            //action1 += action3;

            //action1();


            //异步调用
            action1.BeginInvoke(null, null);
            action3.BeginInvoke(null, null);
            action2.BeginInvoke(null, null);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            duobo db1 = new duobo() { ID = 1 };
            duobo db2 = new duobo() { ID = 2 };
            duobo db3 = new duobo() { ID = 3 };
            Thread thread1 = new Thread(new ThreadStart(db1.dohomework));
            Thread thread2 = new Thread(new ThreadStart(db2.dohomework));
            Thread thread3 = new Thread(new ThreadStart(db3.dohomework));

            thread1.Start();
            thread2.Start();
            thread3.Start();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            duobo db1 = new duobo() { ID = 1 };
            duobo db2 = new duobo() { ID = 2 };
            duobo db3 = new duobo() { ID = 3 };

            Task task1 = new Task(new Action(db1.dohomework));
            Task task2 = new Task(new Action(db2.dohomework));
            Task task3 = new Task(new Action(db3.dohomework));

            task1.Start();
            task2.Start();
            task3.Start();
        }


        //delegate double Calc

    }

    #region bak


    class Calculator2
    {

        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }
        public double Mul(double x, double y)
        {
            return x * y;
        }

        public double Div(double x, double y)
        {
            return x / y;
        }
    }


    class Calculator
    {
        public void Report()
        {
            MessageBox.Show("有三个方法");
        }

        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Sub(int x, int y)
        {
            return x - y;
        }
    }
    #endregion


    #region MyRegion

    class Product
    {
        public string Name { get; set; }
    }

    class Box
    {
        public Product product { get; set; }
    }

    class WrapFactory
    {
        public Box WrapProduct(Func<Product> getProduct)
        {
            Box box = new Box();
            box.product = getProduct.Invoke();
            return box;
        }
    }

    class ProductFactory
    {
        public Product MakePizza()
        {
            Product pro = new Product();
            pro.Name = "Pizza";
            return pro;
        }

        public Product MakeCar()
        {
            Product pro = new Product();
            pro.Name = "Car";
            return pro;
        }
    }
    #endregion


    class duobo
    {
        public int ID { get; set; }
        public void dohomework()
        {
            MessageBox.Show(ID.ToString());
        }
    }


}
