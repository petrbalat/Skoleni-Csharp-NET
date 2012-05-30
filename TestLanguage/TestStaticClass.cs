﻿namespace TestLanguage
{
    public static class TestStaticClass
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
    }

    struct MyStruct 
    {
        public override string ToString()
        {
            return base.ToString();
        }
    }
}