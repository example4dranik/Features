using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace SimpleFeatures.MarshalSize
{
    public class MarshalSize : ISolution
    {
        public void Execute()
        {
            int iii = int.MaxValue;
            string str = "qwertyu";
            byte[] bytes = Encoding.ASCII.GetBytes(str);

            var list = new List<int>() { 1, 2, 3 };

            Console.WriteLine($"int={Marshal.SizeOf(iii)}");
            Console.WriteLine($"string={str.Length}");
            Console.WriteLine($"bytes[]={bytes.Length}");
            Console.WriteLine($"List<int>={GetBytes(list).Length}");
            Console.WriteLine($"{nameof(TestClass)}={GetSizeOfObject(new TestClass { f1 = 1, f2 = 2 })}");
        }

        private byte[] GetBytes<T>(T obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static int GetSizeOfObject(object obj, int avgStringSize = -1)
        {
            int pointerSize = IntPtr.Size;
            int size = 0;
            Type type = obj.GetType();
            var info = type.GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic);
            foreach (var field in info)
            {
                if (field.FieldType.IsValueType)
                {
                    size += System.Runtime.InteropServices.Marshal.SizeOf(field.FieldType);
                }
                else
                {
                    size += pointerSize;
                    if (field.FieldType.IsArray)
                    {
                        var array = field.GetValue(obj) as Array;
                        if (array != null)
                        {
                            var elementType = array.GetType().GetElementType();
                            if (elementType.IsValueType)
                            {
                                size += System.Runtime.InteropServices.Marshal.SizeOf(field.FieldType) * array.Length;
                            }
                            else
                            {
                                size += pointerSize * array.Length;
                                if (elementType == typeof(string) && avgStringSize > 0)
                                {
                                    size += avgStringSize * array.Length;
                                }
                            }
                        }
                    }
                    else if (field.FieldType == typeof(string) && avgStringSize > 0)
                    {
                        size += avgStringSize;
                    }
                }
            }
            return size;
        }
    }

    internal class TestClass
    {
        public int f1 { get; set; }
        public int f2 { get; set; }
    }
}