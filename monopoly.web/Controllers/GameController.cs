using Microsoft.AspNetCore.Mvc;
using monopoly.web.ViewModels;
using Serilog;

namespace monopoly.web.Controllers;
public class GameController : Controller
{
    public static List<BaseModel> db = new List<BaseModel>() {
        new Planet(100, 100,"planet1","https://www.pngmart.com/files/3/Space-Planet-PNG-Photo.png", "planet"),
        new Planet(500, 200,"planet2","https://www.pngmart.com/files/3/Space-Planet-PNG-Transparent.png", "planet"),
        new Planet(100, 200,"planet3","https://www.pngmart.com/files/3/Space-Planet-PNG-HD.png", "planet"),
        new   Hero(300, 300,"hero",   "https://www.citypng.com/public/uploads/preview/hd-cartoon-illustration-flying-rocket-png-31629804671iyeioqeuju.png", "hero"),
        };
    public GameController()
    {
    }
    public JsonResult Move(string derection, string name)
    {
        Log.Logger.Warning($" Move Name : {name} | derection : {derection}");

        var obj = db.FirstOrDefault(x => x.Name == name);

        if (obj == null) return Json(null);

        if(obj.GetUrl != null)
        {
            obj.GetUrl = null;
        }
        if (derection.Contains("1"))
        {
            obj.PositionY -= 50;
        }
        if (derection.Contains("2"))
        {
            obj.PositionX += 50;
        }
        if (derection.Contains("3"))
        {
            obj.PositionY += 50;
        }
        if (derection.Contains("4"))
        {
            obj.PositionX -= 50;
        }

        var contactObject = db.FirstOrDefault(x => x.PositionX == obj.PositionX 
                                                && x.PositionY == obj.PositionY 
                                                && x.Name != obj.Name);
        if (contactObject != null)
        {
            if (contactObject is Planet)
            {
                Log.Logger.Warning($"   Planet! {contactObject.Name}");
                obj.GetUrl = "https://localhost:7232/Game/Planet?name=" + contactObject.Name;
            }
        }
        return Json(obj);
    }
    [HttpGet]
    public JsonResult Info(string? name) => Json(db.FirstOrDefault(x => x.Name == name));
    [HttpGet]
    public IActionResult Area() => View(db);
    [HttpGet]
    public IActionResult Planet(string name) => View(db.FirstOrDefault(x => x.Name == name));
}       