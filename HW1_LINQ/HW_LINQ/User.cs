
namespace HW1_LINQ
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public User(int id, string name, string surname)
        {
            this.ID = id;
            this.Name = name;
            this.Surname = surname;
        }

        public override string ToString()
        {
            return $"ID={ID}: {Name} {Surname}";
        }
    }
}