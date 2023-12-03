namespace Advent_of_Code_2023.Days
{
    public class Day01 : IDay
    {
        private List<string> _input = new List<string>();
        public Day01()
        {
            _input = File.ReadAllLines(@"Days\Input\Day01.txt").ToList();
        }

        public void partOne()
        {
            var listOfNumbers = new List<List<int>>();

            foreach (var row in _input)
            {
                var digitsInRow = new List<int>();
                foreach (var c in row)
                {
                    if (Char.IsDigit(c))
                    {
                        digitsInRow.Add((int)char.GetNumericValue(c));
                    }
                }
                listOfNumbers.Add(digitsInRow);
            }

            var listOfFirstAndLastDigits = new List<int>();

            foreach (var row in listOfNumbers)
            {
                var firstDigit = row[0];
                var secondDigit = row[row.Count - 1];
                listOfFirstAndLastDigits.Add(int.Parse($"{firstDigit}{secondDigit}"));
            }

            Console.WriteLine(listOfFirstAndLastDigits.Sum());
        }

        public void partTwo()
        {
            string[] numbers = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var listOfNumbers = new List<List<int>>();

            foreach (var row in _input)
            {
                var digitsInRow = new Dictionary<int, int>();
                var numberIndex = 0;
                foreach (var number in numbers)
                {
                    var occurenses = AllIndexesOf(row, number);
                    foreach (var c in occurenses)
                    {
                        digitsInRow.Add(c, numberIndex + 1);
                    }
                    numberIndex++;
                }

                var charsIndex = 0;
                foreach (var c in row)
                {
                    if (Char.IsDigit(c))
                    {
                        digitsInRow.Add(charsIndex, (int)char.GetNumericValue(c));
                    }
                    charsIndex++;
                }

                var orderedNumbers = digitsInRow.OrderBy(x => x.Key).ToList();
                var orderedRow = new List<int>();
                foreach (var orderedNumber in orderedNumbers)
                {
                    orderedRow.Add(orderedNumber.Value);
                }
                listOfNumbers.Add(orderedRow);
            }

            var listOfFirstAndLastDigits = new List<int>();

            foreach (var row in listOfNumbers)
            {
                var firstDigit = row[0];
                var secondDigit = row[row.Count - 1];
                listOfFirstAndLastDigits.Add(int.Parse($"{firstDigit}{secondDigit}"));
            }

            Console.WriteLine(listOfFirstAndLastDigits.Sum());
        }

        public List<int> AllIndexesOf(string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }
    }
}
