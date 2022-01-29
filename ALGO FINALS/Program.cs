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
    public void Sort(ref int[] array, int i, int j)
    {

        if (i == j || i < 0 || j < 0 || j < i)
            return; //Base Case

        int pivot = new Random().Next(i, j);        //Random Pivot
        int index = Partition(ref array,i,j,pivot); //Paritioning and finding its index
        Sort(ref array, i, index - 1);  //Sorting left array
        Sort(ref array, index + 1, j);  //Sorting right array
    }

    int Partition(ref int[] array, int i, int j,int pivotIndex)
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