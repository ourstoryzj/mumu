//using System;

////声明一个代理

//public delegate void MyDelegate(object o);

////声明一个类，在类的内部声明事件

//public class MyClass

//{

//  //利用上面的代理声明一个事件

//  public event MyDelegate MyEvent;

//  //定义一个方法调用事件

//  public void FireAway(object o);

// {

//  if(MyEvent!=null)

//   {

//    //调用处理事件的方法

//     MyEvent(o);

//   }

//  }

//}

//public class MainClass

//{

//  //创建一个处理事件的方法

//  private static void EventFunction(object o)

//  {

//    Console.WriteLine("发生某种事件：",o);

//  }

//  //主方法

//  public static void Main()

//  {

//   //声明一个对象

//   MyClass m = new MyClass();

//   //将处理事件的方法和事件关联,其形式类似使用多重代理

//   m.MyEvent += new MyDelegate(EventFunction);

//   //触发事件

//   m.FireAway(m);

//  }

//}