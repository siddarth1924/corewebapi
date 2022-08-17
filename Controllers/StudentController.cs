using Microsoft.AspNetCore.Mvc;

using corewebapi.Model;
using corewebapi.Services;

namespace corewebapi.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    public readonly StudentService studentservice;

    public StudentController(StudentService studentservice){
        this.studentservice = studentservice;

    }
    [HttpGet]
    [Route("/getstudents")]
    public  List<StudentsData> GetStudent(){
        return  studentservice.Get();
        //throw new NotImplementedException();
    }
    

[HttpGet]
[Route("/test")]
public List<StudentsData> TestStudent(){
//throw new NotImplementedException();
return  studentservice.Get();
}


    [HttpPost]
    [Route("/addstudent")]

    public async Task<IActionResult> PostStudent(StudentsData studata){
        await studentservice.CreateAsync(studata);
        return CreatedAtAction(nameof(GetStudent),new{id=studata.Id},studata);
    }

    

    

    


}