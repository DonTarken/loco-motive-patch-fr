using System;
using System.IO;
using System.Text;

class ReadHeader {
    static void Main() {
        using (var fs = File.OpenRead(@"D:\Games\Loco Motive\Loco Motive_Data\data.unity3d"))
        using (var br = new BinaryReader(fs)) {
            byte[] magic = br.ReadBytes(8);
            Console.WriteLine("Magic: " + Encoding.ASCII.GetString(magic));
            int ver = ReadInt32BE(br);
            Console.WriteLine("Version: " + ver);
            string unityVer = ReadNullTerminatedString(br);
            Console.WriteLine("Unity Version: " + unityVer);
            string genVer = ReadNullTerminatedString(br);
            Console.WriteLine("Generator Version: " + genVer);
            long fileSize = ReadInt64BE(br);
            Console.WriteLine("File Size: " + fileSize);
            int ciSize = ReadInt32BE(br);
            int uiSize = ReadInt32BE(br);
            int flags = ReadInt32BE(br);
            Console.WriteLine(string.Format("Compressed BlockInfo: {0}, Uncompressed: {1}, Flags: {2:X}", ciSize, uiSize, flags));
        }
    }

    static int ReadInt32BE(BinaryReader br) {
        byte[] b = br.ReadBytes(4);
        Array.Reverse(b);
        return BitConverter.ToInt32(b, 0);
    }
    static long ReadInt64BE(BinaryReader br) {
        byte[] b = br.ReadBytes(8);
        Array.Reverse(b);
        return BitConverter.ToInt64(b, 0);
    }
    static string ReadNullTerminatedString(BinaryReader br) {
        var sb = new StringBuilder();
        byte b;
        while ((b = br.ReadByte()) != 0) sb.Append((char)b);
        return sb.ToString();
    }
}
