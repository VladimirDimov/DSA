#Complexity Homework
##Task 1
	long Compute(int[] arr)
	{
	    long count = 0;
	    for (int i=0; i<arr.Length; i++)
	    {
	        int start = 0, end = arr.Length-1;
	        while (start < end)
	            if (arr[start] < arr[end])
	                { start++; count++; }
	            else 
	                end--;
	    }
	    return count;
	}

### Complexity: О(n*(n-1)), where n = arr.Length
####Explanation: There are 2 cycles. The outer one is executed n times. The inner one is executed n-1 times.
#####Testing example:
		static void Main(string[] args)
        {
            var matr = new int[] { 1, 2, 3, 4, 5 };


            var complexityCounter = Compute(matr);
            Console.WriteLine(complexityCounter);
        }

        static long Compute(int[] arr)
        {
            long count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int start = 0, end = arr.Length - 1;
                while (start < end)
                    if (arr[start] < arr[end])
                    { start++; count++; }
                    else
                        end--;
            }
            return count;
        }

**Result => 20**
##Task 2
	long CalcCount(int[,] matrix)
	{
	    long count = 0;
	    for (int row=0; row<matrix.GetLength(0); row++)
	        if (matrix[row, 0] % 2 == 0)
	            for (int col=0; col<matrix.GetLength(1); col++)
	                if (matrix[row,col] > 0)
	                    count++;
	    return count;
	}

### Complexity: О(n*m), where n, m are the matrix sizes.
####Explanation: The outer cycle will execute n times if the first element of the matrix row is even. The inner cycle will execute m times.
#####Testing Example:
		static void Main(string[] args)
        {
            var matr = new int[,]
            {
                {2,3,4,5,6},
                {2,3,4,5,6},
                {2,3,4,5,6},
                {2,3,4,5,6}
            };

            var complexityCounter = CalcCount(matr);
            Console.WriteLine(complexityCounter);
        }

        static long CalcCount(int[,] matrix)
        {
            long count = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
                if (matrix[row, 0] % 2 == 0)
                    for (int col = 0; col < matrix.GetLength(1); col++)
                        if (matrix[row, col] > 0)
                            count++;
            return count;
        }

**Result => 20**

##Task 3
		long CalcSum(int[,] matrix, int row)
        {
            long sum = 0;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                counter++;
                sum += matrix[row, col];
            }
            if (row + 1 < matrix.GetLength(0))
                sum += CalcSum(matrix, row + 1);
            return sum;
        }

### Complexity: О(n*m), where n, m are the matrix sizes.
####Explanation: If we put a counter in the most inner cycle the counter the code will pass through the counter exactly n*m times.
#####Testing Example:
	class Program
    {
        public static int counter = 0;

        static void Main()
        {
            var matr = new int[,]
            {
                {1,1,1,1,1},
                {1,1,1,1,1},
                {1,1,1,1,1},
                {1,1,1,1,1}
            };

            var sum = CalcSum(matr, 0);

            Console.WriteLine(sum);
            Console.WriteLine(counter);
        }

        static long CalcSum(int[,] matrix, int row)
        {
            long sum = 0;
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                counter++;
                sum += matrix[row, col];
            }
            if (row + 1 < matrix.GetLength(0))
                sum += CalcSum(matrix, row + 1);
            return sum;
        }
    }

**Result => 20**