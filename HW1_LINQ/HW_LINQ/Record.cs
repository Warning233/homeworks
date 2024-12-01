
namespace HW1_LINQ
{
    public class Record
    {
        public User Author { get; set; }
        public string Message { get; set; }

        public Record(User author, string message)
        {
            this.Author = author;
            this.Message = message;
        }
    }
}