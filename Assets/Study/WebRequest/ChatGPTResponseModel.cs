using System.Collections.Generic;

[System.Serializable]
public class ChatGPTMessageModel
{
    public string role;
    public string content;
}

/// <summary>
/// ChatGPT APIにRequestを送るためのJSON用クラス
/// </summary>
[System.Serializable]
public class ChatGPTCompletionRequestModel
{
    public string model;
    public List<ChatGPTMessageModel> messages;
}

/// <summary>
/// ChatGPT APIからのResponseを受け取るためのクラス
/// </summary>
[System.Serializable]
public class ChatGPTResponseModel
{
    public string id;
    public string @object;
    public int created;
    public Choice[] choices;
    public Tokens tokens;

    [System.Serializable]
    public class Choice
    {
        public int index;
        public ChatGPTMessageModel message;
        public string finish_reason;
    }

    [System.Serializable]
    public class Tokens
    {
        public int prompt_tokens;
        public int completion_tokens;
        public int total_tokens;
    }
}
