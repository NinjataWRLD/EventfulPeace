using System.Reflection;

namespace EventfulPeace.Application;

public class ApplicationReference
{
    public static Assembly Assembly => typeof(ApplicationReference).Assembly;
}
