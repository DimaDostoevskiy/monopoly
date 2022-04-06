namespace monopoly.web.ViewModels
{
    public class Planet : BaseModel
    {
        public Planet(int x, int y, string name, string imagePath, string cssClass)
        {
            Name = name;
            PositionX = x;
            PositionY = y;
            ImagePath = imagePath;
            Class = cssClass;
        }
    }
}