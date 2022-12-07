using proj5_5;
using System;
using System.Collections;
using System.Xml.Linq;

namespace proj5_5
{


    //class A         //声明包含类A
    //{
    //    string stra = "A";  //类A的私有字段
    //    public void funa1() //定义类A的公有方法funa1()
    //    {
    //        B b = new B(this);     //将this即类A的对象传递给类B的构造函数
    //        b.funb1();
    //    }
    //    public void funb2() //定义类A的公有方法funa2()
    //    {
    //        B b = new B(this);    //将this即类A的对象传递给类B的构造函数
    //        b.funb2();
    //    }



    //    private class B         //声明嵌套类B
    //    {
    //        private A m_sb;     //类A 的引用类型为类B的私有字段
    //        string strb = "B";      //类B的私有字段
    //                                // public B() { }  //B构造方法
    //        public B(A parent)
    //        { m_sb = parent; }
    //        public void funb1()     //定义类B的公有方法funb1()
    //        { Console.WriteLine(m_sb.stra); }
    //        public void funb2()
    //        { Console.WriteLine(strb); }
    //    }
    //}

    public class Teacher              //教师类，事件源类
    {
        private string tname;//教师姓名
        int tno;
        public delegate void delegateType();      //声明委托类型
        public event delegateType ClassEvent;//声明一个上课事件
        public Teacher(string name)   //构造函数
        { tname = name; }
        public Teacher()
        {

        }
        public Teacher(int no,string name)   //构造函数
        { tno = no;tname = name; }
        public void Start()       //定义引发事件的方法
        {
            Console.WriteLine(tname + "教师宣布开始上课:");
            if (ClassEvent != null)
                ClassEvent();         //当事件不空时引发该事件
        }
        public void Dispteacher()       //输出教师对象
        { Console.Write("{0}:{1} ", tno, tname); }

        public void Displyteacher()       //重构输出教师对象
        { Console.Write("[{0}:{1}] ", tno, tname); }

    }
    class Stack<T>
    {
        int maxsize;    //栈中最大容纳数量
        int top ;  //确定栈地
        T[] data;   //存放栈中元素
        public Stack()
        {
            maxsize = 10;
            data = new T[maxsize];
            top = -1;
        }
        public bool StackEmpty()    //判断栈是否为空
        {
            return top == -1;
        }
        public bool Push(T e)   //判断进栈元素
        {
            if(top == maxsize-1)   
                return false;
            top++;
            data[top] = e;  
            return true;}
        public bool Pop(ref  T e)   //判断出栈元素；
        {  if(top == -1)
            return false;
          e=data[top];
            top--;
            return true;
        }
    }
    public class Student            //学生类,订阅者类
    {
        protected string sname;       //学生姓名
        protected int sno;
        public string tname;
        public Student()
        {

        }
        public Student(string name)
        {
            sname=name;
        }
        public Student(int no,string name)    //构造函数
        { sno = no;sname = name; }
        public void Listener()      //听课方法
        { Console.WriteLine("  学生" + sname + "正在认真听课"); }
        public void Record()    //做笔记方法
        { Console.WriteLine("  学生" + sname + "正在做笔记"); }
        public void Reading()   //看书方法
        { Console.WriteLine("  学生" + sname + "正在认真看书"); }
        public void setdata(int no1, string name1, string tname1)
        {
            sno = no1; sname = name1; tname = tname1;
        }
        public virtual void dispdata() //虚方法
        {
            Console.WriteLine("本科生　学号:{0} 姓名:{1} 班 主 任:{2}", sno, sname, tname);
        }
        public  void displystudent() //虚方法
        {
            Console.WriteLine("姓名：{0}，学号{1} ", sname, sno);
        }

    }

    class Graduate : Student
    {
        public override void dispdata() //重写方法
        {
            Console.WriteLine("研究生  学号:{0} 姓名:{1} 指导教师:{2}",sno, sname, tname);
        }

    }


    abstract class A
    {
        private int x { get => x; set => x = value; }
        abstract public int Funp();

        //public A() { Console.WriteLine("调用类A的构造函数"); }
        //public A(int x1)
        //{
        //    x = x1;
        //    Console.WriteLine("调用类A的重构构造函数");
        //}
        //~A() { Console.WriteLine("A:x={0}", x); }

    }

    class B : A
    {
        //private int y;
        int x, y;
        public void funb(int x1, int y1) {
            x = x1; y = y1;
        }
        public override int Funp()
        {
            return x * y;
        }
        public B() { Console.WriteLine("调用B的构造函数"); }
        ~B() { Console.WriteLine("B:y={0}", y); }
        //public B(int x1, int y1) : base(x1)
        //{
        //    y = y1;
        //    Console.WriteLine("调用B的重构函数");
        //}

    }

