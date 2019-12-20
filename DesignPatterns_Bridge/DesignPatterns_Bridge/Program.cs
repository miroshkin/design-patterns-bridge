using System;

namespace DesignPatterns_Bridge
{
    //original source https://metanit.com/sharp/patterns/4.6.php
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Design Patterns - Bridge!");

            Programmer freelancer = new FreelanceDeveloper(new Java());
            freelancer.DoWork();
            freelancer.EarnMoney();

            freelancer.Language = new CSharp();
            freelancer.DoWork();
            freelancer.EarnMoney();
        }
    }

    interface ILanguage
    {
        void Build();
        void Execute();
    }

    class Java : ILanguage
    {
        public void Build()
        {
            Console.WriteLine("Building Java library");
        }

        public void Execute()
        {
            Console.WriteLine("Executing Java library");
        }

    }

    class CSharp : ILanguage
    {
        public void Build()
        {
            Console.WriteLine("Building C Sharp library");
        }

        public void Execute()
        {
            Console.WriteLine("Executing C Sharp library");
        }
    }

    abstract class Programmer
    {
        protected ILanguage _language;

        public ILanguage Language
        {
            set { _language = value; }
        }

        public Programmer(ILanguage language)
        {
            _language = language;
        }

        public virtual void DoWork()
        {
            _language.Build();
            _language.Execute();
        }

        public abstract void EarnMoney();
    }

    class FreelanceDeveloper : Programmer
    {
        public FreelanceDeveloper(ILanguage language) : base(language)
        {

        }

        public override void EarnMoney()
        {
            Console.WriteLine("Get project price");
        }
    }

    class CorporateDeveloper : Programmer
    {
        public CorporateDeveloper(ILanguage language) : base(language)
        {
            
        }

        public override void EarnMoney()
        {
            Console.WriteLine("Get monthly paid salary");
        }
    }
}
