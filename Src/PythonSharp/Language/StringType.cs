﻿namespace PythonSharp.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StringType : IType
    {
        private IDictionary<string, IMethod> methods = new Dictionary<string, IMethod>();

        public StringType()
        {
            this.methods["find"] = new NativeMethod(FindMethod);
            this.methods["replace"] = new NativeMethod(ReplaceMethod);
            this.methods["split"] = new NativeMethod(SplitMethod);
        }

        public IMethod GetMethod(string name)
        {
            return this.methods[name];
        }

        private static int Find(string text, string argument)
        {
            return text.IndexOf(argument);
        }

        private static string Replace(string text, string toreplace, string newtext)
        {
            return text.Replace(toreplace, newtext);
        }

        private static string[] Split(string text, string separator)
        {
            if (separator == null)
                return new string[] { text };

            IList<string> result = new List<string>();

            for (int position = text.IndexOf(separator); position >= 0; position = text.IndexOf(separator))
            {
                result.Add(text.Substring(0, position));
                text = text.Substring(position + separator.Length);
            }

            result.Add(text);

            return result.ToArray();
        }

        private static object FindMethod(object target, IList<object> arguments)
        {
            return Find((string)target, (string)arguments[0]);
        }

        private static object ReplaceMethod(object target, IList<object> arguments)
        {
            return Replace((string)target, (string)arguments[0], (string)arguments[1]);
        }

        private static object SplitMethod(object target, IList<object> arguments)
        {
            return Split((string)target, (string)arguments[0]);
        }
    }
}