namespace HW2_PLINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var numbers = Enumerable.Range(0, 1000000); // doesn't work at 1 000 000 and more.
            var query =
                numbers
                    .AsParallel()
                    .Where(IsPerfectNumber)
                    .ToList();

            foreach (var v in query)
            {
                Console.WriteLine(v);
            }
        }

        private static bool IsPerfectNumber(int n)
        {
            if (n < 2)
                return false;
            
            int sum = Enumerable.Range(1, n / 2)
                .AsParallel() 
                .Where(divisor => n % divisor == 0) 
                .Sum(); 
            
            return sum == n;
        }
    }
}