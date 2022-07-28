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
    public  List<StudentsData> GetStudent(){
        return  studentservice.Get();
        
    }

    [HttpPost]

    public async Task<IActionResult> PostStudent(StudentsData studata){
        await studentservice.CreateAsync(studata);
        return CreatedAtAction(nameof(GetStudent),new{id=studata.Id},studata);
    }

    

    

    


}