using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HandyToolsAndExtensions.Extensions
{
    public static class SerializationExtensions
    {
        public static void BinarySerialize<T>(this T instance, string fileName)
        {
            using (var stream = File.OpenWrite(fileName))
            {
                new BinaryFormatter().Serialize(stream, instance);
            }
        }

        public static T BinaryDeserialize<T>(this T instance, string fileName)
        {
            using (var stream = File.OpenRead(fileName))
            {
                return (T)new BinaryFormatter().Deserialize(stream);
            }
        }
    }
}