namespace Peters.Cookies.Domain.Helpers;

public static class Assertion
{
    public static void ArgumentAssert(bool assert, string argName)
    {
        if (!assert)
        {
            throw new ArgumentException("Invalid argument", argName);
        }
    }

    public static void ArgumentAssert(string message, bool assert, string argName)
    {
        if (!assert)
        {
            throw new ArgumentException(message, argName);
        }
    }

    public static void ArgumentNullAssert(object o, string name)
    {
        if (o == null)
        {
            throw new ArgumentNullException(name);
        }
    }

    public static void ArgumentNullAssert(string message, object o, string name)
    {
        if (o == null)
        {
            throw new ArgumentNullException(name, message);
        }
    }

    public static void ValueNullAssert(object o, string name)
    {
        if (o == null)
        {
            throw new ValueNullException(name);
        }
    }

    public static void ValueNullAssert(string message, object o, string name)
    {
        if (o == null)
        {
            throw new ValueNullException(name, message);
        }
    }


    public static void ValueAssert(bool assert, string argName)
    {
        if (!assert)
        {
            throw new ValueException(argName);
        }
    }

    public static void ValueAssert(string message, bool assert, string argName)
    {
        if (!assert)
        {
            throw new ValueException(message, argName);
        }
    }

    internal class ValueNullException : ArgumentNullException
    {
        public ValueNullException(string name) : base(name)
        {
        }

        public ValueNullException()
        {
        }

        public ValueNullException(string message, Exception inner) : base(message, inner)
        {
        }

        public ValueNullException(string paramName, string message) : base(paramName, message)
        {
        }
    }

    internal class ValueException : ArgumentException
    {
        public ValueException(string name) : base(name)
        {
        }

        public ValueException()
        {
        }

        public ValueException(string message, Exception inner) : base(message, inner)
        {
        }

        public ValueException(string message, string paramName) : base(message, paramName)
        {
        }

        public ValueException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        {
        }
    }
}
