using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        // TODO Problem 1 - ADD YOUR CODE HERE
        // Initialize a HashSet of each of the words
        HashSet<string> wordSets = [.. words];

        // Initialize an empty list that will store the results
        List<string> result = [];

        // Loop through each word in the words array
        foreach (string word in words)
        {
            // Reverse the current word since we are looking for symmetric pairs
            string reversed = new string([.. word.Reverse()]);

            // Check if the reversed word is in the wordSet and the current word is not equal to the reversed word
            if (wordSets.Contains(reversed) && word != reversed)
            {
                // Format the symmetric pair
                string formatted = $"{reversed} & {word}";

                // Remove both the words and its reversed form from the wordSet
                wordSets.Remove(reversed);
                wordSets.Remove(word);

                // Add the formatted pair to the result
                result.Add(formatted);
            }
        }

        // Return the result as an array
        return [.. result];
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE
            string degree = fields[3];
            if (!degrees.TryAdd(degree, 1))
            {
                degrees[degree] += 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // Initialize a dictionary for each word
        Dictionary<char, int> word1Dict = [];
        Dictionary<char, int> word2Dict = [];

        // Remove spaces from each word
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        // if words are not the same length return false because they cannot be anagrams
        if (word1.Length != word2.Length)
        {
            return false;
        }

        // loop through each character in each word
        for (int i = 0; i < word1.Length; i++)
        {

            // retrieve the character at the current index for each word and store them in separate variables
            char w1 = word1[i];
            char w2 = word2[i];

            // try adding w1 to the word1 dictionary with a value of 1
            if (!word1Dict.TryAdd(w1, 1))
            {
                // If it fails to add the key, then increment the value
                word1Dict[w1] += 1;
            }

            // try adding w2 to the word2 dictionary with a value of 1
            if (!word2Dict.TryAdd(w2, 1))
            {
                // If it fails to add the key, then increment the value
                word2Dict[w2] += 1;
            }
        }

        // If the dictionaries are the same length then they could be anagrams
        foreach (char key in word1Dict.Keys)
        {
            // If the word2 dictionary does not contain the key or the values are not the same then return false
            if (!word2Dict.TryGetValue(key, out int value) || word1Dict[key] != value)
            {
                return false;
            }
        }

        // All anagram testing logic must have passed so return true
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // Function to convert Unix timestamp to DateTime
        DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is in milliseconds
            DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddMilliseconds(unixTimeStamp).ToLocalTime();
        }

        // Filter the earthquakes to only include those that happened today
        Features[] earthquakesToday = [.. featureCollection.features.Where(x => UnixTimeStampToDateTime(x.properties.time).Date == DateTime.Now.Date)];

        // Create a summary of the earthquakes
        string[] summary = earthquakesToday.Select(x =>
        {
            string place = x.properties.place
                // clear space from between distance and km
                .Replace(" km", "km")
                // Replace the comma with a semicolon
                .Replace(",", ";");

            double mag = x.properties.mag ?? 0;
            return $"{place} - Mag {mag}";
        }).ToArray();

        // 3. Return an array of these string descriptions.
        return summary;
    }
}