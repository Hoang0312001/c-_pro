using Microsoft.Extensions.DependencyInjection;
namespace Dependency

{
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
        public ClassC() => Console.WriteLine("ClassC is created");
        public void ActionC() => Console.WriteLine("Action in ClassC");
    }

    class ClassB : IClassB
    {
        IClassC c_dependency;
        public ClassB(IClassC classc)
        {
            c_dependency = classc;
            Console.WriteLine("ClassB is created");
        }
        public void ActionB()
        {
            Console.WriteLine("Action in ClassB");
            c_dependency.ActionC();
        }
    }


    class ClassA
    {
        IClassB b_dependency;
        public ClassA(IClassB classb)
        {
            b_dependency = classb;
            Console.WriteLine("ClassA is created");
        }
        public void ActionA()
        {
            Console.WriteLine("Action in ClassA");
            b_dependency.ActionB();
        }
    }
    class Program
    {


        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSingleton<ClassA, ClassA>();
            services.AddSingleton<IClassC, ClassC>();
            services.AddSingleton<IClassB, ClassB>();

            var provider = services.BuildServiceProvider();
            ClassA classA = provider.GetService<ClassA>();
            classA.ActionA();

        }
    }
}