﻿using Newtonsoft.Json;
using System;
using System.IO;

namespace NureTimetable.Helpers
{
    public static class Serialisation
    {
        public static void ToJsonFile<T>(T instance, string filePath)
        {
            try
            {
                string json = ToJson(instance);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                // Log error
            }
        }

        public static T FromJsonFile<T>(string filePath)
        {
            try
            {
                string fileContent = File.ReadAllText(filePath);
                T instance = FromJson<T>(fileContent);
                return instance;
            }
            catch (Exception ex)
            {
                // Log error
            }
            return default(T);
        }

        public static string ToJson<T>(T instance)
        {
            string json = JsonConvert.SerializeObject(instance);
            return json;
        }
        
        public static T FromJson<T>(string json)
        {
            if (typeof(T).IsPrimitive || typeof(T) == typeof(string))
            {
                return (T)Convert.ChangeType(json, typeof(T));
            }

            T instance = JsonConvert.DeserializeObject<T>(json);
            return instance;
        }
    }
}