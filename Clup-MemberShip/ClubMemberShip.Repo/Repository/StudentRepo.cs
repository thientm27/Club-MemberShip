using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace ClubMemberShip.Repo.Repository;

public class StudentRepo : GenericRepo<Student>, IStudentRepo
{
    public override void Delete(object? id)
    {
        using var context = new ClubMembershipContext();
        Student? std = GetById(id);
        // context.Students.FirstOrDefault(o => o.Id == id);
        if (std != null)
        {
            std.Status = 0;
            context.Attach(std).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
        
    // public List<Student>? GetAllStudents(){
    //       var _context = new ClubMembershipContext();
    //     return _context.Students
    //         .Include(s => s.Grade)
    //         .Include(s => s.Major).ToList();
    // }
    // public List<Grade>? GetAllGrades()
    // {
    //     var _context = new ClubMembershipContext();
    //     return _context.Grades.ToList();
    //
    // }
    // public List<Major>? GetAllMajors()
    // {
    //     var _context = new ClubMembershipContext();
    //     return _context.Majors.ToList();
    //
    // }
    // public Student? GetStudent(string id)
    // {
    //     using var context = new ClubMembershipContext();
    //     return context.Students.FirstOrDefault(m => m.Id == id);
    // }

    // public Result UpdateStudent(Student student)
    // {
    //     if (student == null)
    //     {
    //         return Result.Null;
    //     }
    //     var _context = new ClubMembershipContext();
    //     _context.Attach(student).State = EntityState.Modified;
    //     _context.SaveChanges();
    //     return Result.Ok;
    // }
    //
    // public Result AddStudent(Student student)
    // {
    //     var _context = new ClubMembershipContext();
    //     if (_context.Students == null || student == null)
    //     {
    //         return Result.Null;
    //     }
    //     Student? std = _context.Students.FirstOrDefault(o => o.Id == student.Id);
    //     if (std != null)
    //     {
    //         return Result.DuplicatedId;
    //     }
    //     _context.Students.Add(student);
    //     _context.SaveChanges();
    //     return Result.Ok;
    // }

}