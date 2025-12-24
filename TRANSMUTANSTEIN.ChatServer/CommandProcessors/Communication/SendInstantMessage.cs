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



        // REVERT: Strategy v9 "True Echo Probe" (Stable State)
        // Findings:
        // - Receiver gets message: YES
        // - Sender Frozen: NO (Implied)
        // - Sender Echo Visible: NO (Invisible)
        // Current Goal: Re-establish this baseline, then try to fix the invisible echo.
        
        session.Send(new InstantMessageResponse(
            session.Account.ID,          // Sender ID 
            recipientSession.Account.Name, // Recipient Name
            request.Message, 
            9,                           // Type 9
            1,                           // Flags 1
            0, 
            session.Account.ID           
        ));

        // Send Message to Recipient (Type 1 Standard)
        // Note: Recipient needs Type 1 to receive Extended Fields (ID, Flags) via InstantMessageResponse.Encode()
        recipientSession.Send(new InstantMessageResponse(
            session.Account.ID,
            session.Account.Name,
            request.Message,
            1,                           // Type 1 (Standard Display)
            1,
            0,
            session.Account.ID
        ));
    }
    else
    {
        // Recipient Offline
        // TODO: Send "User not found" or Offline Message
        session.Send(new WhisperFailedResponse());
    }
}
}


