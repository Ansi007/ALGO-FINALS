
int[] array = {18,19,20,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17 };
QuickSort.Sort(ref array,0,array.Length);

public class HomeWork02B
{
    void p1Searching(int[] A, int X)
    {
        /*
            Sort the array,
        int i = 0; int j = n - 1;
        while(i < j){
         if(A[i]+A[j]==X) return i,j;
         else if(A[i]+A[j]<X) return i++;
         else return j--;

         */
    }

    void p2Decision(int[] S1, int[] S2)
    {
        /*
            Sort the sets (nlogn)
        int i = 0; int j = 0;
        while(i < j){
         if(S1[i]==S2[j]) return false;
         else if(S1[i]<S2[j]) return i++;
         else return j--;
         */
    }

    void p3FindTwoMinimums(int[] array)
    {

    }

    void p4FindRange(int[] array, int a, int b)
    {
        //  5 4 3 7 8 3 5 6 2 2 3 6 89 67 5 4 3 2 3 3 4 56 6 78 9
        //Find Maximum Number for this case its 89
        // 3 39
    }

    void p5Sort(int[] array)
    {
    /*
        Extract lgn unique elements (n)
        now are n = lgn
        Apply any sort(lgn) nlglgn
        Reinsert duplicated where they belongs (n)
        T(n) = n + nlglgn + n
        O(nlglgn)

         
         */
    }
}







public class HomeWork02A
{
    void p1Searching(int[] A, int X)
    {
        /*
            Sort the array,
        int i = 0; int j = n - 1;
        while(i < j){
         if(A[i]+A[j]==X) return i,j;
         else if(A[i]+A[j]<X) return i++;
         else return j--;

         */
    }

    void p2Decision(int[] S1, int[] S2)
    {
        /*
            Sort the sets (nlogn)
        int i = 0; int j = 0;
        while(i < j){
         if(S1[i]==S2[j]) return false;
         else if(S1[i]<S2[j]) return i++;
         else return j--;
         */
    }

    void p3MaxSubArray(int[] a, int size)
    {
        int max_so_far = int.MinValue,
        max_ending_here = 0, start = 0,
        end = 0, s = 0;


        // 1 5 -2 4 5 -4 2 -10

        // -2 -3 4 -1 -2 1 5 -3

        for (int i = 0; i < size; i++)
        {
            max_ending_here += a[i];

            if (max_so_far < max_ending_here)
            {
                max_so_far = max_ending_here;
                start = s;  // 0 0 0 0
                end = i;    // 0 1 3 4
            }

            if (max_ending_here < 0)
            {
                s = i + 1; //2
                max_ending_here = 0;
            }
        }
        //return start,end
        //O(n)
    }

    static int maxCrossingSum(int[] arr, int l, int m,
                              int h)
    {
        // Include elements on left of mid.
        int sum = 0;
        int left_sum = int.MinValue;
        for (int i = m; i >= l; i--)
        {
            sum = sum + arr[i];
            if (sum > left_sum)
                left_sum = sum;
        }

        // Include elements on right of mid
        sum = 0;
        int right_sum = int.MinValue;
        ;
        for (int i = m + 1; i <= h; i++)
        {
            sum = sum + arr[i];
            if (sum > right_sum)
                right_sum = sum;
        }

        // Return sum of elements on left
        // and right of mid
        // returning only left_sum + right_sum will fail for
        // [-2, 1]
        return Math.Max(left_sum + right_sum,
                        Math.Max(left_sum, right_sum));
    }

    // Returns sum of maximum sum subarray
    // in aa[l..h]
    int p3maxSubArraySum(int[] arr, int l, int h)
    {

        // Base Case: Only one element
        if (l == h)
            return arr[l];

        // Find middle point
        int m = (l + h) / 2;

        /* Return maximum of following three
        possible cases:
        a) Maximum subarray sum in left half
        b) Maximum subarray sum in right half
        c) Maximum subarray sum such that the
        subarray crosses the midpoint */
        return Math.Max(
            Math.Max(p3maxSubArraySum(arr, l, m),
                     p3maxSubArraySum(arr, m + 1, h)),
            maxCrossingSum(arr, l, m, h));
    }



