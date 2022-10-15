namespace Blazor.Scrum.Data
{
    public class QuestionService
    {
        public async Task<Question> GetQuestion(int index)
        {
            using var questionsStream = new StreamReader(File.OpenRead("Resources/Questions.txt"));

            var questionDetails = (await questionsStream.ReadToEndAsync()).Split("###", StringSplitOptions.RemoveEmptyEntries);

            var questionDetailSerialized = questionDetails[index];

            var questionContent = questionDetailSerialized.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

            return new Question()
            {
                Index = index,
                Text = questionContent[0],
                Answers = BuildAnswer(questionContent.Skip(1).ToList())
            };
        }

        private Answer[] BuildAnswer(List<string> answerList)
        {
            return answerList.Select(a =>
                new Answer()
                {
                    Index = answerList.IndexOf(a),
                    Text = a.Replace("- [ ] ", "").Replace("- [x] ", ""),
                    IsSelected = a.StartsWith("- [x] ")
                }
            ).ToArray();
        }
    }
}