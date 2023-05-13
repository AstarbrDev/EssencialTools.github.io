/*
*    ALL RIGHTS RESERVED FOR ASTAR DO BRASIL 2021
*/
using System.Text;
using System.Text.RegularExpressions;

namespace AstarLibrary.Core
{
    public static class StringsExtensions
    {
        #region Functions
        /// <summary>
        /// Replace Values of this array with New Array
        /// </summary>
        /// <param name="line"></param>
        /// <param name="newArray"></param>
        /// <returns></returns>
        public static string[] ReplaceValues(this string[] line, string[] newArray)
        {
            for (int i = 0; i < newArray.Length; i++)
            {
                line[i] = newArray[i];
            }

            return line;
        }
        /// <summary>
        /// Split string based on Characters
        /// </summary>
        /// <param name="tosplit"></param>
        /// <param name="chars"></param>
        /// <returns></returns>
        public static string[] StringSplitter(this string tosplit, char[] chars)
        {
            return tosplit.Split(chars);
        }
        /// <summary>
        /// Cut string based on letter position
        /// </summary>
        /// <param name="toCut"></param>
        /// <param name="initialCharLength"></param>
        /// <param name="finalCharLength"></param>
        /// <returns></returns>
        public static string StringCut(this string toCut, int initialCharLength, int finalCharLength)
        {
            toCut = toCut.Substring(initialCharLength, toCut.Length - initialCharLength);
            toCut = toCut.Remove(toCut.Length - finalCharLength);

            return toCut;
        }
        /// <summary>
        /// Add char to a string
        /// </summary>
        /// <param name="toModify"></param>
        /// <param name="toAdd"></param>
        /// <returns></returns>
        public static string AddCharacterToString(this string toModify, char toAdd)
        {

            StringBuilder builder = new StringBuilder();

            builder.Append(toModify);
            builder.Append(toAdd);

            return builder.ToString();
        }
        /// <summary>
        /// Remove special characters
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveSpecialCharacters(this string str, string regex)
        {
            return Regex.Replace(str, regex, "", RegexOptions.Compiled);
        }
        #endregion
    }
}