namespace SurveyApp.ImageServer.Data.Models
{
    public class AppImage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
    }
}
