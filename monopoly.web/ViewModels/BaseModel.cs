namespace monopoly.web.ViewModels
{
    public abstract class BaseModel
    {
        public Int32 Id { get; set; }
        public Int32 PositionX { get; set; }
        public Int32 PositionY { get; set; }
        public String Name { get; set; } = String.Empty;
        public String ImagePath { get; set; } = String.Empty;
        public String Class { get; set; } = String.Empty;
    }
}