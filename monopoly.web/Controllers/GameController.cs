using Microsoft.AspNetCore.Mvc;
using monopoly.web.ViewModels;
using Serilog;

namespace monopoly.web.Controllers;
public class GameController : Controller
{
    public static List<BaseModel> db = new List<BaseModel>() {
        new Planet(1, 100, 100, "planet1", "~/img/planet1.png", "planet"),
        new Planet(2, 500, 200, "planet2", "~/img/planet2.png", "planet"),
        new Planet(3, 100, 200, "planet3", "~/img/planet3.png", "planet"),
        new Planet(4, 400, 700, "planet4", "~/img/planet4.png", "planet"),
        new Hero  (5, 300, 300, "hero", "~/img/rocket3.png", "hero"),
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
    public JsonResult Info(string? name)
    {
        Log.Logger.Warning($"   !InFo name: {name}");
        return Json(db
            .FirstOrDefault(x => x.Name == name));
    }

    //To MVC controller
    [HttpGet]
    public IActionResult Area() => View(db);
    [HttpGet]
    public IActionResult Planet(string name) => View(db.FirstOrDefault(x => x.Name == name));
}