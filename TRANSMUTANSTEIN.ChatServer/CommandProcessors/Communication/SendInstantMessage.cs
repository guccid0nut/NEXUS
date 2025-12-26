using global::TRANSMUTANSTEIN.ChatServer.Domain.Core;
using global::TRANSMUTANSTEIN.ChatServer.Domain.Communication;
using global::TRANSMUTANSTEIN.ChatServer.Utilities;
using KINESIS.Client;
using KINESIS; // For CommandBuffer

namespace TRANSMUTANSTEIN.ChatServer.CommandProcessors.Communication;

[ChatCommand(ChatProtocol.Command.CHAT_CMD_IM)]
public class SendInstantMessage : ISynchronousCommandProcessor<ClientChatSession>
{
    public void Process(ClientChatSession session, ChatBuffer buffer)
    {


        // Decode request using KINESIS model
        InstantMessageRequest request = InstantMessageRequest.Decode(buffer.Data, (int)buffer.Offset + 2, out _);
        
        var recipientSession = Context.ClientChatSessions.Values
            .FirstOrDefault(x => x.Account.Name.Equals(request.Nickname, StringComparison.OrdinalIgnoreCase));

        if (recipientSession != null)
        {
            

        // Send Confirmation to Sender (Echo)











        // Native Protocol Implementation (Ref: hon.c)
        // 1. Send HON_SC_WHISPER (0x08) to Sender -> Unfreezes Client.
        // 2. Send HON_SC_PM (0x1C) to Recipient -> Standard Delivery.
        // 3. (Patch) Send HON_SC_PM (0x1C) to Sender -> Forces Visual Echo (Client Bug Workaround).

        var senderId = session.Account.ID;
        var senderName = session.Account.Name;
        var targetName = recipientSession.Account.Name;

        Console.WriteLine($"[IM] {senderName} ({senderId}) -> {targetName} : {request.Message}");

        // 1. ACK to Sender (Unfreeze) - REMOVED per User Request (Stop "Whisper to..." text)
        // session.Send(new WhisperSentResponse(targetName, request.Message));

        // 2. Visual Echo to Sender (Type 1 Echo)
        // Sender Packet (v18 Logic: Echo with AuthorID = SenderID)
        // Using named parameters for absolute certainty.
        session.Send(new InstantMessageResponse(
            accountId: 0,           // Fake ID 0 (Safe Echo)
            nickname: targetName,   // Window: Recipient
            message: request.Message, 
            type: 1, 
            flags: 1, 
            unknown: 0, 
            authorId: senderId      // AuthorID: Sender (Fixes "Me" label)
        ));

        // 3. Message to Recipient (Strategy v24: Type 0 Short)
        // User pointed to "ss" format (String String) -> Fits Type 0 [Nick][Msg].
        // This forces label to be SenderName (no ID/Flags to override).
        Console.WriteLine($"[IM] Sending to Recipient: v24 Type 0, Name={senderName}");
        
        recipientSession.Send(new InstantMessageResponse(
            accountId: 0,           // Ignored in Type 0
            nickname: senderName,   // Nick: Sender Name (Sole Label Source)
            message: request.Message,
            type: 0,                // Type 0 (Short Packet)
            flags: 0,               // Ignored
            unknown: 0,
            authorId: 0             // Ignored
        ));
    }
    else
    {
        // Recipient Offline
        session.Send(new WhisperFailedResponse());
        Console.WriteLine($"[IM] Failed: Recipient not found.");
    }
}
}
                

