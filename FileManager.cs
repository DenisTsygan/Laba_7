using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Laba_7
{
    public class FileManager
    {
        /// <summary>
        /// Serialize object to json format, return ArgumentNullException if obj is null or uncorrect format string (string need to end ".json")
        /// </summary>
        /// <param name="obj">object to serialize</param>
        /// <param name="nameFile">name file to create</param>
        public static void SerializationToJSON(Object obj, string nameFile)
        {
            if (obj is not null && nameFile.EndsWith(".json"))
            {
                string output = JsonSerializer.Serialize(obj);
                using var outFile = new FileStream(nameFile, FileMode.Create);
                using StreamWriter writer = new StreamWriter(outFile);
                writer.Write(output);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        /// <summary>
        /// Deserialize from file json to Object(cast [param]obj.GetType()), return ArgumentException if uncorrect format param nameFile (string need to end ".json")
        /// </summary>
        /// <param name="nameFile">name file to open</param>
        /// <param name="obj">object to deserialize</param>
        public static Object DeserializationFromJSON(string nameFile, Object obj)
        {
            if (nameFile.EndsWith(".json"))
            {
                using var file = new FileStream(nameFile, FileMode.Open);
                using StreamReader reader = new StreamReader(file);
                string json = reader.ReadToEnd();
                return JsonSerializer.Deserialize(json,obj.GetType());
            }
            else
            {
                throw new ArgumentException();
            }
        }
        /// <summary>
        /// Serialize object to binary format, return ArgumentNullException if obj is null or uncorrect format param nameFile (string need to end ".bin")
        /// </summary>
        /// <param name="obj">object to serialize</param>
        /// <param name="nameFile">name file to create</param>
        public static void SerializationToBinary(Object obj, string nameFile)
        {
            if (obj is not null && nameFile.EndsWith(".bin"))
            {
                using var file = new FileStream(nameFile, FileMode.Create);
                new BinaryFormatter().Serialize(file, obj);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        /// <summary>
        /// Deserialize  from file binary to Object(need cast), return ArgumentException if uncorrect format param nameFile (string need to end ".bin")
        /// </summary>
        /// <param name="nameFile">name file to open</param>
        public static Object DeserializationFromBinary(string nameFile)
        {
            if (nameFile.EndsWith(".bin"))
            {
                using var file = new FileStream(nameFile, FileMode.Open);
                return new BinaryFormatter().Deserialize(file);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
