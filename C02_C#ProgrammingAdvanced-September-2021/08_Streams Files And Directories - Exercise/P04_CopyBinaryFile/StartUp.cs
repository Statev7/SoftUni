namespace P04_CopyBinaryFile
{
    using System;
    using System.IO;

    public class StartUp
    {
        const string ORIGINAL_PATH = @"../../../copyMe.png";
        const string COPIED_PATH = @"../../../copyMe-copy.png";

        public static void Main()
        {

            using (FileStream stream = new FileStream(ORIGINAL_PATH, FileMode.Open))
            {
                using (FileStream writer = new FileStream(COPIED_PATH, FileMode.Create, FileAccess.Write))
                {
                    byte[] buffer = new byte[4096];
                    while (stream.Read(buffer, 0, buffer.Length) > 0)
                    {
                        writer.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}
