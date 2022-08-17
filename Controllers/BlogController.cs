using Microsoft.AspNetCore.Mvc;

using corewebapi.Model;
using corewebapi.Services;

namespace corewebapi.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogController : ControllerBase
{
    public readonly UserService userservice;

    public BlogController(UserService userservice){
        this.userservice = userservice;

    }
    [HttpGet]
    [Route("/getuser")]
    public  List<UserData> GetUser(){
        return  userservice.Get();
        //throw new NotImplementedException();
    }
    
    [HttpGet("{LoginID}")]
    [Route("/getuserbyid/{LoginID}")]
    public ActionResult<UserData> GetUserByID(String LoginID){

        var x= userservice.GetByID(LoginID);
        if(x==null){
            return NotFound($"User not found");
        }
         return x;
    }



    [HttpPost]
    [Route("/adduser")]

    public async Task<IActionResult> PostUser(UserData userdata){
        await userservice.CreateAsync(userdata);
        return CreatedAtAction(nameof(GetUser),new{id=userdata.Id},userdata);
    }

    

    

    


}