    int p4Searching(int[] arr, int low, int high)
        {
        // This condition is needed to handle the case
        // when the array is not rotated at all
        if (high < low)
            return 0;

        // If there is only one element left
        if (high == low)
            return low;

        // Find mid
        int mid = low + (high - low) / 2; /*(low + high)/2;*/

        // Check if element (mid+1) is minimum element.
        // Consider the cases like {3, 4, 5, 1, 2}
        if (mid < high && arr[mid + 1] < arr[mid])
            return (mid + 1);

        // Check if mid itself is minimum element
        if (mid > low && arr[mid] < arr[mid - 1])
            return mid;

        // Decide whether we need to go to left half or
        // right half
        if (arr[high] > arr[mid])
            return p4Searching(arr, low, mid - 1);

        return p4Searching(arr, mid + 1, high);
    }


    /*
     
    Problem 6: Design an array, the array is:
     // 18 19 20 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17
     
     */



    /*
            Problem 7:

    Sort(A,i,j){
        Find random pivot
        Call Partition(A,i,j,pivot)
        Partition will return us IndexStart, IndexEnd
        Call Sort(A,i,IndexStart - 1)
        Call Sort(A,IndexEnd + 1,j)
    }

    Partition(A,i,j,pivot){
        First find how many repeated pivots elements are there store them in count
        Then remove other repeated elements except the pivot
        Change pivot = new Pivot Index of modifed Array
        Do the previous simple Parition Procedure and find the ideal position of pivot
        Then re insert those removed elements after pivot
        Return pivot, pivot + count
    } 
     */





    /*
     
    Problem 8:
        ElementUnique(A){
            if(FindMode(A) == 0) //O(nlogn)
                return true;
            else return false;
    }

    It is stated that ElementUnique best case is O(nlogn),FindMode will also be
    O(nlogn)
     
   */
}







public class MaxHeap
{

    /*
        Every Parent is greater than childs
        BuildMaxHeap(){ //O(n)
            foreach node heapify 
    }
     */



}






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


public class QuickSortModifiedForRepeatElements
{


    public static void Sort(ref int[] array, int i, int j)
    {

        if (i == j || i < 0 || j < 0 || j < i)
            return; //Base Case

        int pivot = new Random().Next(i, j);        //Random Pivot
        int index = Partition(ref array, i, j, pivot); //Paritioning and finding its index
        Sort(ref array, i, index - 1);  //Sorting left array
        Sort(ref array, index + 1, j);  //Sorting right array
    }

    static int Partition(ref int[] array, int i, int j, int pivotIndex)
    {
        int count = -1;
        for(int I = i; I <= j; I++)
        {
            if (array[i] == array[pivotIndex])
                count++;
        }

        int[] tempArray = new int[(j - i + 1) - count];
        int k = 0;
        for (int I = i; I <= j; I++)
        {
            if (array[i] == array[pivotIndex] && i == pivotIndex)
                tempArray[k++] = array[i];

            else if (array[i] == array[pivotIndex] && i == pivotIndex)
                continue;

            else tempArray[k++] = array[i];

        }


        int temp = tempArray[i];        //Swaping first element with pivot
        tempArray[i] = tempArray[pivotIndex];
        tempArray[pivotIndex] = temp;

        int p = i + 1;
        int q = j;

        while (p <= q)
        {
            if (tempArray[p] < tempArray[i]) //While array[p] is smaller than array[i] p++;
            {
                p++;
            }

            else if (tempArray[q] > tempArray[i])    //While array[q] is larger than array[i] q--;
            {
                q--;
            }

            else //Else swap qth and pth elements
            {
                int temp1 = tempArray[p];
                tempArray[p] = tempArray[q];
                tempArray[q] = temp1;
                p++;
                q--;
            }

        }
        temp = tempArray[i]; //sawp ith element with qth and return q
        tempArray[i] = tempArray[q];
        tempArray[q] = temp;

        for(int I  = 0; I < count; I++)
        {
            //Re insert tempArray[q] between q and the next index
        }
        //then return q and q + count
        return q;
    }


}