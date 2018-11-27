using Newtonsoft.Json;
using WpfApp.DataStructures;
using System.IO;
using System.Windows;

namespace WpfApp.Logic
{
    public static class Persistence
    {
        private static readonly string filePath = @"C:\Users\stefa\Documents\Workspace\SoftwareEngineeringCW\DataBase.json";
        private static string json = "Json is empty";

        public static void Serialize()
        {
            json = JsonConvert.SerializeObject(DataBaseSingleton.Instance, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static void DeSerialize()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException();
                }

                json = File.ReadAllText(filePath);
                DataBaseSingleton.Instance = JsonConvert.DeserializeObject<DataBaseSingleton>(json);

                // To replace - when have instantiation in the definition
                //var serializerSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };
                //JsonConvert.PopulateObject(json, DataBaseSingleton.Instance, serializerSettings);
                // i love toby <3
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The database file not found.");
            }
        }
    }
}
