namespace SimpleFeatures.JoinMultiKey
{
    public class Row
    {
        public int id { get; set; }
        public string field1 { get; set; }
        public string field2 { get; set; }

        public Row(int i, string f1, string f2)
        {
            id = i;
            field1 = f1;
            field2 = f2;
        }
    }
}