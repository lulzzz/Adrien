﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Newtonsoft.Json;

namespace Adrien.Compiler.PlaidML
{
    public class Settings : CompilerApi<Settings>
    {
        #region Constructors
        public Settings()
        {
            if (EnvironmentConfigFile != null && EnvironmentConfigFile.Exists)
            {
                ConfigFile = EnvironmentConfigFile;
                Info("Using PlaidML environment settings file {0}.", EnvironmentConfigFile.FullName);
            }
            if (UserConfigFile.Exists)
            {
                ConfigFile = UserConfigFile;
                Info("Using PlaidML user settings file {0}.", UserConfigFile.FullName); 
            }
            else
            {
                ConfigFile = DefaultConfigFile;
                Info("Using PlaidML default settings file {0}.", DefaultConfigFile.FullName);
            }
            Load();
        }
        #endregion
        
        #region Properties
        public static string CONFIG_VAR = "PLAIDML_CONFIG";
        public static string CONFIG_FILE_VAR = "PLAIDML_CONFIG_FILE";
        public static string DEVICE_IDS_VAR = "PLAIDML_DEVICE_IDS";
        public static string EXPERIMENTAL_VAR = "PLAIDML_EXPERIMENTAL";
        public static string SESSION_VAR = "PLAIDML_SESSION";
        public static string SETTINGS_VAR = "PLAIDML_SETTINGS";
        public static string TELEMETRY_VAR = "PLAIDML_TELEMETRY";
        public static string[] ENV_SETTINGS_VARS = { CONFIG_VAR, CONFIG_FILE_VAR, DEVICE_IDS_VAR, EXPERIMENTAL_VAR, SESSION_VAR, SETTINGS_VAR, TELEMETRY_VAR };

        public static FileInfo EnvironmentConfigFile = Environment.GetEnvironmentVariable(SETTINGS_VAR).IsNotNullOrEmpty()
            ? new FileInfo(Environment.GetEnvironmentVariable(SETTINGS_VAR))
            : null;


        public static FileInfo UserConfigFile = new FileInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".plaidml"));



        public static FileInfo DefaultConfigFile = Environment.GetEnvironmentVariable("PLAIDML_DEFAULT_CONFIG").IsNotNullOrEmpty() 
            ? new FileInfo(Environment.GetEnvironmentVariable("PLAIDML_DEFAULT_CONFIG"))
            : new FileInfo(GetAssemblyDirectoryFullPath("config.json"));

        public static FileInfo ExperimentalConfigFile =
            Environment.GetEnvironmentVariable("PLAIDML_EXPERIMENTAL_CONFIG").IsNotNullOrEmpty() 
            ? new FileInfo(Environment.GetEnvironmentVariable("PLAIDML_EXPERIMENTAL_CONFIG"))
            : new FileInfo(GetAssemblyDirectoryFullPath("experimental.json"));

        public FileInfo ConfigFile { get; protected set; }

        public Dictionary<string, object> Dict { get; protected set; }

        public bool IsLoaded { get; protected set; }
        #endregion

        #region Methods
        protected bool Load()
        {
            try
            {
                string c = ConfigFile.OpenText().ReadToEnd();
                Dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(c);
                if (Dict != null && Dict.Count > 0)
                {
                    Info("Loaded configuration from file {0}.", ConfigFile.FullName);
                }
                IsLoaded = true;
            }
            catch (Exception e)
            {
                Error(e, "Exception thrown loading configuration from file {0}.", ConfigFile.FullName);
                IsLoaded = false;
            }
            return IsLoaded;
        }

        protected void ThrowIfNotLoaded()
        {
            if (!IsLoaded)
            {
                throw new InvalidOperationException("Settings are not loaded.");
            }
        }
        #endregion

        #region Operators
        #region Operators
        public object this[string key]
        {
            
            get
            {
                ThrowIfNotLoaded();
                return this.Dict[key];
            }
        }
        #endregion
        #endregion
    }
}
