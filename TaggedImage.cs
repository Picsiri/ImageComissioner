using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ImageCommissioner
{
    public class TaggedImage
    {
        public string ImagePath { get; private set; }
        public List<string> Tags { get; private set; }
        public int Index { get; private set; }

        [JsonConstructor]
        public TaggedImage(string imagePath, List<string> tags, int index)
        {
            ImagePath = imagePath;
            Tags = tags;
            Index = index;
        }

        // Method to set (replace) all tags
        public void SetTags(List<string> newTags)
        {
            Tags = new List<string>(newTags); // Ensures immutability of input list
        }

        // Method to add a single tag
        public void AddTag(string tag)
        {
            if (!Tags.Contains(tag))
            {
                Tags.Add(tag);
            }
        }

        // Method to remove a tag
        public void RemoveTag(string tag)
        {
            Tags.Remove(tag);
        }

        // Check if the image has a specific tag
        public bool HasTag(string tag)
        {
            return Tags.Contains(tag);
        }

        // Convert to a nicely formatted string for debugging or exporting
        public override string ToString()
        {
            return $"{ImagePath} - Tags: {string.Join(", ", Tags)}";
        }
    }
}
