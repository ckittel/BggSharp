namespace BggSharp.Models
{
    public class PlayPlayer
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string StartPosition { get; set; }
        public string Color { get; set; }
        public string Score { get; set; }
        public string Rating { get; set; }
        public bool IsNew { get; set; }
        public bool Won { get; set; }        
    }
}