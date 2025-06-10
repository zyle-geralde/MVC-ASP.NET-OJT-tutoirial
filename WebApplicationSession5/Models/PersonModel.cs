namespace WebApplicationSession5.Models
{
    public class PersonModel
    {
        public  string Id { get; set; }
        public int Name { get; set; }
        public int Age { get; set; }
        //question mark is optional
        public int? Address { get; set; }
    }
}
