﻿using Microsoft.AspNetCore.Mvc;
using Serilog;

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
    public JsonResult Move(string derection, string name)
    {
        Log.Logger.Warning($" Move id : {name} | derection : {derection}");

        var obj = db.FirstOrDefault(x => x.Name == name);

        if (obj == null) return Json(null);

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
        return Json(obj);
    }

    public IActionResult Area() => View(db);

    public JsonResult Info(string? name)
    {
        Log.Logger.Warning($" Info id : {name} ");
        if(name == null) return Json(null);
        return Json(db.FirstOrDefault(x => x.Name == name));
    }
}