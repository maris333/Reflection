using System.Reflection;

public static class ReflectionHelper
{
    public static Dictionary<string, object> GetProperties(object obj)
    {
        Type type = obj.GetType();
        PropertyInfo[] properties = type.GetProperties();

        Dictionary<string, object> result = new Dictionary<string, object>();

        foreach (PropertyInfo property in properties)
        {
            string propertyName = property.Name;
            object propertyValue = property.GetValue(obj);

            result.Add(propertyName, propertyValue);
        }

        return result;
    }
}


class MyClass
{
    public string Name { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        MyClass obj = new MyClass()
        {
            Name = "John Doe",
            Age = 30
        };

        Dictionary<string, object> properties = ReflectionHelper.GetProperties(obj);

        foreach (var kvp in properties)
        {
            Console.WriteLine($"Property: {kvp.Key}, Value: {kvp.Value}");
        }
    }
}
