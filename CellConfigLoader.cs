using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SimpliSafeTakeHomeAssesment
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class CellConfig : CellConfigInterface
    {
        [JsonProperty("empty_value")]
        string emptyValue;

        [JsonProperty("player_values")]
        List<string> playerValues;

        List<string> combinedConfigValues = new List<string>();

        public void CombineConfig()
        {
            combinedConfigValues.Add(emptyValue);
            combinedConfigValues.AddRange(playerValues);
        }

        public List<string> GetCellConfigList()
        {
            return combinedConfigValues;
        }
    }

    public interface CellConfigInterface
    {
        public List<string> GetCellConfigList();
        public string this[int key]
        {
            get => GetCellConfigList()[key];
        }

        public string _EmptyValue
        {
            get
            {
                return GetCellConfigList()[0];
            }
        }
    }

    public static class CellConfigLoader
    {
        const string FILE_NAME = "cell_config.json";
        static string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILE_NAME);

        public static CellConfigInterface Load()
        {
            using (StreamReader file = File.OpenText(filePath))
            {
                string data = file.ReadToEnd();

                try
                {
                    CellConfig config = JsonConvert.DeserializeObject<CellConfig>(data);
                    if (config != null)
                    {
                        config.CombineConfig();
                        return config;
                    }
                    else
                    {
                        throw new Exception("Could not read config file");
                    }

                }
                catch (Exception)
                {
                    throw new Exception("Could not read config file");
                }


                //using (JsonTextReader reader = new JsonTextReader())
                //{
                //    try
                //    {
                //        CellConfig config = JsonConvert.DeserializeObject<CellConfig>(reader.ReadAsString());
                //        if (config != null)
                //        {
                //            config.CombineConfig();
                //            return config;
                //        }
                //        else
                //        {
                //            throw new Exception("Could not read config file");
                //        }
                        
                //    }
                //    catch (Exception)
                //    {
                //        throw new Exception("Could not read config file");
                //    }
                //}
            }
        }
    }
}
