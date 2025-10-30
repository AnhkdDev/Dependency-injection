using System.Threading.Channels;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    //Dependency: phụ thuộc
    //ClassA được gọi là Dependency của ClassB, vì có ClassA thì ClassB mới hoạt động được

    //Inverse of Control (Dependency Inverse)
    //Dependency injection 

    class Horn
    {
        int lever = 0;//độ lớn
        public Horn(int lever)
        {
            this.lever = lever;
        }
        public void Beep() => Console.WriteLine("Beep - Beep - Beep");
    }

    class Car
    {
        public Horn horn { get; set; }
        public Car(Horn _horn) => horn = _horn;
        public void Beep()
        {
            horn.Beep();
        }
    }

    //ví dụ phụ thuộc theo interface
    interface IClassB
    {
        public void ActionB();
    }

    interface IClassC
    {
        public void ActionC();
    }

    class ClassC : IClassC
    {
        public void ActionC() => Console.WriteLine("Action in ClassC");
    }

    class ClassB : IClassB
    {
        // Phụ thuộc của ClassB là ClassC
        IClassC c_dependency;

        public ClassB(IClassC classc) => c_dependency = classc;
        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }

    class ClassA
    {
        // Phụ thuộc của ClassA là ClassB
        IClassB b_dependency;

        public ClassA(IClassB classb) => b_dependency = classb;
        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }
        class ClassC1 : IClassC
        {
            public ClassC1() => Console.WriteLine("ClassC1 is created");
            public void ActionC()
            {
                Console.WriteLine("Action in C1");
            }
        }

        class ClassB1 : IClassB
        {
            IClassC c_dependency;
            public ClassB1(IClassC classc)
            {
                c_dependency = classc;
                Console.WriteLine("ClassB1 is created");
            }
            public void ActionB()
            {
                Console.WriteLine("Action in B1");
                c_dependency.ActionC();
            }
        }

        static void Main(string[] args)
        {
            //thư viện Dependency Injection
            //DI container  : chính là ServiceCollection 
            // - Đăng kí các dịch vị (lớp)
            // - Get Service : ServiceProvider

            var services = new ServiceCollection();

            //đăng kí các dịch vụ
            //IClassC, ClassC, ClassC1

            //Đăng kí dịch vụ kiểu Singleton
            //services.AddSingleton<IClassC, ClassC1>();

            //Đăng kí dịch vụ kiểu Transient
            //services.AddTransient<IClassC, ClassC1>();

            //Đăng kí dịch vụ kiểu Scoped
            //services.AddScoped<IClassC, ClassC1>();

            // ClassA
            // IClassC, ClassC, ClassC1
            // IClassB, ClassB, ClassB1

            services.AddSingleton<ClassA, ClassA>();
            services.AddSingleton<ClassB, ClassB>();
            services.AddSingleton<IClassC, ClassC>();

            var provider = services.BuildServiceProvider();

            ClassA a = provider.GetService<ClassA>();
            a.ActionA();

          
        }
    }
}
