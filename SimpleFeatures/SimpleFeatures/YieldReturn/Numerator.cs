using System.Collections;

namespace SimpleFeatures.YieldReturn
{
    internal class Numerator
    {
        private List<int> listInt;

        public Numerator()
        {
            listInt = new List<int>();
            for (int i = 1; i < 10; i++)
            {
                listInt.Add(i);
            }
        }

        public IEnumerable GetInt(bool view = false)
        {
            if (view)
            {
                yield return listInt.IndexOf(8);
                yield return listInt.IndexOf(0);
                yield return listInt.IndexOf(5);
            }
            else
            {
                foreach (var el in listInt)
                {
                    yield return el;
                }
            }
        }
    }
}