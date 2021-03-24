using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using InterfaceIListener;
using System.Reflection;

namespace logger
{
   public class Logger
    {
        public LogLevel minLogLevel { get; private set; }
        public List<IListener> executorLogger { get; private set; }

        public Logger ()
        {
            executorLogger = new List<IListener>();

        }
            
        public void ParseConfig (string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string jsonString = File.ReadAllText(path);
                var loggerConfig = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonString)["Logger"];
                SetMinLogLevelLogger(loggerConfig["MinLogLevel"].ToString());
                InitializeExecutors(loggerConfig, jsonString);
                SetLogLevelExecutor();
            }
        }

        private void SetMinLogLevelLogger (string str)
        {
            switch (str.ToLower())
            { 
                case "info":
                    minLogLevel = LogLevel.Info;
                    break;
                case "warning":
                    minLogLevel = LogLevel.Warning;
                    break;
                case "error":
                    minLogLevel = LogLevel.Error;
                    break;
                case "trace":
                    minLogLevel = LogLevel.Trace;
                    break;
                default: throw new ArgumentException();
            }
        }
      
        private void InitializeExecutors(Newtonsoft.Json.Linq.JObject loggerConfig, string jsonString)
        {
            Assembly assembly = null;
            Type [] classesAssebmly = null;
            IListener executor = null;
            LogLevel extcutorLogLevel = 0;
            Type executorClass = null;
            foreach (var objExecutor  in loggerConfig.Properties())
            {
                if (objExecutor.Name != "MinLogLevel")
                {
                    assembly = Assembly.Load(objExecutor.Name);
                    classesAssebmly = assembly.GetTypes();
                    executorClass = assembly.GetType(classesAssebmly[0].FullName);
                    executor = (IListener)Activator.CreateInstance(executorClass);                           
                    executor.Loglevel = ParseEnum<LogLevel>((string)loggerConfig[objExecutor.Name]["LogLevel"]);
                    executor.SetSource((string)loggerConfig[objExecutor.Name]["Source"]);
                    executorLogger.Add(executor);                 
                }              
            }
        }  

        private  void SetLogLevelExecutor ()
        {         
            foreach( var curListener in executorLogger)
            {
                curListener.Loglevel = minLogLevel < curListener.Loglevel ? minLogLevel : curListener.Loglevel;
            }
        }

        private static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }
        
        public void Log (string message, LogLevel loglevel)
        {
            foreach(var curExecutor in executorLogger)
            {
                curExecutor?.WriteMessage(message, loglevel);
            }         
        }    
              
        public void Track (object obj, string path)
        {
            var objType = obj.GetType();
            Attribute trackingEntityAttribute = Attribute.GetCustomAttribute(objType, typeof(TrackingEntityAttribute));
            if (trackingEntityAttribute != null)
            {
                var allProperty = objType.GetProperties();
                foreach ( var property in allProperty)
                {
                    Attribute result = Attribute.GetCustomAttribute(property, typeof(TrackingPropertyAttribute));
                    if (result != null)
                    {
                        ParseConfig(path);
                       
                        Log($"{property.Name}={property.GetValue(obj)}", LogLevel.Trace);
                    }
                }
            }
        }       
    }
}
