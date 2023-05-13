/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 
*    VERSION: 0.0.1
*/
using UnityEngine;
using System;
using UnityEngine.Events;
using System.IO;
using System.Linq;
using System.Text;


namespace AstarLibrary.Core
{
	public static class Report 
	{
        #region Variables
        internal static UnityAction<Memo> Log = new UnityAction<Memo>(FileLog);

        internal static string dataPath = Application.persistentDataPath + "/Log.txt";

        internal static bool registerLog = false;

        internal static int lineThreshold = 10;
        #endregion

        #region UnityMethods
        internal static void FileLog(Memo memo)
        {
            StringBuilder sb = new StringBuilder();

            DateTime now = DateTime.Now;

            if (memo == null)
            {
                memo = new Memo();
                memo.group = "Report";
                memo.name = "Log";
                memo.Type = ReportType.Error;
                memo.Source = ReportSource.System;
            }

            if (registerLog)
            {       

                sb.AppendFormat("[{0}] - [{1}]", now.ToString("dd-MM-yyyy"), now.ToString("hh:mm:ss tt"));
                sb.AppendFormat(" - [{0} - {1}]", memo.group, memo.name);
                sb.AppendFormat(" - {0}: {1}, {2}.", Enum.GetName(typeof(ReportType), memo.Type), memo.message, memo.addional);
                sb.AppendFormat(" - [Code - {0}] - [Source - {1}].",memo.code, Enum.GetName(typeof(ReportSource),memo.Source));               


                if (!File.Exists(dataPath)) File.AppendAllText(dataPath, sb.ToString() + Environment.NewLine);
                else
                {
                    var limit = File.ReadLines(dataPath).Count();

                    if (limit > lineThreshold)
                    {
                        var linesList = File.ReadAllLines(dataPath).ToList();
                        linesList.RemoveAt(0);
                        File.WriteAllLines(dataPath, linesList.ToArray());
                        File.AppendAllText(dataPath, sb.ToString() + Environment.NewLine);
                    }
                    else
                    {
                        File.AppendAllText(dataPath, sb.ToString() + Environment.NewLine);
                    }
                }
            }
            else
            {
                sb.AppendFormat("[{0}]", now.ToString("hh:mm:ss tt"));
                sb.AppendFormat(" - <color=#{0}>[{1} - {2}]</color>", ColorUtility.ToHtmlStringRGB(memo.Color), memo.group, memo.name);
                sb.AppendFormat(" - {0}: {1}, {2}.", Enum.GetName(typeof(ReportType), memo.Type), memo.message, memo.addional);

                Debug.Log(sb.ToString());
            }
        }
        #endregion

        #region PublicMethods
        public static void SetPath(string path) => dataPath = path;
        public static void SetRegister(bool isOn) => registerLog = isOn;
        #endregion
    }
}
