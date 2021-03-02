namespace Homework4.Models
{
    public abstract class AbstractSort
    {
        protected static void Swap(ref int itm1, ref int itm2)
        {
            var tmp = itm1;
            itm1 = itm2;
            itm2 = tmp;
        }
    }
}