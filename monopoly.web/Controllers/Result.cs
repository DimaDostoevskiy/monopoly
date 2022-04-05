namespace monopoly.web.Controllers;
public class Result
{
    public Int32 Id;
    public String Name { get; set; } = String.Empty;
    public Int32 PositionX { get; set; }
    public Int32 PositionY { get; set; }
    public String ImagePath { get; set; } = String.Empty;
    public String Class { get; set; } = String.Empty;
    public Result(int id, int x, int y, string name, string imagePath, string cssClass = "")
    {
        Id = id;
        PositionX = x;
        PositionY = y;
        ImagePath = imagePath;
        Name = name;
        Class = "base-class " + cssClass;
    }
}