

namespace KINESIS.Client;

public class InstantMessageResponse : ProtocolResponse
{
    private readonly int _accountId;
    public int AccountId => _accountId;
    private readonly string _nickname;
    public string Nickname => _nickname;
    private readonly string _message;
    public string Message => _message;

    private readonly byte _type;
    private readonly byte _flags;
    private readonly byte _unknown;
    private readonly int _authorId;

    public InstantMessageResponse(int accountId, string nickname, string message, byte type = 1, byte flags = 0, byte unknown = 0, int authorId = 0)
    {
        _accountId = accountId;
        _nickname = nickname;
        _message = message;
        _type = type;
        _flags = flags;
        _unknown = unknown;
        _authorId = authorId;
    }

    public override CommandBuffer Encode()
    {
        CommandBuffer response = new();
        response.WriteInt16(ChatServerResponse.InstantMessageReceived);
        
        response.WriteInt8(_type); // Dynamic Type (0 or 1)

        response.WriteString(_nickname);

        if (_type == 1)
        {
            // Type 1 Fields (Extended)
            response.WriteInt32(_accountId);
            response.WriteInt8(_flags); // Flags
            response.WriteInt8(_unknown); // Unknown Byte (Testing if this is 'Use AuthorID')
            response.WriteString(""); // Color
            response.WriteString(""); // Icon
            response.WriteInt32(_authorId); // AuthorID (Potential Label Override)
        }

        response.WriteString(_message);
        return response;
    }
}
