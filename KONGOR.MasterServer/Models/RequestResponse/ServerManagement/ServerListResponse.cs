namespace KONGOR.MasterServer.Models.RequestResponse.ServerManagement;

public class ServerForCreateListResponse(List<MatchServer> servers, string? region, string cookie) : ServerListResponse(cookie)
{
       // TODO: Filter Server List By Region(+Add Support For NEWERTH Region)

        /*

            switch (region)
               {
                   case null:
                       // Blank region indicates ALL servers.
                       lock (SharedContext.IdleServersByRegion)
                       {
                           foreach (KeyValuePair<string, HashSet<ConnectedServer>> entry in SharedContext.IdleServersByRegion)
                           {
                               AddServers(entry.Value);
                           }
                       }
                       break;
                   case "US":
                       // US combines USE and USW
                       lock (SharedContext.IdleServersByRegion)
                       {
                           if (SharedContext.IdleServersByRegion.TryGetValue("USE", out HashSet<ConnectedServer>? useServers))
                           {
                               AddServers(useServers);
                           }
                           if (SharedContext.IdleServersByRegion.TryGetValue("USW", out HashSet<ConnectedServer>? uswServers))
                           {
                               AddServers(uswServers);
                           }
                       }
                       break;
                   default:
                       // Only use a specific region.
                       lock (SharedContext.IdleServersByRegion)
                       {
                           if (SharedContext.IdleServersByRegion.TryGetValue(region, out HashSet<ConnectedServer>? regionSpecificServers))
                           {
                               AddServers(regionSpecificServers);
                           }
                       }
                       break;
               }

         */

    [PhpProperty("server_list")]
    public Dictionary<int, ServerForCreate> Servers { get; set; } = servers.Any() is false? []
        : servers.Where(server => server.Status is ServerStatus.SERVER_STATUS_IDLE)
            .ToDictionary(server => server.ID, server => new ServerForCreate(server.ID.ToString(), server.IPAddress, server.Port.ToString(), server.Location, server.Name, "4.10.1"));
}

public class ServerForJoinListResponse(List<MatchServer> servers, string cookie) : ServerListResponse(cookie)
{
    [PhpProperty("server_list")]
    public List<List<object>> Servers { get; set; } = servers.Any() is false ? []
        : servers // .Where(server => server.Status is ServerStatus.SERVER_STATUS_ACTIVE) // TODO: Filter By Server Status ... Maybe!?
             .Select(server => new List<object>
            {
                $"{server.IPAddress}:{server.Port}",
                "Unknown Server",
                0,
                0,
                0,
                server.Location,
                server.Location
            })
            .ToList();
}

public abstract class ServerListResponse
{
    protected ServerListResponse(string cookie)
    {
        string key = Guid.CreateVersion7().ToString();

        AccountKey = key;
        AccountKeyHash = SRPAuthenticationHandlers.ComputeMatchServerChatAuthenticationHash(key, cookie);
    }

    [PhpProperty("acc_key")]
    public string AccountKey { get; set; }

    [PhpProperty("acc_key_hash")]
    public string AccountKeyHash { get; set; }

    [PhpProperty("vested_threshold")]
    public int VestedThreshold { get; set; } = 5;

    [PhpProperty(0)]
    public bool Zero { get; set; } = true;
}

public class ServerForCreate(string id, string ip, string port, string location, string name, string version) : ServerForResponse(id, ip, port, location, name, version)
{
    [PhpProperty("c_state")]
    public string Category { get; set; } = "1";
}

public class ServerForJoin(string id, string ip, string port, string location, string name, string version) : ServerForResponse(id, ip, port, location, name, version)
{
    [PhpProperty("class")]
    public string Category { get; set; } = "1";
}

public abstract class ServerForResponse(string id, string ip, string port, string location, string name, string version)
{
    [PhpProperty("server_id")]
    public string ID { get; set; } = id;

    [PhpProperty("ip")]
    public string IPAddress { get; set; } = ip;

    [PhpProperty("name")]
    public string Name { get; set; } = name;

    [PhpProperty("version")]
    public string Version { get; set; } = version;

    [PhpProperty("port")]
    public string Port { get; set; } = port;

    [PhpProperty("location")]
    public string Location { get; set; } = location;

    [PhpProperty("region")]
    public string Region { get; set; } = location; // Map Region to Location for now
}
