using System;
using Unity;
using Unity.Resolution;

namespace Pipopolam.MegaArchitecture
{
    public interface IImplementable { }

    public interface IRegistrator : IImplementable
    {
        void Register();
    }

    public interface ILoggable : IImplementable
    {
        string ToLog();
    }

    public interface IAutoLoggable : ILoggable, IImplementable
    {
        void Log();
    }

    public interface ILogger : IImplementable
    {
        void Log(ILoggable obj);
    }

    public interface IReader : IImplementable
    {
        int Read();
    }

    public interface IMember : IAutoLoggable, IImplementable { }

    public interface IResult : IMember, IAutoLoggable, IImplementable { }

    public interface IOperator<TMember, TResult> : IImplementable
        where TMember : IMember
        where TResult : IResult
    {
        TMember Left { get; }
        TMember Right { get; }

        TResult GetResult();
    }

    public interface ISummator<TMember, TResult> : IOperator<TMember, TResult>, IImplementable
        where TMember : IMember
        where TResult : IResult
    {
    }

    public interface IIntMember : IMember, IImplementable
    {
        int Value { get; }
    }

    public class IntMember : IIntMember
    {
        [Dependency]
        public ILogger Logger { get; set; }

        public int Value { get; }

        public IntMember(int value)
        {
            Value = value;
        }

        public void Log()
        {
            Logger.Log(this);
        }

        public string ToLog()
        {
            return Value.ToString();
        }
    }

    public interface IIntResult : IResult, IImplementable { }

    public class IntResult : IntMember, IIntResult
    {
        public IntResult(int value) : base(value) { }
    }

    public interface IIntSummator : ISummator<IIntMember, IIntResult>, IImplementable {  }

    public class IntSummator : IIntSummator
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        [Dependency]
        public IIntMember Left { get; set; }

        [Dependency]
        public IIntMember Right { get; set; }

        public IIntResult GetResult()
        {
            return Container.Resolve<IntResult>(new ParameterOverride("value", Left.Value + Right.Value));
        }
    }

    public class RegistratorImpl : IRegistrator, IImplementable
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        public void Register()
        {
            Container.RegisterSingleton<ILogger, LoggerImpl>();
            Container.RegisterSingleton<IReader, ReaderImpl>();

            Container.RegisterType<IIntMember, IntMember>();
            Container.RegisterType<IIntResult, IntResult>();
            Container.RegisterType<IIntSummator, IntSummator>();
        }
    }

    public class LoggerImpl : ILogger, IImplementable
    {
        public void Log(ILoggable obj)
        {
            Console.WriteLine($"{obj?.ToLog() ?? "[null]"}");
        }
    }

    public class ReaderImpl : IReader, IImplementable
    {
        public int Read()
        {
            if (Int32.TryParse(Console.ReadLine(), out int result))
                return result;

            throw new InvalidCastException("You need to enter int value!");
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterSingleton<IRegistrator, RegistratorImpl>();
            container.Resolve<IRegistrator>().Register();

            IReader reader = container.Resolve<IReader>();

            IIntMember left = container.Resolve<IIntMember>(new ParameterOverride("value", reader.Read()));
            IIntMember right = container.Resolve<IIntMember>(new ParameterOverride("value", reader.Read()));

            IIntSummator summator = container.Resolve<IIntSummator>(new PropertyOverride("Left", left), new PropertyOverride("Right", right));

            summator.GetResult().Log();
        }
    }
}
