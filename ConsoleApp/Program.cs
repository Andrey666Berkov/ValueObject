using ConsoleApp;

var age1 = Age.Create(2, 1).Value;
var age2 = Age.Create(1, 1).Value;

Console.WriteLine(age1 == age2);