using Newtonsoft.Json;

//As i created the project .Net Core i couldn't use System.Web.Script.Serialization namespace so i installed Newtonsoft.Json to solve this problem
internal class Program
{
    //Attribute for the class to be able to serialize and deserialize
    [Serializable]
    public class Customer
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    private static void Main(string[] args)
    {
        Customer customer = new Customer() { Id = 1, Name = "John", Age = 21 };

        string json = JsonConvert.SerializeObject(customer);

        Console.WriteLine(json);

        string filePath = @"c:\FileTest\customers.json";
        StreamWriter streamW = new StreamWriter(filePath);
        streamW.Write(json);
        streamW.Close();

        StreamReader streamR = new StreamReader(filePath);
        Customer customer1 = JsonConvert.DeserializeObject<Customer>(streamR.ReadToEnd());
        streamR.Close();
        Console.WriteLine(customer1?.Name + " " + customer1?.Id);
    }
}