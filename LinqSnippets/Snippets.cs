using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LinqSnippets
{

    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "Volkswagen Golf",
                "Volkswagen California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat León"

            };

            // 1 - SELECT * of cars (SELECT ALL CARS)
            var carList = from car in cars select car;

            foreach (var car in carList)
            {
                Console.WriteLine(car);
            }

            // 2 - SELECT WHERE car is Audi
            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }

        }

        // Number Examples
        static public void LinqNumbers()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Each number multiplied by 3; take all numbers but 9
            // Order numbers by ascending value 

            var processedNumberList =
               numbers
                .Select(num => num * 3)
                .Where(num => num != 9)
                .OrderBy(num => num); // order ascending
        }

        static public void SearchExamples()
        {
            List<string> textList = new List<string>
            {
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };

            // 1 - Search for the first element
            var first = textList.First();

            // 2 - First element that is "c"
            var cText = textList.First(text => text.Equals("c"));

            // 3 - First element that contains "j"
            var jText = textList.First(text => text.Contains("j"));

            // 4 - First element that contains Z if not dafault
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z"));

            // 5 - Last element that contains Z if not dafault
            var lastOrDefaultText = textList.LastOrDefault(text => text.Contains("z"));

            // 6 - Single values
            var uniqueTexts = textList.Single();
            var uniqueOrDefaultTexts = textList.SingleOrDefault();

            // Comparision between lists
            int[] evenNumbers = { 0, 2, 4, 6, 8 };
            int[] otherEvenNumbers = { 0, 2, 6 };

            // Obtain {4 , 8}
            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers); // only { 4, 8 )
        }

        static public void MultipleSelects()
        {
            // SELECT MANY
            string[] myOpinions =
            {
                "Opinion 1 text 1",
                "Opinion 2 text 2",
                "Opinion 3 text 3",
            };

            var myOpinionSelection = myOpinions.SelectMany(opinion => opinion.Split(","));

            var enterprises = new[]
            {
                new Enterprise()
                {
                    Id =1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 1,
                            Name = "Rui",
                            Email = "rlago@sapo.pt",
                            Salary = 3500
                        },
                        new Employee
                        {
                            Id = 2,
                            Name = "Carlos",
                            Email = "carlo@sapo.pt",
                            Salary = 3000
                        },
                        new Employee
                        {
                               Id = 3,
                            Name = "Popi",
                            Email = "popi@gmail.com",
                            Salary = 2800
                        }
                    }
                },
                 new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 2",
                    Employees = new[]
                    {
                        new Employee
                        {
                            Id = 4,
                            Name = "Ana",
                            Email = "ana.lopes@gmail.com",
                            Salary = 3000
                        },
                        new Employee
                        {
                            Id = 5,
                            Name = "Afonso",
                            Email = "af@sapo.pt",
                            Salary = 2400
                        },
                        new Employee
                        {
                               Id = 6,
                            Name = "Alex",
                            Email = "alexander.n@gmail.com",
                            Salary = 3800
                        }
                    }
                }
            };

            // Obtain all enployees of all enterprises
            var employeeList = enterprises.SelectMany(enterprise => enterprise.Employees);

            // Know if any List is empty empty
            bool hasEnterprises = enterprises.Any();

            bool hasEmployees = enterprises.Any(enterprise => enterprise.Employees.Any());

            // At least all enterprises has employees with a 1000Euro salary
            bool hasEmployeeWithSalaryMoreThanOrEqual1000 =
                enterprises.Any(enterprise =>
                    enterprise.Employees.Any(employee => 
                        employee.Salary >= 1000));

        }

        static public void linqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c" };
            var secondList = new List<string>() { "a", "c", "d" };

            // INNER JOIN
            var commonResult = from element in firstList
                               join secondElement in secondList
                               on element equals secondElement
                               select new { element, secondElement };

            var commonResult2 = firstList.Join(
                    secondList,
                    element => element,
                    secondElement => secondElement,
                    (element, seconElement) => new { element, seconElement }
                );

            // OUTER JOIN - LEFT
            var leftOuterJoin = from element in firstList
                                 join secondElement in secondList
                                 on element equals secondElement
                                 into temporalList
                                 from temporalElement in temporalList.DefaultIfEmpty()
                                 where element != temporalElement
                                 select new { Element = element };

            var leftOuterJoin2 = from element in firstList
                                 from secondElement in secondList.Where(s => s == element).DefaultIfEmpty()
                                 select new { Element = element, secondElement = secondElement };   


            //  OUTER JOIN - RIGHT
            var rightOuterJoin = from secondElement in secondList
                                join element in firstList
                                on secondElement equals element
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where secondElement != temporalElement
                                select new { Element = secondElement };

            // UNION
            var unionList = leftOuterJoin.Union(rightOuterJoin);

        }

        static public void SkipTakeLinq()
        {
            var myList = new[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            // SKIP Functions
            var skipTwoFirstValues = myList.Skip(2);

            var skipLastTwoValues = myList.SkipLast(2);

            var skipWhileSmallerThan4 = myList.SkipWhile(num => num < 4);

            // TAKE Functions
            var takeFirstTwoValues = myList.Take(2);

            var takeLastTwoValues = myList.TakeLast(2);

            var takeWhileSmallerThan4 = myList.TakeWhile(num => num < 4);

        }

        // Variables



        // ZIP


        // Repeat


        // All

        // Aggregate

        // Distinct

        // GroupBy



    }
}