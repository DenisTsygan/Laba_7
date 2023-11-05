using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace Laba_7
{
    public class FileManagerComments
    {
        /// <summary>
        /// Serialize list to json format, return ArgumentNullException if list is null or uncorrect format string (string need to end ".json")
        /// </summary>
        /// <param name="list">list to serialize</param>
        /// <param name="nameFile">name file to create</param>
        public static void SerializationToJSON(List<Comment> list, string nameFile)
        {
            if (list is not null && nameFile.EndsWith(".json"))
            {
                string output = JsonSerializer.Serialize(list);
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
        /// Deserialize from file json to (List<Comment>), return ArgumentException if uncorrect format param nameFile (string need to end ".json")
        /// </summary>
        /// <param name="nameFile">name file to open</param>
        public static List<Comment> DeserializationFromJSON(string nameFile)
        {
            if (nameFile.EndsWith(".json"))
            {
                using var file = new FileStream(nameFile, FileMode.Open);
                using StreamReader reader = new StreamReader(file);
                string json = reader.ReadToEnd();
                return JsonSerializer.Deserialize<List<Comment>>(json);
            }
            else
            {
                throw new ArgumentException();
            }
        }
        /// <summary>
        /// Serialize list to binary format, return ArgumentNullException if list is null or uncorrect format param nameFile (string need to end ".bin")
        /// </summary>
        /// <param name="list">list to serialize</param>
        /// <param name="nameFile">name file to create</param>
        public static void SerializationToBinary(List<Comment> list, string nameFile)
        {
            if (list is not null && nameFile.EndsWith(".bin"))
            {
                using var file = new FileStream(nameFile, FileMode.Create);
                new BinaryFormatter().Serialize(file, list);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
        /// <summary>
        /// Deserialize from file binary to (List<Comment>), return ArgumentException if uncorrect format param nameFile (string need to end ".bin")
        /// </summary>
        /// <param name="nameFile">name file to open</param>
        public static List<Comment> DeserializationFromBinary(string nameFile)
        {
            if (nameFile.EndsWith(".bin"))
            {
                using var file = new FileStream(nameFile, FileMode.Open);
                return (List<Comment>)new BinaryFormatter().Deserialize(file);
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
