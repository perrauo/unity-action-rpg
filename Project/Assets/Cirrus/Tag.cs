using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cirrus.Tags
{
    public static class Utils
    {
        public static bool IsTagged(this ITagged tagged, Tag tag)
        {
            return tagged.Tags.Contains(tag);
        }

        public static bool IsTaggedAny(this ITagged tagged, IEnumerable<Tag> tags)
        {
            return tagged.Tags.Intersect(tags).Any();
        }

        public static bool IsTaggedAll(this ITagged tagged, IEnumerable<Tag> tags)
        {
            throw new System.Exception("NOT IMPL");
        }
    }

    public interface ITagged
    {
        IEnumerable<Tag> Tags { get; }
    }

    public abstract class Tag : ScriptableObject
    {
        public abstract int Flags { get; }
      
    }
}
