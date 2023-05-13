/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using System;
using UnityEngine;

namespace AstarLibrary.Core
{
    [Serializable]
    public class Memo
    {
        #region Variables
        public string       message  { get; set; }
        public string       addional { get; set; }
        public string       code     { get; set; }
        public string       group    { get; set; }
        public string       name     { get; set; }
        public Color        Color    { get; set; }
        public ReportSource Source   { get; set; }
        public ReportType   Type     { get; set; }
        #endregion

        #region Constructor
        public Memo() { }

        public Memo(string message, string addional, string code, string group, string name, Color color, ReportSource source, ReportType type)
        {
            this.message  = message;
            this.addional = addional;
            this.code     = code;
            this.group    = group;
            this.name     = name;
            Color         = color;
            Source        = source;
            Type          = type;
        }
        #endregion
    }
}
