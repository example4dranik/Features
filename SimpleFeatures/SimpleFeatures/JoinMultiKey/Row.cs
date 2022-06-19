namespace SimpleFeatures.JoinMultiKey
{
    public class Row
    {
        public int Id { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }

        public Row(int i, string f1, string f2)
        {
            Id = i;
            Field1 = f1;
            Field2 = f2;
        }
    }
}