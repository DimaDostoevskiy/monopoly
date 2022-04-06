namespace monopoly.web.ViewModels;
public class Hero : BaseModel
{
    public Hero(int id, int x, int y, string name, string imagePath, string cssClass)
    {
        Id = id;
        Name = name;
        PositionX = x;
        PositionY = y;
        ImagePath = imagePath;
        Class = cssClass;
    }
}