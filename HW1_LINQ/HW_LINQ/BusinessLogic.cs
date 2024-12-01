namespace HW1_LINQ
{
    public class BusinessLogic
    {
        private List<User> users = new List<User>();
        private List<Record> records = new List<Record>();

        public BusinessLogic()
        {
            users.Add(new User(0, "Rob", "Smith"));
            users.Add(new User(1, "John", "Adams"));
            users.Add(new User(2, "Chris", "Switch"));
            users.Add(new User(3, "Carl", "Grow"));
            users.Add(new User(4, "Mark", "Collinze"));

            records.Add(new Record(users[0], "Hi there"));
            records.Add(new Record(users[1], "I'm there"));
            records.Add(new Record(users[2], "I'm a newbie"));
            records.Add(new Record(users[3], "How are you?"));
            records.Add(new Record(users[4], "Hello!"));
        }

        public List<User> GetUsersBySurname(string surname)
        {
            var result = from u in users
                where u.Surname == surname
                select u;

            return result.ToList();
        }

        public User GetUserByID(int id)
        {
            var result = from u in users
                where u.ID == id
                select u;

            try
            {
                return result.Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return result.Single();
        }

        public List<User> GetUsersBySubstring(string substring)
        {
            var result = from u in users
                where ((u.Name.Contains(substring)) || (u.Surname.Contains(substring)))
                select u;

            return result.ToList();
        }

        public List<String> GetAllUniqueNames()
        {
            var result = from u in users
                select u.Name;

            return result.Distinct().ToList();
        }

        public List<User> GetAllAuthors()
        {
            var result = from u in users
                join r in records on u equals r.Author
                select u;

            return result.ToList();
        }

        public Dictionary<int, User> GetUsersDictionary()
        {
            var result = users.ToDictionary(u => u.ID, u => u);

            return result;
        }

        public int GetMaxID()
        {
            var result = from u in users
                select u.ID;

            return result.Max();
        }

        public List<User> GetOrderedUsers()
        {
            var result = from u in users
                orderby u.ID
                select u;

            return result.ToList();
        }

        public List<User> GetDescendingOrderedUsers()
        {
            var result = from u in users
                orderby u.ID descending
                select u;

            return result.ToList();
        }

        public List<User> GetReversedUsers()
        {
            var result = (from u in users select u).Reverse();

            return result.ToList();
        }

        public List<User> GetUsersPage(int pageSize, int pageIndex)
        {
            var result = users.Skip(pageSize * (pageIndex - 1)).Take(pageSize);

            return result.ToList();
        }
    }
}