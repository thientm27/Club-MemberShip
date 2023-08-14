using ClubMemberShip.Repo;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.UnitOfWork;
using ClubMemberShip.Service;
using ClubMemberShip.Service.Service;

namespace ClubMemberShip.TestConsole
{
    internal class Program
    {
        public static void Main()
        {
            IUnitOfWork unitOfWork = new UnitOfWork();
            IStudentServices studentRepo = new StudentService(unitOfWork);
            IMajorService majorRepo = new MajorService(unitOfWork);
            var choose = -1;
            while (choose != 0)
            {
                ShowMenu();
                try
                {
                    choose = int.Parse(Console.ReadLine() ?? string.Empty);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    choose = -1;
                }

                switch (choose)
                {
                    case 0:
                    {
                        break;
                    }
                    case 1:
                    {
                        foreach (var item in studentRepo.Get() ?? new List<Student>())
                        {
                            Console.WriteLine(item.Id + " | " + item.Code + " | " + item.Name + " | " +
                                              item.Grade.GradeYear);
                        }

                        break;
                    }
                    case 2:
                    {
                        Console.Write("Input id: ");
                        var id = Console.ReadLine();
                        var item = studentRepo.GetById(id ?? "-1");
                        if (item == null)
                        {
                            Console.WriteLine("Not found");
                        }
                        else
                        {
                            Console.WriteLine(item.Id + " | " + item.Name);
                        }

                        break;
                    }
                    case 3:
                    {
                        try
                        {
                            Console.Write("Input id: ");
                            var id = int.Parse(Console.ReadLine() ?? string.Empty);
                            Console.Write("Input student code: ");
                            var code = Console.ReadLine();
                            Console.Write("Input name: ");
                            var name = Console.ReadLine();
                            studentRepo.Add(new Student
                            {
                                Status = Status.Active,
                                Id = id,
                                Code = code,
                                Name = name,
                                Address = "",
                                MajorId = 1,
                                GradeId = 1,
                                DateOfBirth = null,
                            });
                            Console.WriteLine("Student added");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    }
                    case 4:
                    {
                        break;
                    }
                    case 5:
                    {
                        foreach (var item in majorRepo.Get() ?? new List<Major>())
                        {
                            Console.WriteLine(item.Id + " | " + item.Code + " | " + item.Detail);
                        }

                        break;
                    }
                    case 6:
                    {
                        Console.Write("Input id: ");
                        var id = int.Parse(Console.ReadLine() ?? "-1");
                        var item = majorRepo.GetById(id);
                        if (item == null)
                        {
                            Console.WriteLine("Not found");
                        }
                        else
                        {
                            Console.WriteLine(item.Id + " | " + item.Name );
                        }
                        break;
                    }
                    case 7:
                    {
                        break;
                    }
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("-------------------&&&&&-------------------");
            Console.WriteLine("Club Member Test");
            Console.WriteLine("1. List all students");
            Console.WriteLine("2. Find student with id");
            Console.WriteLine("3. Add new student");
            Console.WriteLine("4. N/A");
            Console.WriteLine("5. List All Major");
            Console.WriteLine("6. Find Major with Code");
            Console.WriteLine("7. Add new major");
            Console.WriteLine("-------------------&&&&&-------------------");
            Console.Write("Your choice: ");
        }
    }
}