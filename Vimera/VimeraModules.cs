﻿using System;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Vimera{
    internal class VimeraModules{
        // LINK SYSTEM
        // ======================================================================================================
        public class TS_LinkSystem{
            public string
            website_link = "https://www.erayturkay.com/",
            github_link = "https://github.com/roines45",
            twitter_link = "https://twitter.com/roines45";
        }
        // ======================================================================================================
        // VERSIONS
        public class VimeraVersionEngine{
            string version_mode;
            public string VimeraVersion(int v_type, int v_mode){
                if (v_type == 0){
                    if (v_mode == 0){
                        version_mode = string.Format("{0} - v{1}", Application.ProductName, Application.ProductVersion.Substring(0, 5));
                    }else if (v_mode == 1){
                        version_mode = string.Format("{0} - v{1}", Application.ProductName, Application.ProductVersion.Substring(0, 7));
                    }
                }else if (v_type == 1){
                    if (v_mode == 0){
                        version_mode = string.Format("v{0}", Application.ProductVersion.Substring(0, 5));
                    }else if (v_mode == 1){
                        version_mode = string.Format("v{0}", Application.ProductVersion.Substring(0, 7));
                    }
                }
                return version_mode;
            }
        }
        // ======================================================================================================
        // SAVE PATHS
        public static string vimera_lf = @"v_langs";                                // Main Path
        public static string vimera_lang_en = vimera_lf + @"\English.ini";          // English    | en
        public static string vimera_lang_tr = vimera_lf + @"\Turkish.ini";          // Turkish    | tr
        // Total Langs | Current Langs Count: 2
        public static int v_langs_count = 2;
        // ======================================================================================================
        // VIMERA SETTINGS SAVE CLASS
        public class VimeraGetLangs{
            [DllImport("kernel32.dll")]
            private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
            public VimeraGetLangs(string file_path){ save_file_path = file_path; }
            private string save_file_path = vimera_lf;
            private string default_save_process { get; set; }
            public string VimeraReadLangs(string episode, string setting_name){
                default_save_process = default_save_process ?? string.Empty;
                StringBuilder str_builder = new StringBuilder(256);
                GetPrivateProfileString(episode, setting_name, default_save_process, str_builder, 255, save_file_path);
                return str_builder.ToString();
            }
        }
        // ======================================================================================================
        // SAVE PATHS
        public static string vimera_df = Application.StartupPath;
        public static string vimera_sf = vimera_df + @"\VimeraSettings.ini";
        // ======================================================================================================
        // VIMERA SETTINGS SAVE CLASS
        public class VimeraSettingsSave{
            [DllImport("kernel32.dll")]
            private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
            [DllImport("kernel32.dll")]
            private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
            public VimeraSettingsSave(string file_path){ save_file_path = file_path; }
            private string save_file_path = vimera_sf;
            private string default_save_process { get; set; }
            public string VimeraReadSettings(string episode, string setting_name){
                default_save_process = default_save_process ?? string.Empty;
                StringBuilder str_builder = new StringBuilder(256);
                GetPrivateProfileString(episode, setting_name, default_save_process, str_builder, 255, save_file_path);
                return str_builder.ToString();
            }
            public long VimeraWriteSettings(string episode, string setting_name, string value){
                return WritePrivateProfileString(episode, setting_name, value, save_file_path);
            }
        }
        // TITLE BAR SETTINGS DWM API
        // ======================================================================================================
        [DllImport("DwmApi")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);
        // ======================================================================================================
        // DPI AWARE
        [DllImport("user32.dll")]
        public static extern bool SetProcessDPIAware();
    }
}