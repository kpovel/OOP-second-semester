using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

[Serializable]
public class Smiley
{
    public double R { get; set; } // radius of the face
    public double r { get; set; } // radius of the eyes

    public Smiley() // parameterless constructor
    {
        R = 0;
        r = 0;
    }

    public Smiley(double R, double r) // constructor with parameters
    {
        this.R = R;
        this.r = r;
    }

    public void Draw()
    {
         Console.WriteLine("   ^_^   ");
    }


public class Program
{
    public static void Main()
    {
        Smiley smiley = new Smiley(10, 5);
        IFormatter formatter = new BinaryFormatter();

        // Binary Serialization
        using (Stream stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None))
        {
            formatter.Serialize(stream, smiley);
        }

        // Binary Deserialization
        Smiley deserializedSmiley;
        using (Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            deserializedSmiley = (Smiley)formatter.Deserialize(stream);
            Console.WriteLine($"Deserialized Smile from Binary: R={deserializedSmiley.R}, r={deserializedSmiley.r}");
        }

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Smiley));

        // XML Serialization
        using (TextWriter writer = new StreamWriter("MyFile.xml"))
        {
            xmlSerializer.Serialize(writer, smiley);
        }

        // XML Deserialization
        using (TextReader reader = new StreamReader("MyFile.xml"))
        {
            deserializedSmiley = (Smiley)xmlSerializer.Deserialize(reader);
            Console.WriteLine($"Deserialized Smile from XML: R={deserializedSmiley.R}, r={deserializedSmiley.r}");
        }

        // Reflection
        Type type = typeof(Smiley);

        // Get Properties
        PropertyInfo[] properties = type.GetProperties();
        foreach (PropertyInfo property in properties)
        {
            Console.WriteLine("Property: " + property.Name);
        }

        // Get Methods
        MethodInfo[] methods = type.GetMethods();
        foreach (MethodInfo method in methods)
        {
            Console.WriteLine("Method: " + method.Name);
        }
    }
}

