using System;

namespace BinaryTreeUniversity
{
    class Program
    {
        static void Main(string[] args)
        {
            //SE CREAN LOS OBJETOS QUE SE NECESITAN
            Position rectorPosition = new Position();
            rectorPosition.Name = "Rector";
            rectorPosition.Salary = 1000;
            rectorPosition.PorTax = 30;
            //CALCULO EL VALOR DEL IMPUESTO DEL SUELDO
            rectorPosition.TaxValue = (rectorPosition.Salary * rectorPosition.PorTax) / 100;

            Position vicFinPosition = new Position();
            vicFinPosition.Name = "Vicerector Financiero";
            vicFinPosition.Salary = 750;
            vicFinPosition.PorTax = 25;
            vicFinPosition.TaxValue = (vicFinPosition.Salary * vicFinPosition.PorTax) / 100;

            Position contadorPosition = new Position();
            contadorPosition.Name = "Contador";
            contadorPosition.Salary = 500;
            contadorPosition.PorTax = 20;
            contadorPosition.TaxValue = (contadorPosition.Salary * contadorPosition.PorTax) / 100;

            Position jefeFinPosition = new Position();
            jefeFinPosition.Name = "Jefe Financiero";
            jefeFinPosition.Salary = 610;
            jefeFinPosition.PorTax = 20;
            jefeFinPosition.TaxValue = (jefeFinPosition.Salary * jefeFinPosition.PorTax) / 100;

            Position secFin1Position = new Position();
            secFin1Position.Name = "Secretaria Financiera 1";
            secFin1Position.Salary = 350;
            secFin1Position.PorTax = 15;
            secFin1Position.TaxValue = (secFin1Position.Salary * secFin1Position.PorTax) / 100;

            Position secFin2Position = new Position();
            secFin2Position.Name = "Secretaria Financiera 2";
            secFin2Position.Salary = 310;
            secFin2Position.PorTax = 15;
            secFin2Position.TaxValue = (secFin2Position.Salary * secFin2Position.PorTax) / 100;

            Position vicAcademicoPosition = new Position();
            vicAcademicoPosition.Name = "Vicerector Academico";
            vicAcademicoPosition.Salary = 780;
            vicAcademicoPosition.PorTax = 25;
            vicAcademicoPosition.TaxValue = (vicAcademicoPosition.Salary * vicAcademicoPosition.PorTax) / 100;

            Position jefeRegPosition = new Position();
            jefeRegPosition.Name = "Jefe de registro Academico";
            jefeRegPosition.Salary = 640;
            jefeRegPosition.PorTax = 20;
            jefeRegPosition.TaxValue = (jefeRegPosition.Salary * jefeRegPosition.PorTax) / 100;

            Position secGen2Position = new Position();
            secGen2Position.Name = "Secretaria General 2";
            secGen2Position.Salary = 360;
            secGen2Position.PorTax = 15;
            secGen2Position.TaxValue = (secGen2Position.Salary * secGen2Position.PorTax) / 100;

            Position secGen1Position = new Position();
            secGen1Position.Name = "Secretaria General 1";
            secGen1Position.Salary = 400;
            secGen1Position.PorTax = 15;
            secGen1Position.TaxValue = (secGen1Position.Salary * secGen1Position.PorTax) / 100;

            Position asistente2Position = new Position();
            asistente2Position.Name = "Asistente 2";
            asistente2Position.Salary = 170;
            asistente2Position.PorTax = 10;
            asistente2Position.TaxValue = (asistente2Position.Salary * asistente2Position.PorTax) / 100;

            Position mensajeroPosition = new Position();
            mensajeroPosition.Name = "Mensajero";
            mensajeroPosition.Salary = 90;
            mensajeroPosition.PorTax = 5;
            mensajeroPosition.TaxValue = (mensajeroPosition.Salary * mensajeroPosition.PorTax) / 100;

            Position asistente1Position = new Position();
            asistente1Position.Name = "Asistente 1";
            asistente1Position.Salary = 250;
            asistente1Position.PorTax = 10;
            asistente1Position.TaxValue = (asistente1Position.Salary * asistente1Position.PorTax) / 100;

            //CREO EL ARBOL DE UNIVERSIDAD
            UniversityTree universityTree = new UniversityTree();
            //CREO LOS CARGOS
            universityTree.CreatePosition(null, rectorPosition, null);
            universityTree.CreatePosition(universityTree.Root, vicFinPosition, rectorPosition.Name);

            universityTree.CreatePosition(universityTree.Root, contadorPosition, vicFinPosition.Name);
            universityTree.CreatePosition(universityTree.Root, secFin1Position, contadorPosition.Name);
            universityTree.CreatePosition(universityTree.Root, secFin2Position, contadorPosition.Name);

            universityTree.CreatePosition(universityTree.Root, jefeFinPosition, vicFinPosition.Name);

            universityTree.CreatePosition(universityTree.Root, vicAcademicoPosition, rectorPosition.Name);

            universityTree.CreatePosition(universityTree.Root, jefeRegPosition, vicAcademicoPosition.Name);
            universityTree.CreatePosition(universityTree.Root, secGen2Position, jefeRegPosition.Name);
            universityTree.CreatePosition(universityTree.Root, secGen1Position, jefeRegPosition.Name);
            universityTree.CreatePosition(universityTree.Root, asistente2Position, secGen1Position.Name);
            universityTree.CreatePosition(universityTree.Root, mensajeroPosition, asistente2Position.Name);
            universityTree.CreatePosition(universityTree.Root, asistente1Position, secGen1Position.Name);
            
            Console.WriteLine("{0,28} {1,6} {2,6} {3,8}", "POSITION", "SALARY", "% TAX", "TAX VALUE\n");
            //LLAMO EL METODO IMPRIMIR ARBOL
            universityTree.PrintTree(universityTree.Root);

            //LLAMO EL METODO QUE SUMA LOS SALARIOS PARTIENDO DESDE LA POSICION ROOT
            float sumSalary1 = universityTree.SumSalaries(universityTree.Root);
            //IMPRIME EL VALOR DE LOS SALARIOS
            Console.WriteLine("\n{0,28} {1,7}", "The sum of salaries is:", $"{sumSalary1} ");

            //LLAMO EL METODO MAYOR SALARIO POR LA DERECHA Y POR LA IZQUIERDA             
            float higherLeft = universityTree.SalaryHigher(universityTree.Root.Left);
            float higherRight = universityTree.SalaryHigher(universityTree.Root.Right);
            //IDENTIFICO EL SALARIO MAS ALTO Y LO IMPRIMO
            if (higherLeft >= higherRight)
            {
                Console.WriteLine($"\nP 1. The higher salary is: {higherLeft} ");
            }
            else 
            { 
                Console.WriteLine($"\nP 1. The higher salary is: {higherRight} "); 
            }

            //LLAMO EL METODO DE CONTEO DE NODOS  
            float count1 = universityTree.Count(universityTree.Root);
            //CALCULO EL PROMEDIO DE SALARIOS.  
            double promedio = (sumSalary1 / count1);
            //REDONDEO CON UN DECIMAL 
            promedio = Math.Round(promedio,1);
            //IMPRIMO EL PROMEDIO DE SALARIOS
            Console.WriteLine($"\nP 2. The average salary is: {promedio}");
            
            //LLAMO EL METODO PARA BUSCAR EL CARGO Y LE INGRESO EL CARGO QUE QUIERO BUSCAR
            PositionNode position = universityTree.SearchNodo(universityTree.Root, vicFinPosition.Name);
            //LLAMO EL METODO PARA SUMAR SALARIOS DESDE EL CARGO QUE SE REQUIERA
            float sumSalary2 = universityTree.SumSalaries(position);
            //LLAMO EL METODO PARA CONTAR LOS NODOS DESDE EL CARGO QUE SE REQUIERA 
            float count2 = universityTree.Count(position);           
            Console.WriteLine($"\nP 3. The average salaries from position {position.Position.Name}" + $" is: {sumSalary2 / count2}");

            //LLAMO EL METODO PARA SUMAR IMPUESTOS E IMPRIMO EL TOTAL DE LOS IMPUESTOS PARTIENDO DE ROOT
            float sumTax = universityTree.SumTax(universityTree.Root);
            Console.WriteLine($"\nP 4.The total taxes are: {sumTax}");
            
            Console.ReadLine();            
        }
    }           
}

              
