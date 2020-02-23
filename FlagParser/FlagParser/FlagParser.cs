using System;
using System.Collections.Generic;
using System.Linq;

namespace LoableTech
{
    public class FlagParser
    {
        #region public properties
        /// <summary>
        /// List of error strings if ContinueOnError = true
        /// </summary>
        public static List<string> Errors = new List<string>();
        /// <summary>
        /// If true, do not raise argument exception error
        /// </summary>
        public static bool ContinueOnError { get; set; }
        /// <summary>
        /// Set the flag marker, default -
        /// </summary>
        public static char FlagMarker = '-';
        /// <summary>
        /// Set the separator for flag and value, default =
        /// </summary>
        public static string ValueSeparator = "=";
        /// <summary>
        /// If true, parameters are compared in case sensitive mode
        /// </summary>
        public static bool IsCaseSensitive { get; set; }
        #endregion
        #region private properties
        private static List<object> flags = new List<object>();
        private static Dictionary<string, string> arguments = new Dictionary<string, string>();
        #endregion
        #region public methods
        /// <summary>
        /// Parse the command line arguments
        /// </summary>
        /// <param name="args">The arguments from main</param>
        public static void Parse(string[] args)
        {
            foreach(var arg in args)
            {
                var s = arg.Split(new string[] { ValueSeparator }, StringSplitOptions.RemoveEmptyEntries);

                if (!s[0][0].Equals(FlagMarker))
                {
                    var error = $"Invalid Parameter {s[0]}";
                    Errors.Add(error);
                    if (!ContinueOnError)
                        throw new ArgumentException(error);
                }

                var key = IsCaseSensitive ? s[0].Substring(1) : s[0].Substring(1).ToLower();

                if (s.Length == 1)
                {
                    arguments.Add(key, "true");
                } else
                {
                    arguments.Add(key, string.Join(ValueSeparator, s.Skip(1).ToArray()));
                }
            }
        }

        public static string StringFlag(string name, string defaultValue, bool isRequired)
        {
            string strVal = string.Empty;
            if (!arguments.TryGetValue(IsCaseSensitive ? name : name.ToLower(), out strVal) && isRequired)
            {
                var error = $"Invalid parameter {name}";
                Errors.Add(error);
                if (!ContinueOnError)
                    throw new ArgumentException(error);
                
            }
            if (string.IsNullOrEmpty(strVal))
                strVal = defaultValue;
            return strVal;
        }
        public static decimal DecimalFlag(string name, decimal defaultValue, bool isRequired)
        {
            decimal val = defaultValue;
            string strval = StringFlag(name, defaultValue.ToString(), isRequired);
            if (!decimal.TryParse(strval, out val))
            {
                var error = $"Wrong Parameter Data Type : Expecting Decimal Value {name} [{strval}]";
                Errors.Add(error);
                if (!ContinueOnError)
                    throw new ArgumentException(error);

            }
            return val;
        }
        public static double DoubleFlag(string name, double defaultValue, bool isRequired)
        {
            double val = defaultValue;
            string strval = StringFlag(name, defaultValue.ToString(), isRequired);
            if (!double.TryParse(strval, out val))
            {
                var error = $"Wrong Parameter Data Type : Expecting Double Value {name} [{strval}]";
                Errors.Add(error);
                if (!ContinueOnError)
                    throw new ArgumentException(error);

            }
            return val;
        }
        public static float FloatFlag(string name, float defaultValue, bool isRequired)
        {
            float val = defaultValue;
            string strval = StringFlag(name, defaultValue.ToString(), isRequired);
            if (!float.TryParse(strval, out val))
            {
                var error = $"Wrong Parameter Data Type : Expecting Float Value {name} [{strval}]";
                Errors.Add(error);
                if (!ContinueOnError)
                    throw new ArgumentException(error);

            }
            return val;
        }
        public static long LongFlag(string name, long defaultValue, bool isRequired)
        {
            long val = defaultValue;
            string strval = StringFlag(name, defaultValue.ToString(), isRequired);
            if (!long.TryParse(strval, out val))
            {
                var error = $"Wrong Parameter Data Type : Expecting Long Value {name} [{strval}]";
                Errors.Add(error);
                if (!ContinueOnError)
                    throw new ArgumentException(error);

            }
            return val;
        }
        public static ulong ULongFlag(string name, ulong defaultValue, bool isRequired)
        {
            ulong val = defaultValue;
            string strval = StringFlag(name, defaultValue.ToString(), isRequired);
            if (!ulong.TryParse(strval, out val))
            {
                var error = $"Wrong Parameter Data Type : Expecting Unsigned Long Value {name} [{strval}]";
                Errors.Add(error);
                if (!ContinueOnError)
                    throw new ArgumentException(error);

            }
            return val;
        }
        public static int IntFlag(string name, int defaultValue, bool isRequired)
        {
            int val = defaultValue;
            string strval = StringFlag(name, defaultValue.ToString(), isRequired);
            if (!int.TryParse(strval, out val))
            {
                var error = $"Wrong Parameter Data Type : Expecting Integer Value {name} [{strval}]";
                Errors.Add(error);
                if (!ContinueOnError)
                    throw new ArgumentException(error);

            }
            return val;
        }
        public static uint UIntFlag(string name, uint defaultValue, bool isRequired)
        {
            uint val = defaultValue;
            string strval = StringFlag(name, defaultValue.ToString(), isRequired);
            if (!uint.TryParse(strval, out val))
            {
                var error = $"Wrong Parameter Data Type : Expecting Unsigned Integer Value {name} [{strval}]";
                Errors.Add(error);
                if (!ContinueOnError)
                    throw new ArgumentException(error);

            }
            return val;
        }
        public static bool BoolFlag(string name, bool defaultValue, bool isRequired)
        {
            bool val = defaultValue;
            string strval = StringFlag(name, defaultValue.ToString(), isRequired);
            if (!bool.TryParse(strval, out val))
            {
                var error = $"Wrong Parameter Data Type : Expecting Boolean Value {name} [{strval}]";
                Errors.Add(error);
                if (!ContinueOnError)
                    throw new ArgumentException(error);

            }
            return val;
        }
        public static DateTime FloatFlag(string name, DateTime defaultValue, bool isRequired)
        {
            DateTime val = defaultValue;
            string strval = StringFlag(name, defaultValue.ToString(), isRequired);
            if (!DateTime.TryParse(strval, out val))
            {
                var error = $"Wrong Parameter Data Type : Expecting DateTime Value {name} [{strval}]";
                Errors.Add(error);
                if (!ContinueOnError)
                    throw new ArgumentException(error);

            }
            return val;
        }
        #endregion
    }
}
