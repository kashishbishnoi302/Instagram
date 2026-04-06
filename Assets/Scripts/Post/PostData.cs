using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PostData
{
    public string username;
    public string profilePic;
    public string place;
    public string image;
    public string[] tags;
    public string caption;
    public string content;
}

[System.Serializable]
public class PostsJsonRoot
{
    public PostData[] posts;
}

public static class PostDataJson
{
    public static List<PostData> LoadPostsFromJson(string json)
    {
        PostsJsonRoot root = JsonUtility.FromJson<PostsJsonRoot>(json);
        if (root?.posts == null || root.posts.Length == 0)
            return new List<PostData>();
        return new List<PostData>(root.posts);
    }
}
