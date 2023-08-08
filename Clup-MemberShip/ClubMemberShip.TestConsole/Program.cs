using ClubMemberShip.Repo.Repository;
using System;

namespace TestConsole // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            StudentRepo studentRepo = new StudentRepo();    
            var choose = -1;
            while(choose != 0)
            {
                ShowMenu();
                try
                {
                    choose = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
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
                            foreach (var item in studentRepo.GetAllStudents())
                            {
                                Console.WriteLine(item.Name);
                            }
                            break;
                        }
                    case 2:
                        {
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                    case 4:
                        {
                            break;
                        }
                    case 5:
                        {
                            break;
                        }
                }
                
            }
            

        }

        public static void ShowMenu()
        {
            Console.WriteLine("Club Member Test");
            Console.WriteLine("1.");
            Console.WriteLine("2.");
        }
    }
}