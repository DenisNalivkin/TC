using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using InterfaceIListener;
using System.Reflection;

namespace logger
{
    /// <summary>
    /// Logger class does chronological record of information about events occurring in the system.
    /// </summary>
    public class Logger
    {
        public LogLevel MinLogLevel { get; private set; }
        public List<IListener> ExecutorLogger { get; private set; }

        /// <summary>
        /// Public constructor Logger initialize field ExecutorLogger of class Logger.
        /// </summary>
        public Logger ()
        {
            ExecutorLogger = new List<IListener>();
        }

        /// <summary>
        /// ParseConfig method reads information about listeners from json file.
        /// </summary>
        /// <param name="path"> Path to configuration json file. </param>
        public void ParseConfig (string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string jsonString = File.ReadAllText(path);
                var loggerConfig = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(jsonString)["Logger"];
                SetMinLogLevelLogger(loggerConfig["MinLogLevel"].ToString());
                InitializeExecutors(loggerConfig);
                SetLogLevelExecutor();
            }
        }

        /// <summary>
        /// SetMinLogLevelL method sets the minimum logging level for logger.
        /// </summary>
        /// <param name="str"> Logging level. </param>
        private void SetMinLogLevelLogger (string str)
        {
            switch (str.ToLower())
            { 
                case "info":
                    MinLogLevel = LogLevel.Info;
                    break;
                case "warning":
                    MinLogLevel = LogLevel.Warning;
                    break;
                case "error":
                    MinLogLevel = LogLevel.Error;
                    break;
                case "trace":
                    MinLogLevel = LogLevel.Trace;
                    break;
                default: throw new ArgumentException();
            }
        }

        /// <summary>
        /// InitializeExecutors method adds listeners in list listener.
        /// </summary>
        /// <param name="loggerConfig"> Json.Linq.JObject with a minimum logging level for the logger and a list of listener objects. </param>
        private void InitializeExecutors(Newtonsoft.Json.Linq.JObject loggerConfig)
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
                    executor = (IListener)Activator.CreateInstance(executorClass,(string)loggerConfig[objExecutor.Name]["Source"]);                           
                    executor.Loglevel = ParseEnum<LogLevel>((string)loggerConfig[objExecutor.Name]["LogLevel"]);
                    ExecutorLogger.Add(executor);                 
                }              
            }
        }

        /// <summary>
        /// SetLogLevelExecutor method sets the minimum logging level of the logger for all listeners.
        /// </summary>
        private void SetLogLevelExecutor ()
        {         
            foreach( var curListener in ExecutorLogger)
            {
                curListener.Loglevel = MinLogLevel < curListener.Loglevel ? MinLogLevel : curListener.Loglevel;
            }
        }

        /// <summary>
        /// ParseEnum method converts string to enum value.
        /// </summary>
        /// <param name="value"> String for convert. </param>
        /// <returns> Value of Enum. </returns>
        private static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// Log method, depending on the logging level of the listener, transfers the logging task to the required listener.
        /// </summary>
        /// <param name="message"> Text for write. </param>
        /// <param name="loglevel"> Logging level. </param>
        public void Log (string message, LogLevel loglevel)
        {
            foreach(var curExecutor in ExecutorLogger)
            {
                curExecutor?.WriteMessage(message, loglevel);
            }         
        }

        /// <summary>
        ///  Track method accepts an arbitrary object as a parameter.If the[TrackingEntity] attribute is detected in a class or structure corresponding to the object type, the logger records(writes to a log file with the Trace level) the values ​​of those properties and fields of the object that are marked with the[TrackingPropert] attribute.
        /// </summary>
        /// <param name="obj"> Arbitrary object. </param>
        /// <param name="path"> Path to file for write. </param>
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