    //class C : B
    //{
    //    private int z;
    //    public C() { Console.WriteLine("调用C的构造函数"); }
    //    ~C() { Console.WriteLine("C:z={0}",z); }
    //    public C(int x1,int y1,int z1) : base(x1, y1)
    //    {
    //        z=z1 ;
    //        Console.WriteLine("调用C的重构函数");
    //    }


    //}

    interface Ia {
        float getarea();
    }



    public class Rectangle : Ia
    {
        float x, y;
        public Rectangle(float x1, float x2)
        {
            x = x1; y = x2;
        }
        float Ia.getarea() //显式接口成员实现,带有接口名前缀,不能使用public
        {
            return x * y;
        }




    }


  

    class Program
    {
        class Stud : IComparable    //从接口派生
        {
            int xh;                     //学号
            string xm;                  //姓名
            int fs;                     //分数
            public int pxh              //pxh属性
            {
                get { return xh; }
            }
            public string pxm           //pxm属性
            {
                get { return xm; }
            }
            public int pfs              //pfs属性
            {
                get { return fs; }
            }

            public Stud(int no, string name, int degree) //构造函数
            {
                xh = no; xm = name; fs = degree;
            }
            public void disp()                        //输出学生信息
            {
                Console.WriteLine("\t{0}\t{1}\t{2}", xh, xm, fs);
            }
            public int CompareTo(object obj)     //实现接口方法
            {
                Stud s = (Stud)obj;                 //转换为Stud实例
                if (pfs < s.pfs) return 1;
                else if (pfs == s.pfs) return 0;
                else return -1;
            }
        }
        static void disparr(ArrayList myarr, string str)
        //输出所有学生信息
        {
            Console.WriteLine(str);
            Console.WriteLine("\t学号\t姓名\t分数");
            foreach (Stud s in myarr) s.disp();
        }



        static void Main(string[] args)
        {
            //A a = new A();
            //a.funa1();
            //a.funb2();
            Teacher t = new Teacher("李明");
            Student s1 = new Student("许强");
            Student s2 = new Student("陈兵");
            Student s3 = new Student("张英");
            //以下是3个学生订阅同一个事件
            t.ClassEvent += new Teacher.delegateType(s1.Listener);
            t.ClassEvent += new Teacher.delegateType(s2.Reading);
            t.ClassEvent += new Teacher.delegateType(s3.Record);
            t.Start();		//引发事件
            //C c = new C(1, 2, 3);
            Student s = new Student();
            s.setdata(101, "王华", "李量");
            s.dispdata();
            Graduate g = new Graduate();
            g.setdata(201, "张华", "陈军");
            g.dispdata();
            B b= new B();
            b.Funp();
            Rectangle box1 = new Rectangle(2.5f, 3.0f);//定义一个类实例
            Ia ia = box1;                               //定义一个接口实例
            Console.WriteLine("长方形面积: {0}", ia.getarea());
            int i, n = 4;
            ArrayList myarr = new ArrayList();
            Stud[] st = new Stud[4] { new Stud(1, "Smith", 82),
                  new Stud(4, "John", 88), new Stud(3, "Mary", 95),
                  new Stud(2, "Cherr", 64) };
            for (i = 0; i < n; i++)     //将对象添加到myarr集合中
            myarr.Add(st[i]);
            disparr(myarr, "排序前:");
            myarr.Sort();
            disparr(myarr, "按分数降序排序后:");
            //整数栈操作
            int e = 0;
            Stack<int> s8 = new Stack<int>();
            s8.Push(5);
            s8.Push(10);
            s8.Push(18);
            Console.WriteLine("整数栈出数顺序");
            while (!s8.StackEmpty())
            {
                s8.Pop(ref e);
                Console.WriteLine("{0}",e);
            }
            Console.WriteLine();
            //实数栈操作
            double r = 0;
            Stack<double> s9 = new Stack<double>();
            s9.Push(5.5);
            s9.Push(10.10);
            s9.Push(18.5);
            Console.WriteLine("实数栈出数顺序");
            while (!s9.StackEmpty())
            {
                s9.Pop(ref r);
                Console.WriteLine("{0}", r);
            }
            Student student=new Student();
            Stack<Student> s10 = new Stack<Student>();
            s10.Push(new Student(1,"xxc"));
            s10.Push(new Student(2, "xxv"));
            s10.Push(new Student(3, "xxb"));
            //学生栈出栈顺序
            Console.Write("学生栈出数顺序");
            while (!s10.StackEmpty())
            {
                s10.Pop(ref student);
                student.displystudent();
            }
            Console.WriteLine();
            Teacher teacher = new Teacher();
            Stack<Teacher> s11 = new Stack<Teacher>();
            s11.Push(new Teacher(1, "SD"));
            s11.Push(new Teacher(2, "SC"));
            s11.Push(new Teacher(3, "SM"));
            //老师栈出栈顺序
            Console.Write("老师栈出数顺序");
            while (!s11.StackEmpty())
            {
                s11.Pop(ref teacher); 
                teacher.Displyteacher();
            }
            Console.WriteLine();











        }




    }






}
    

