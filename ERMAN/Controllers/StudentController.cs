﻿using ERMAN.Dtos;
using ERMAN.Models;
using ERMAN.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERMAN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentRepository _studentRepo;
        public StudentController(StudentRepository studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [HttpPost(Name = "StudentPost")]
        public void Post(StudentDto student)
        {
            _studentRepo.Add(student);
        }

        [HttpPut("/api/Student/addCourses", Name = "StudentAddSelecetedCourses")]
        public void PutCourses(int id, List<CourseMapped> courses)
        {
            _studentRepo.UpdateStudentSelectedCourses( id,  courses);
        }

        [HttpPut("/api/Student/approveStatus", Name = "StudentApproveCourseStatus")]
        public void SetSelectedCourseAs(int id, int mappedId, ApprovedStatus approvedStatus)
        {
            _studentRepo.Get(id).SelectedCourses.FirstOrDefault(x => x.Id == mappedId).ApprovedStatus = approvedStatus;
            _studentRepo.Update();
        }

        [HttpPut("/api/Student/removeCourse", Name = "StudentRemoveCourse")]
        public void RemoveSelectedCourse(int id, int mappedId)
        {
            CourseMapped course = _studentRepo.Get(id).SelectedCourses.FirstOrDefault(x => x.Id == mappedId);
            _studentRepo.Get(id).SelectedCourses.Remove(course);
            _studentRepo.Update();
        }

        [HttpGet(Name = "StudentGet")]
        public Student Get(int id)
        {
            return _studentRepo.Get(id);
        }

        [HttpGet("/api/Student/all", Name = "StudentGetAll")]
        public List<Student> GetAll()
        {
            return _studentRepo.GetAll();
        }

        [HttpGet("/api/Student/SelectedCourses", Name = "StudentGetSelecetedCourses")]
        public List<CourseMapped> getCourses( int id)
        {
            return _studentRepo.Get(id).SelectedCourses;
        }

        [HttpDelete(Name = "StudentDelete")]
        public Student Delete(int id)
        {
            return _studentRepo.Remove(id);
        }

        //[HttpPut(Name = "StudentPut")]
        //public void Put()
        //{
        //    _studentRepo.Update();
        //}

    }
}
