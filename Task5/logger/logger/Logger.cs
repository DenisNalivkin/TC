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
        public IListener TextListener { get; private set; }
        public IListener WordListener { get; private set; }
        public IListener EventLogListener { get; private set; }

        public void ParseConfig (string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string jsonString = File.ReadAllText(path);
                var loggerConfig = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonString)["Logger"];
                SetMinLogLevel(loggerConfig["MinLogLevel"].ToString());
                InitializeListeners(loggerConfig, jsonString);               
            }
        }

        private void SetMinLogLevel (string str)
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

        private IListener LoadDll(AssemblyName assemblyName, Assembly assembly, string className)
        {
            try
            {
                assembly = Assembly.Load(assemblyName);
                Type type = assembly.GetType($"{assemblyName}.{className}");
                return (IListener)Activator.CreateInstance(type);
            }
                  
            catch
            {
                return null;
            }
        }
        private void InitializeListeners(Newtonsoft.Json.Linq.JObject loggerConfig, string jsonString)
        {
            AssemblyName assemblyName = null;
            Assembly assembly = null;
            foreach (var value  in loggerConfig.Properties())
            {
                if(value.Name.ToLower() == "textlistener")
                {
                    assemblyName = new AssemblyName("TextListener");
                    assembly = Assembly.Load(assemblyName);
                    TextListener = LoadDll(assemblyName, assembly, "Textlistener");
                    SetLogLevel("TextListener", jsonString);                 
                    var path = loggerConfig["TextListener"]["Path"];
                    TextListener.SetPathOrSource(path.ToString());
                }

                if (value.Name.ToLower() == "wordlistener")
                {
                    assemblyName = new AssemblyName("WordListener");
                    WordListener = LoadDll(assemblyName, assembly, "Wordlistener");
                    SetLogLevel("WordListener", jsonString);
                    var path = loggerConfig["WordListener"]["Path"];
                    WordListener.SetPathOrSource(path.ToString());
                }

                if (value.Name.ToLower() == "eventloglistener")
                {
                    assemblyName = new AssemblyName("EventLogListener");
                    EventLogListener = LoadDll(assemblyName, assembly, "EventLoglistener");
                    SetLogLevel("EventLogListener", jsonString);
                    var source = loggerConfig["EventLogListener"]["Source"];
                    EventLogListener.SetPathOrSource(source.ToString());
                }
                assemblyName = null;
            }
        }
     
        private  void SetLogLevel (string listenerName, string jsonString)
        {
            Dictionary<string, LogLevel> dictLogLevel = new Dictionary<string, LogLevel> { {"Trace",LogLevel.Trace },  { "Info", LogLevel.Info }, { "Warning", LogLevel.Warning }, { "Error", LogLevel.Error } };
            var logLevel = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonString)["Logger"][listenerName]["LogLevel"];
            logLevel = minLogLevel < dictLogLevel[logLevel.Value] ? minLogLevel : logLevel;
            if (listenerName == "TextListener")
            {               
                this.TextListener.Loglevel = logLevel;
            }
            if (listenerName == "WordListener")
            {
                this.WordListener.Loglevel = logLevel;
            }
            if (listenerName == "EventLogListener")
            {
                this.EventLogListener.Loglevel = logLevel;
            }

        }
        public void Log (string message, LogLevel loglevel)
        {
            EventLogListener?.WriteMessage(message, loglevel);
            TextListener?.WriteMessage(message, loglevel);
            WordListener?.WriteMessage(message, loglevel);          
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
