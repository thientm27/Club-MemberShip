﻿using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Repository;

namespace ClubMemberShip.Service.Service;

public class ClubMemberShipService : IStudentServices, IClubActivityService, IClubServices
{
    readonly StudentRepo _studentRepo = new();
    readonly MajorRepo _majorRepo = new();
    readonly GradeRepo _gradeRepo = new();

    public Result DeleteStudent(string id)
    {
        _studentRepo.Delete(id);
        return Result.Ok;
    }

    public List<Grade>? GetGrades()
    {
        return _gradeRepo.GetAll().ToList();
    }

    public List<Major>? GetMajors()
    {
        return _majorRepo.GetAll().ToList();
    }

    public Student? GetStudent(string id)
    {
        return _studentRepo.GetById(id);
    }

    public List<Student>? GetStudents()
    {
        return _studentRepo.GetAll(includeProperties: "Major,Grade").ToList();
        // return _studentRepo.GetAll().ToList();
    }

    public int Login(string id)
    {
        if(id == "Admin@123")
        {
            return -1;
        }
        return _studentRepo.GetById(id) == null ? 0 : 1;
    }

    public Result Register(Student student)
    {
         _studentRepo.Create(student);
         return Result.Ok;
    }

    public Result UpdateStudent(Student student)
    {
        _studentRepo.Update(student);
        return Result.Ok;
    }
    
    
}
public enum Result
{
    Null,
    Ok,
    DuplicatedId,
    Fail,
}