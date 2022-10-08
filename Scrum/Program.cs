// See https://aka.ms/new-console-template for more information

using var answers = new StreamReader(File.OpenRead("Answers.txt"));
using var questions = new StreamReader(File.OpenRead("Questions.txt"));

var questionCounts = questions.ReadToEnd().Split("###", StringSplitOptions.RemoveEmptyEntries).Count();
questions.BaseStream.Seek(0, SeekOrigin.Begin);

var question = questions.ReadLine();
var anwser = answers.ReadLine();

int currentIndex = 0;

while (true)
{
    Console.WriteLine($"Question {++currentIndex} of {questionCounts}");
    Console.WriteLine();
    Console.WriteLine();

    do
    {
        Console.WriteLine(question);
        question = questions.ReadLine();
    } while (!question.StartsWith("###"));

    Console.ReadKey();

    do
    {
        Console.WriteLine(anwser);
        anwser = answers.ReadLine();
    } while (!anwser.StartsWith("###"));

    Console.ReadKey();
    Console.Clear();
}
