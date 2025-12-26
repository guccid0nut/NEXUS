
using KINESIS;

namespace KINESIS.Client;

public class WhisperSentResponse : ProtocolResponse
{
    private readonly string _recipientName;
    private readonly string _message;

    public WhisperSentResponse(string recipientName, string message)
    {
        _recipientName = recipientName;
        _message = message;
    }

    public override CommandBuffer Encode()
    {
        CommandBuffer response = new();
        // 0x0008 - HON_SC_WHISPER (WhisperedToPlayer)
        // Expected Signature: 'ss' (String Name, String Message)
        response.WriteInt16(ChatServerResponse.WhisperedToPlayer);
        
        response.WriteString(_recipientName);
        response.WriteString(_message);
        
        return response;
    }
}
