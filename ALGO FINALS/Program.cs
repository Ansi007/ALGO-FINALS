






/*
 
Trees and their types and teriminologies

1- Tree: A undirected,acyclic connected graph.
2- Rooted Tree: Divided in levels, first node is root.
3- Binary Tree: With at max two childs at any node.
4- Balanced Tree: With height of O(lgn).
5- Full Binary Tree: If all of the nodes have exactly two childs.
6- Complete Binary Tree: If all of the nodes have exactly two childs and all of the leaves are at last level.              level.
7- Heap Tree: Completed till 2nd last level. Filled from left to right.
8- Parent,Child,Siblings,Ascedents,Descedents.
9- Level (increase top to bottom) & Height (increase bottom to top)

Q: A Complete Binary Tree of height 'h' can have at max how many nodes (n)?
A: n = (2^(h+1)) - 1

Q: A Complete Binary Tree of height 'h', have how many nodes(n) at height 'k'?
A: (2^h-k) or (n`+1)/(2^k+1)

Max Heap: Every Parent > Child
Min Heap: Every Parent < Child
Left Child = 2*i + 1
Right Child = 2*i + 2
Parent = floor(i-1/2)


 */


public class Kth_Smallest
{

/*
 
    1- Create a matrix of 5 by n/5
    2- Sort each columns
    3- Extract the middle row
    4- Find median of that row
    5- Make Small and Large array based on median
    5- if(K < indexOf(m)) FindKthSmallest(Small,K)
        else FindKthSmallest(Large,K)
    6- return KthSmallest

    T(n) = T(n/5) + T(3n/4) + O(n)

 */
    public static int FindKthSmallest(ref int[] array, int K)
    {
        int n = (array.Length)/5;
        int[,] matrix = new int[5,n];      
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = array[i]; //1- Create a matrix of 5 by n/5
            }
        }

        for (int i = 0; i < n;)
        {
            SortColumn(ref array, i);   //    2- Sort each columns
        }

        int[] middleRow = new int[n];
        for (int i = 0; i < n;i++)
        {
            middleRow[i] = matrix[3,i]; //3- Extract the middle row
        }
        int median = FindKthSmallest(ref middleRow, n / 2); //4 - Find median of that row

        int[] smallArray = new int[n];
        int[] largeArray = new int[n];
        for(int i = 0; i < array.Length; i++)
        {
            if(array[i] <= median) smallArray[i] = array[i];
        }
        
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] >median) largeArray[i] = array[i];
        }
        int medianIndex = (smallArray.Length);
        if (K < medianIndex)
            return FindKthSmallest(ref smallArray, K);
        else if (K > medianIndex)
            return FindKthSmallest(ref largeArray, medianIndex - K);
        else return median;
        //    5- if(K < indexOf(m)) FindKthSmallest(Small,K)
        // else FindKthSmallest(Large, K)
                
    }

    static void SortColumn(ref int[] array, int c)
    {
        for(int i = 0; i < 5; i++)
        {
            /*
             Sort That Column
             */
        }
    }
} 





public class QuickSort
{

/*
 
    Best Case = O(nlogn)
    Worst Case = O(n^2)

    After every iteration, pivot is at its right and sorted position
    Pivot is choosed at random
    Pivot is partitioned, left array is smaller and right is larger
    Then Quick Sort is applied on left and right array excluding the already sorted index
 
 */
    public static void Sort(ref int[] array, int i, int j)
    {

        if (i == j || i < 0 || j < 0 || j < i)
            return; //Base Case

        int pivot = new Random().Next(i, j);        //Random Pivot
        int index = Partition(ref array,i,j,pivot); //Paritioning and finding its index
        Sort(ref array, i, index - 1);  //Sorting left array
        Sort(ref array, index + 1, j);  //Sorting right array
    }

    static int Partition(ref int[] array, int i, int j,int pivotIndex)
    {
        int temp = array[i];        //Swaping first element with pivot
        array[i] = array[pivotIndex];
        array[pivotIndex] = temp;

        int p = i + 1;
        int q = j;
        while(p <= q)
        {
            if(array[p] < array[i]) //While array[p] is smaller than array[i] p++;
            {
                p++;
            }

            else if(array[q] > array[i])    //While array[q] is larger than array[i] q--;
            {
                q--;
            }

            else //Else swap qth and pth elements
            {
                int temp1 = array[p];
                array[p] = array[q];
                array[q] = temp1;
                p++;
                q--;
            }

        }
        temp = array[i]; //sawp ith element with qth and return q
        array[i] = array[q];
        array[q] = temp;
        return q;
    }


}