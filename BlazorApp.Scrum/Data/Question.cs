namespace Blazor.Scrum.Data
{
    public class Question
    {
        public int Index { get; set; }
        public string Text { get; set; }

        public Answer[] Answers { get; set; }
    }

    public class Answer
    {
        public int Index { get; set; }
        public string Text { get; set; }
        public bool IsSelected { get; set; }
        public bool IsUserSelected { get; set; }
    }
}