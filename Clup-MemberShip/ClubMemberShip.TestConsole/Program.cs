using ClubMemberShip.Repo.Repository;
using System;
using System.Diagnostics;
using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Repository.Implement;

namespace TestConsole // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // StudentRepo studentRepo = new StudentRepo();    
            // MajorRepo majorRepo = new MajorRepo();    
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
                            // foreach (var item in studentRepo.GetAll(includeProperties: "Major,Grade"))
                            // {
                            //     Console.WriteLine(item.Id + " | " + item.Name + " | " + item.Grade.GradeYear);
                            // }
                            break;
                        }
                    case 2:
                    {
                        // Console.Write("Input id: ");
                        // var id = Console.ReadLine();
                        // var item = studentRepo.GetById(id);
                        // if (item == null)
                        // {
                        //     Console.WriteLine("Not found");
                        // }
                        // else
                        // {
                        //     Console.WriteLine(item.Id + " | " + item.Name );
                        // }
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
                            // foreach (var item in majorRepo.GetAll(includeProperties: ""))
                            // {
                            //     Console.WriteLine(item.Id + " | " + item.Code + " | " + item.Detail);
                            // }
                            break;
                        }
                    case 6:
                    {
                        
                        break;
                    }
                    case 7:
                    {
                        break;
                    }
                }
                
            }
            

        }

        public static void ShowMenu()
        {
            Console.WriteLine("-------------------&&&&&-------------------");
            Console.WriteLine("Club Member Test");
            Console.WriteLine("1. List all students");
            Console.WriteLine("2. Find student with id");
            Console.WriteLine("3. N/A");
            Console.WriteLine("4. N/A");
            Console.WriteLine("5. List All Major");
            Console.WriteLine("6. Find Major with Code");
            Console.WriteLine("7. Add new major");
            Console.WriteLine("-------------------&&&&&-------------------");
            Console.Write("Your choice: ");
            
        }
    }
}