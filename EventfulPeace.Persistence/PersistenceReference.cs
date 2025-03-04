using System.Reflection;

namespace EventfulPeace.Persistence;

public class PersistenceReference
{
    public static Assembly Assembly => typeof(PersistenceReference).Assembly;
}
