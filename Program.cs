// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Text;

StringBuilder desc = new StringBuilder();
desc.AppendLine($"Room number: 1").
    AppendLine($"Price: 3 dollars").
    Append($"Description: This is a hotel room");

Console.WriteLine(desc.ToString()+" with bitches");
