namespace CoreDemo.Models
{
    public class UserComment
    {
        public UserComment(int ıd, string name)
        {
            Id = ıd;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

    }

}
