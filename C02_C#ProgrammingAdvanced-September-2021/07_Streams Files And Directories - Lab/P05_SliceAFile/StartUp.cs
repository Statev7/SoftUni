namespace P05_SliceAFile
{
    using System.IO;

    public class StartUp
    {
        public static void Main()
        {
            using (FileStream stream = new FileStream("../../../sliceMe.txt", FileMode.Open))
            {
                int size = (int)stream.Length / 4;
                byte[] buffer = new byte[size];

                for (int i = 0; i < 4; i++)
                {
                    using (FileStream write = new FileStream($"../../../Part-{i + 1}.txt", FileMode.Create, FileAccess.Write))
                    {
                        stream.Read(buffer, 0, buffer.Length);
                        write.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
