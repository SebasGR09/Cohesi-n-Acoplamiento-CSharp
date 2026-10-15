using System;


public interface IGenerator
{
    void Generate();
}



namespace Employee
{

    public class GeneratorPDF : IGenerator
    {
        public void Generate()
        {
            Console.WriteLine("PDF generado");
        }
    }


    public class GeneratorEmail : IGenerator
    {
      public void Generate()
        {
            Console.WriteLine("Email generado");
        }
    }


    public class ReportService
    {
        private readonly IGenerator _generator;

        public ReportService(IGenerator generator)
        {
            this._generator = generator;
        }

        public void Generate()
        {
            _generator.Generate();
        }

    }

    public class EmployeeService
    {
        public void RegisterEmployee()
        {
            Console.WriteLine("Empleado registrado");
        }

        public void SalaryCalculate()
        {
            Console.WriteLine("Salario Calculado");
        }

    }



    public class Program
    {
        static void Main(string[] args)
        {
            var pruebaGenerador = new ReportService(new GeneratorEmail());
            pruebaGenerador.Generate();

            var pruebaGenerador2 = new ReportService(new GeneratorPDF());
            pruebaGenerador2.Generate();
        }
    }

    



}