namespace WebApplicationSession5.Models
{
    public class PersonModel
    {
        public  string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        //question mark is optional
        public string? Address { get; set; }
    }
}
