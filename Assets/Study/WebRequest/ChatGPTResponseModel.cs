using System.Collections.Generic;

[System.Serializable]
public class ChatGPTMessageModel
{
    public string role;
    public string content;
}

/// <summary>
/// ChatGPT API��Request�𑗂邽�߂�JSON�p�N���X
/// </summary>
[System.Serializable]
public class ChatGPTCompletionRequestModel
{
    public string model;
    public List<ChatGPTMessageModel> messages;
}

/// <summary>
/// ChatGPT API�����Response���󂯎�邽�߂̃N���X
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
