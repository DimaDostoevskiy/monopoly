using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Text.Encodings.Web;
namespace monopoly.web.Controllers;
public class GameController : Controller
{
    public static List<Result> db = new List<Result>() {
        new Result(1, 100, 100,"planet1","https://www.pngmart.com/files/3/Space-Planet-PNG-Photo.png", "planet"),
        new Result(2, 500, 200,"planet2","https://www.pngmart.com/files/3/Space-Planet-PNG-Transparent.png", "planet"),
        new Result(3, 100, 200,"planet3","https://www.pngmart.com/files/3/Space-Planet-PNG-HD.png", "planet"),
        new Result(4, 300, 300,"hero","https://www.citypng.com/public/uploads/preview/hd-cartoon-illustration-flying-rocket-png-31629804671iyeioqeuju.png", "hero"),
        };
        
    public GameController()
    {
    }

    [HttpGet]
    public JsonResult Move(string derection, int id)
    {
        Log.Logger.Warning($"id : {id} | derection : {derection}");

        var obj = db.FirstOrDefault(x => x.Id == id);

        if (obj == null) return Json(null);

        if(derection.Contains("up"))
        {
            obj.PositionY -= 50;
        }
        if(derection.Contains("down"))
        {
            obj.PositionY += 50;
        }
        if(derection.Contains("left"))
        {
            obj.PositionY += 50;
        }
        if(derection.Contains("reight"))
        {
            obj.PositionY += 50;
        }
        return Json(obj);
    }

    [HttpGet]
    public IActionResult Area()
    {
        return View(db);
    }

    [HttpGet]
    public IActionResult Info(int? id)
    {
        return (id == null) ? BadRequest() : Json(db.FirstOrDefault(x => x.Id == id));
    }
}