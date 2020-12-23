using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Solution
{
    public class Note
    {
        public string State { get; set; }
        public string Name { get; set; }

        public Note(string state, string name)
        {
            State = state;
            Name = name;
        }
    }

    public class NotesStore
    {
        private readonly IList<string> _ValidStates = new List<string>() { "completed", "active", "others" };
        private readonly IList<Note> _Notes = new List<Note>();
        public NotesStore() { }
        public void AddNote(String state, String name)
        {
            if (string.IsNullOrEmpty(name)) throw new Exception("Name cannot be empty");

            if (!_ValidStates.Contains(state)) throw new Exception($"Invalid state {state}");

            _Notes.Add(new Note(state, name));
        }
        public List<String> GetNotes(String state)
        {

            if (!_ValidStates.Contains(state)) throw new Exception($"Invalid state {state}");

            return _Notes
                .Where(n => n.State == state)
                .Select(n => n.Name)
                .ToList();
        }
    }

    public class Solution
    {
        public static void Main()
        {
            var notesStoreObj = new NotesStore();
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; i++)
            {
                var operationInfo = Console.ReadLine().Split(' ');
                try
                {
                    if (operationInfo[0] == "AddNote")
                        notesStoreObj.AddNote(operationInfo[1], operationInfo.Length == 2 ? "" : operationInfo[2]);
                    else if (operationInfo[0] == "GetNotes")
                    {
                        var result = notesStoreObj.GetNotes(operationInfo[1]);
                        if (result.Count == 0)
                            Console.WriteLine("No Notes");
                        else
                            Console.WriteLine(string.Join(",", result));
                    }
                    else
                    {
                        Console.WriteLine("Invalid Parameter");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }
            }
        }
    }
}