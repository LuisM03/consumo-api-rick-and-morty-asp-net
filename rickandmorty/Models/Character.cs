namespace rickandmorty.Models
{
    public class Character
    {
        public int id;
        public string name;
        public string status;
        public string species;
        public string type;
        public string gender;
        public Origin origin;
        public LocationCharacter location;
        public string image;
        public List<string> episode;
        public string url;
        public string created;
    }
}
