using System;
using System.Globalization;

namespace practice_algorithms {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine("Hello! Welcome to the Algorithm Program!");
            Console.WriteLine("Please enter the Algorithm you'd like to use! Options include MergeSort and CountInversions so far!");
            Console.WriteLine("Enter MS for MergeSort");
            Console.WriteLine("Enter CI for CountInversions");
            var algo = Console.ReadLine();
            while (algo != "MS" && algo != "CI") {
                Console.WriteLine("Sorry, that is not an available algorithm! Please enter a valid one!");
                algo = Console.ReadLine();
            }

            if (algo == "MS") {
            Console.WriteLine("MergeSort it is!");
            StartMergeSort();
            }
            else if (algo == "CI") {
             Console.WriteLine("Let's count some inversions!");
             StartCountInversions();
            }
        }

        public static void StartCountInversions() {
        List<int> numbers = new List<int>{};
        Console.WriteLine("Please enter the numbers from which you would like to know the number of inversions!"); 
        string[] inputs = Console.ReadLine()!.Split(' ');
        foreach (string input in inputs) {       
            int x = 0;
            var isInt = Int32.TryParse(input, out x);
            if (isInt) {
                numbers.Add(x);
                Console.WriteLine(x);
            }
        }

        List<string> inversions = new List<string>(){};

        CountInversions(numbers, inversions);
        Console.WriteLine("Inversions are: ");
        inversions.ForEach(i => Console.WriteLine(i));

        Console.WriteLine($"Total number of inversions: are: {inversions.Count()}");

        return; 

        }

        public static List<int> CountInversions(List<int> input, List<string> inversions) {

            if (input.Count() == 1) {
                return input;
            }
            else {
                
                var size = input.Count();
                var halfway = (int)Math.Floor((decimal)size / 2);
                var inputA = input.GetRange(0, halfway);
                var remainder = size - inputA.Count();
                var inputB = input.GetRange(halfway, remainder); 
            
                return MergeAndCount(CountInversions(inputA, inversions), CountInversions(inputB, inversions), inversions);
            }
    
        }
        public static List<int> MergeAndCount(List<int> inputA, List<int> inputB, List<string> inversions) {

            int i = 0;
            int j = 0;
            int inputSize = inputA.Count() + inputB.Count();
            List<int> mergedInputs = new List<int>(inputSize);

            for (int k = 0; k < inputSize; k ++) {

                if (i == inputA.Count()) {
                    mergedInputs.Add(inputB[j]);
                    j++;
                }

                else if (j == inputB.Count()) {
                    mergedInputs.Add(inputA[i]);

                    i++;
                }

                else if (inputA[i] < inputB[j]) {
                    mergedInputs.Add(inputA[i]);
                    i++;
                }
                else {
                    mergedInputs.Add(inputB[j]);
                    for (int m = i; m < inputA.Count(); m++ ) {
                        inversions.Add($"{inputB.ElementAt(j)}, {inputA.ElementAt(m)}");
                    }
                    j++;
                }
            }
            Console.WriteLine("Merged: ");
            mergedInputs.ForEach(i => Console.WriteLine(i));
            return mergedInputs;
        }

        public static void StartMergeSort() {
            List<int> numbers = new List<int>{};
            Console.WriteLine("Please enter the numbers you would like to have sorted!"); 
            string[] inputs = Console.ReadLine()!.Split(' ');
            foreach (string input in inputs) {
                
                int x = 0;
                var isInt = Int32.TryParse(input, out x);
                if (isInt) {
                    numbers.Add(x);
                    Console.WriteLine(x);
                }
            }

            MergeSort(numbers);
            return; 
        }

        public static List<int> MergeSort(List<int> input) {

            if (input.Count() == 1) {
                return input;
            }
            else {
                var size = input.Count();
                var halfway = (int)Math.Floor((decimal)size / 2);
                var inputA = input.GetRange(0, halfway);
                var remainder = size - inputA.Count();
                var inputB = input.GetRange(halfway, remainder); 
            
                return Merge(MergeSort(inputA), MergeSort(inputB));
            }
    
        }

        public static List<int> Merge(List<int> inputA, List<int> inputB) {

            int i = 0;
            int j = 0;
            int inputSize = inputA.Count() + inputB.Count();
            List<int> mergedInputs = new List<int>(inputSize);

            for (int k = 0; k < inputSize; k ++) {

                if (i == inputA.Count()) {
                    mergedInputs.Add(inputB[j]);
                    j++;
                }

                else if (j == inputB.Count()) {
                    mergedInputs.Add(inputA[i]);

                    i++;
                }

                else if (inputA[i] < inputB[j]) {
                    mergedInputs.Add(inputA[i]);
                    i++;
                }
                else {
                    mergedInputs.Add(inputB[j]);
                    j++;
                }
            }
            Console.WriteLine("Merged: ");
            mergedInputs.ForEach(i => Console.WriteLine(i));
            return mergedInputs;
        }
    }
}