namespace monopoly.web.ViewModels
{
    public class Planet : BaseModel
    {
        public Planet(int id, int x, int y, string name, string imagePath, string cssClass)
        {
            Id = id;
            Name = name;
            PositionX = x;
            PositionY = y;
            ImagePath = imagePath;
            Class = cssClass;
        }
    }
}