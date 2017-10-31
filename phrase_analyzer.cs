
        string[] inputData = {"My computer is broken",
                                  "My computer is slow",
                                  "My computer crashed",
                                  "I can't login",
                                  "The printer is broken",
                                  "I can't send email",
                                  "My internet is slow",
                                  "My computer crashed" };

        public Dictionary<string, int> AnalyzePhrases(string[] phrases)
        {
            Dictionary<string, int> outputData = new Dictionary<string, int>();
            int phraseLength = phrases.Length;

            List<string> words = new List<string>();

            for (int i = 0; i < phraseLength; i++)
            {
                string temp1 = phrases[i];
                string[] stringArray = temp1.Split(' ');

                int stringArrayLength = stringArray.Length;

                for (int j = 0; j < stringArrayLength; j++)
                {
                    words.Add(stringArray[j]);
                }

                int numberOfWords = words.Count;
                int first = 0;
                int last = numberOfWords - 1;

                do
                {
                    string initialString = "";
                    for (int k = first; k < numberOfWords; k++)
                    {
                        string searchElemenet = String.Concat(initialString, words[k]);
                        var count = 0;

                        if (phrases[i].Contains(searchElemenet) || String.Equals(phrases[i], searchElemenet))
                            count++;

                        if (!outputData.ContainsKey(searchElemenet)) outputData.Add(searchElemenet, count);
                        else outputData[searchElemenet] += count;

                        initialString = String.Concat(searchElemenet, " ");
                    }
                    first++;

                } while (first != last);

                words.Clear();
            }
            return outputData;
        }
    }
}