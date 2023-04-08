// See https://aka.ms/new-console-template for more information


using System.Text.Json;

var httpClient = new HttpClient();

Console.WriteLine("Enter your name:");

var name = Console.ReadLine() ?? throw new ArgumentException("Name is null!");

Console.WriteLine("Enter your age:");

var age = Console.ReadLine() ?? throw new ArgumentException("Age is null!");


var clinet = new Client {
    Name = name,
    Age = age,
};

var jsonString = JsonSerializer.Serialize(clinet);

StringContent postData = new StringContent(jsonString);

var postResult = await httpClient.PostAsync($"https://localhost:7047/HelloPost", postData);
var postcontent = await postResult.Content.ReadAsStringAsync();

Console.WriteLine(postcontent);


public class Client 
{   
    public string Name { get; set; }
    public string Age { get; set; }
}