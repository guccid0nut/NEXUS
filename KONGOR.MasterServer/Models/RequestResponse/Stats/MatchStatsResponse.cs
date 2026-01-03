namespace KONGOR.MasterServer.Models.RequestResponse.Stats;

// ReSharper disable InconsistentNaming

public class MatchStatsResponse
{
    /*
     *  Existing Properties
     */

    /// <summary>
    ///     The amount of gold coins that the account owns.
    /// </summary>
    [PhpProperty("points")]
    public required string GoldCoins { get; set; }

    /// <summary>
    ///     The amount of silver coins that the account owns.
    /// </summary>
    [PhpProperty("mmpoints")]
    public required int SilverCoins { get; set; }

    /// <summary>
    ///     A collection containing the summary of the match.
    ///     This is typically a single-element collection.
    /// </summary>
    [PhpProperty("match_summ")]
    public required List<MatchSummary> MatchSummary { get; set; }

    /// <summary>
    ///     A dictionary of player statistics for the match, keyed by the player's account ID.
    /// </summary>
    [PhpProperty("match_player_stats")]
    public required Dictionary<int, PlayerStatistics> PlayerStatistics { get; set; }

    /// <summary>
    ///     A dictionary of player inventories for the match, keyed by the player's account ID.
    /// </summary>
    [PhpProperty("inventory")]
    public required Dictionary<int, PlayerInventory> PlayerInventories { get; set; }

    /// <summary>
    ///     Mastery details for the hero played in the match.
    /// </summary>
    public required MatchMastery MatchMastery { get; set; }

    /// <summary>
    ///     Tokens for the Kros Dice random ability draft that players can use while dead or in spawn in a Kros Mode match.
    ///     Only works in matches which have the "GAME_OPTION_SHUFFLE_ABILITIES" flag enabled, such as Rift Wars.
    /// </summary>
    [PhpProperty("dice_tokens")]
    public int DiceTokens { get; set; } = 100;

    /// <summary>
    ///     Tokens which grant temporary access to game modes (MidWars, Grimm's Crossing, etc.) for free-to-play players.
    ///     Alternative to permanent "Game Pass" or temporary "Game Access" products (e.g. "m.midwars.pass", "m.midwars.access").
    ///     Legacy accounts have full access to all game modes, and so do accounts which own the "m.allmodes.pass" store item.
    /// </summary>
    [PhpProperty("game_tokens")]
    public int GameTokens { get; set; } = 100;

    /// <summary>
    ///     Controls the visual appearance of tournament/seasonal buildings (towers, barracks, etc.) in matches.
    ///     <code>
    ///         Level 0     -> default appearance
    ///         Level 01-09 -> tier 01 appearance
    ///         Level 10-24 -> tier 02 appearance
    ///         Level 25-49 -> tier 03 appearance
    ///         Level 50-74 -> tier 04 appearance
    ///         Level 75-99 -> tier 05 appearance
    ///         Level 100+  -> tier 06 appearance
    ///     </code>
    /// </summary>
    [PhpProperty("season_level")]
    public int SeasonLevel { get; set; } = 100;

    /// <summary>
    ///     Unused.
    ///     <br/>
    ///     May have been intended as a seasonal progression system similar to "season_level" but for creep cosmetics.
    ///     For the sake of consistency with "season_level", this property is set to "100", although it most likely has no effect.
    /// </summary>
    [PhpProperty("creep_level")]
    public int CreepLevel { get; set; } = 100;

    /// <summary>
    ///     The collection of owned store items.
    ///     <code>
    ///         Chat Name Colour       =>   "cc"
    ///         Chat Symbol            =>   "cs"
    ///         Account Icon           =>   "ai"
    ///         Alternative Avatar     =>   "aa"
    ///         Announcer Voice        =>   "av"
    ///         Taunt                  =>   "t"
    ///         Courier                =>   "c"
    ///         Hero                   =>   "h"
    ///         Early-Access Product   =>   "eap"
    ///         Status                 =>   "s"
    ///         Miscellaneous          =>   "m"
    ///         Ward                   =>   "w"
    ///         Enhancement            =>   "en"
    ///         Coupon                 =>   "cp"
    ///         Mastery                =>   "ma"
    ///         Creep                  =>   "cr"
    ///         Building               =>   "bu"
    ///         Taunt Badge            =>   "tb"
    ///         Teleportation Effect   =>   "te"
    ///         Selection Circle       =>   "sc"
    ///         Bundle                 =>   string.Empty
    ///     </code>
    /// </summary>
    [PhpProperty("my_upgrades")]
    public required List<string> OwnedStoreItems { get; set; }

    /// <summary>
    ///     The collection of selected store items.
    /// </summary>
    [PhpProperty("selected_upgrades")]
    public required List<string> SelectedStoreItems { get; set; }

    /// <summary>
    ///     The index of the custom icon equipped, or "0" if no custom icon is equipped.
    /// </summary>
    [PhpProperty("slot_id")]
    public required string CustomIconSlotID { get; set; }

    /// <summary>
    ///     The server time (in UTC seconds).
    /// </summary>
    [PhpProperty("timestamp")]
    public long ServerTimestamp { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

    /// <summary>
    ///     Used for the quest system, which has been disabled.
    ///     <br/>
    ///     While the quest system is disabled, this dictionary contains a single element with a key of "error".
    ///     The object which is the value of this element has the values of all its properties set to "0".
    /// </summary>
    [PhpProperty("quest_system")]
    public Dictionary<string, QuestSystem> QuestSystem { get; set; } = new() { { "error", new QuestSystem() } };

    /// <summary>
    ///     Unused.
    ///     <br/>
    ///     Statistics related to the "Event Codex" (otherwise known as "Ascension") seasonal system.
    /// </summary>
    [PhpProperty("season_system")]
    public SeasonSystem SeasonSystem { get; set; } = new ();

    /// <summary>
    ///     Statistics related to the Champions Of Newerth seasonal campaign.
    /// </summary>
    [PhpProperty("con_reward")]
    public required CampaignReward CampaignReward { get; set; } = new ();

    /// <summary>
    ///     The minimum number of matches a free-to-play (trial) account must complete to become verified.
    ///     A verified account is considered to have full account privileges, and is no longer considered a restricted account.
    /// </summary>
    [PhpProperty("vested_threshold")]
    public int VestedThreshold => 5;

    /// <summary>
    ///     Unknown.
    ///     <br/>
    ///     Seems to be set to "true" on a successful response, or to "false" if an error occurs.
    /// </summary>
    [PhpProperty(0)]
    public bool Zero => true;

    /*
     *  Migrated Properties
     */

    /// <summary>
    ///     A list containing the primary summary of the match.
    ///     This is typically a single-element list but structured as an array in the original JSON.
    /// </summary>
    [PhpProperty("match_summ")]
    public required List<MatchSummary> MatchSummary { get; set; }

    /// <summary>
    ///     A dictionary of player statistics for the match, keyed by the player's account ID (or a variation thereof).
    /// </summary>
    [PhpProperty("match_player_stats")]
    public required Dictionary<string, MatchPlayerStats> MatchPlayerStats { get; set; }

    /// <summary>
    ///     A dictionary of player inventories for the match, keyed by the player's account ID.
    /// </summary>
    [PhpProperty("inventory")]
    public required Dictionary<string, MatchInventory> Inventory { get; set; }

    /// <summary>
    ///     Rewards or progression updates related to the match.
    /// </summary>
    [PhpProperty("con_reward")]
    public required ConReward ConReward { get; set; }

    /// <summary>
    ///     Mastery (hero progression) updates related to the match.
    /// </summary>
    [PhpProperty("match_mastery")]
    public required MatchMastery MatchMastery { get; set; }

    /// <summary>
    ///     Seasonal progression system data (diamonds/rewards).
    /// </summary>
    [PhpProperty("season_system")]
    public required SeasonSystem SeasonSystem { get; set; }
}

public class MatchSummary
{
    /// <summary>
    ///     The unique identifier for the match.
    /// </summary>
    [PhpProperty("match_id")]
    public required string MatchID { get; set; }

    /// <summary>
    ///     The ID of the server where the match took place.
    /// </summary>
    [PhpProperty("server_id")]
    public required string ServerID { get; set; }

    /// <summary>
    ///     The name of the map played (e.g., "newerthearth").
    /// </summary>
    [PhpProperty("map")]
    public required string Map { get; set; }

    /// <summary>
    ///     The version hash or identifier of the map.
    /// </summary>
    [PhpProperty("map_version")]
    public required string MapVersion { get; set; }

    /// <summary>
    ///     The total duration of the match in time format (H:MM:SS or similar).
    /// </summary>
    [PhpProperty("time_played")]
    public required string TimePlayed { get; set; }

    /// <summary>
    ///     The host address where the replay file is stored.
    /// </summary>
    [PhpProperty("file_host")]
    public required string FileHost { get; set; }

    /// <summary>
    ///     The size of the replay file in bytes.
    /// </summary>
    [PhpProperty("file_size")]
    public required string FileSize { get; set; }

    /// <summary>
    ///     The filename of the replay.
    /// </summary>
    [PhpProperty("file_name")]
    public required string FileName { get; set; }

    /// <summary>
    ///     The completion state of the match.
    /// </summary>
    [PhpProperty("c_state")]
    public required string CState { get; set; }

    /// <summary>
    ///     The game client version used for the match.
    /// </summary>
    [PhpProperty("version")]
    public required string Version { get; set; }

    /// <summary>
    ///     The average Public Skill Rating (PSR) of the match.
    /// </summary>
    [PhpProperty("avgpsr")]
    public required string AvgPsr { get; set; }

    /// <summary>
    ///     The date the match was played (e.g., MM/DD/YYYY).
    /// </summary>
    [PhpProperty("date")]
    public required string Date { get; set; }

    /// <summary>
    ///     The time of day when the match started.
    /// </summary>
    [PhpProperty("time")]
    public required string Time { get; set; }

    /// <summary>
    ///     The name of the match lobby.
    /// </summary>
    [PhpProperty("mname")]
    public required string MatchName { get; set; }

    /// <summary>
    ///     The class identifier for the match type (e.g., "ver" for verified).
    /// </summary>
    [PhpProperty("class")]
    public required string Class { get; set; }

    /// <summary>
    ///     Indicates if the match was private ("1" for yes, "0" for no).
    /// </summary>
    [PhpProperty("private")]
    public required string Private { get; set; }

    /// <summary>
    ///     "No Mods" mode flag.
    /// </summary>
    [PhpProperty("nm")]
    public required string Nm { get; set; }

    /// <summary>
    ///     "Single Draft" mode flag.
    /// </summary>
    [PhpProperty("sd")]
    public required string Sd { get; set; }

    /// <summary>
    ///     "Random Draft" mode flag.
    /// </summary>
    [PhpProperty("rd")]
    public required string Rd { get; set; }

    /// <summary>
    ///     "Death Match" mode flag.
    /// </summary>
    [PhpProperty("dm")]
    public required string Dm { get; set; }

    /// <summary>
    ///     "Banning Draft" mode flag.
    /// </summary>
    [PhpProperty("bd")]
    public required string Bd { get; set; }

    /// <summary>
    ///     "Banning Pick" mode flag.
    /// </summary>
    [PhpProperty("bp")]
    public required string Bp { get; set; }

    /// <summary>
    ///     "All Random" mode flag.
    /// </summary>
    [PhpProperty("ar")]
    public required string Ar { get; set; }

    /// <summary>
    ///     "Captains Draft" mode flag.
    /// </summary>
    [PhpProperty("cd")]
    public required string Cd { get; set; }

    /// <summary>
    ///     "Captains Mode" mode flag.
    /// </summary>
    [PhpProperty("cm")]
    public required string Cm { get; set; }

    /// <summary>
    ///     "League Play" mode flag.
    /// </summary>
    [PhpProperty("lp")]
    public required string Lp { get; set; }

    /// <summary>
    ///     "Blind Ban" mode flag.
    /// </summary>
    [PhpProperty("bb")]
    public required string Bb { get; set; }

    /// <summary>
    ///     "Balanced Mode" mode flag.
    /// </summary>
    [PhpProperty("bm")]
    public required string Bm { get; set; }

    /// <summary>
    ///     "Kros Mode" flag.
    /// </summary>
    [PhpProperty("km")]
    public required string Km { get; set; }

    /// <summary>
    ///     The league identifier associated with the match.
    /// </summary>
    [PhpProperty("league")]
    public required string League { get; set; }

    /// <summary>
    ///     The maximum number of players allowed in the match (e.g., "10").
    /// </summary>
    [PhpProperty("max_players")]
    public required string MaxPlayers { get; set; }

    /// <summary>
    ///     The tier of the match (e.g., "normal", "casual").
    /// </summary>
    [PhpProperty("tier")]
    public required string Tier { get; set; }

    /// <summary>
    ///     "No Repick" option flag.
    /// </summary>
    [PhpProperty("no_repick")]
    public required string NoRepick { get; set; }

    /// <summary>
    ///     "No Agility" option flag.
    /// </summary>
    [PhpProperty("no_agi")]
    public required string NoAgi { get; set; }

    /// <summary>
    ///     "Drop Items" option flag.
    /// </summary>
    [PhpProperty("drp_itm")]
    public required string DropItems { get; set; }

    /// <summary>
    ///     "No Timer" option flag.
    /// </summary>
    [PhpProperty("no_timer")]
    public required string NoTimer { get; set; }

    /// <summary>
    ///     "Reverse Hero Selection" option flag.
    /// </summary>
    [PhpProperty("rev_hs")]
    public required string RevHs { get; set; }

    /// <summary>
    ///     "No Swap" option flag.
    /// </summary>
    [PhpProperty("no_swap")]
    public required string NoSwap { get; set; }

    /// <summary>
    ///     "No Intelligence" option flag.
    /// </summary>
    [PhpProperty("no_int")]
    public required string NoInt { get; set; }

    /// <summary>
    ///     "Alternative Pick" option flag.
    /// </summary>
    [PhpProperty("alt_pick")]
    public required string AltPick { get; set; }

    /// <summary>
    ///     "Veto" option flag.
    /// </summary>
    [PhpProperty("veto")]
    public required string Veto { get; set; }

    /// <summary>
    ///     "Shuffle" option flag.
    /// </summary>
    [PhpProperty("shuf")]
    public required string Shuffle { get; set; }

    /// <summary>
    ///     "No Strength" option flag.
    /// </summary>
    [PhpProperty("no_str")]
    public required string NoStr { get; set; }

    /// <summary>
    ///     "No Power-ups" option flag.
    /// </summary>
    [PhpProperty("no_pups")]
    public required string NoPowerups { get; set; }

    /// <summary>
    ///     "Duplicate Heroes" option flag.
    /// </summary>
    [PhpProperty("dup_h")]
    public required string DuplicateHeroes { get; set; }

    /// <summary>
    ///     "All Pick" mode flag.
    /// </summary>
    [PhpProperty("ap")]
    public required string Ap { get; set; }

    /// <summary>
    ///     "Bot Reassignment" or Battle Royale flag.
    /// </summary>
    [PhpProperty("br")]
    public required string Br { get; set; }

    /// <summary>
    ///     "Easy Mode" flag.
    /// </summary>
    [PhpProperty("em")]
    public required string Em { get; set; }

    /// <summary>
    ///     "Casual Mode" flag.
    /// </summary>
    [PhpProperty("cas")]
    public required string Cas { get; set; }

    /// <summary>
    ///     "Force Random" or "Random Start" flag.
    /// </summary>
    [PhpProperty("rs")]
    public required string Rs { get; set; }

    /// <summary>
    ///     "No Leaver" flag, or "New Lobby" flag.
    /// </summary>
    [PhpProperty("nl")]
    public required string Nl { get; set; }

    /// <summary>
    ///     Indicates if the match was official ("1" for yes).
    /// </summary>
    [PhpProperty("officl")]
    public required string Official { get; set; }

    /// <summary>
    ///     "No Stats" match flag.
    /// </summary>
    [PhpProperty("no_stats")]
    public required string NoStats { get; set; }

    /// <summary>
    ///     "Auto Ban" option flag.
    /// </summary>
    [PhpProperty("ab")]
    public required string Ab { get; set; }

    /// <summary>
    ///     "Hardcore" mode flag.
    /// </summary>
    [PhpProperty("hardcore")]
    public required string Hardcore { get; set; }

    /// <summary>
    ///     "Dev Heroes" allowed flag.
    /// </summary>
    [PhpProperty("dev_heroes")]
    public required string DevHeroes { get; set; }

    /// <summary>
    ///     "Verified Only" match flag.
    /// </summary>
    [PhpProperty("verified_only")]
    public required string VerifiedOnly { get; set; }

    /// <summary>
    ///     "Gated" match flag (requires specific criteria).
    /// </summary>
    [PhpProperty("gated")]
    public required string Gated { get; set; }

    /// <summary>
    ///     "Rapid Fire" mode flag.
    /// </summary>
    [PhpProperty("rapidfire")]
    public required string RapidFire { get; set; }

    /// <summary>
    ///     The timestamp when the match was recorded/finished.
    /// </summary>
    [PhpProperty("timestamp")]
    public int Timestamp { get; set; }

    /// <summary>
    ///     The URL to the replay file.
    /// </summary>
    [PhpProperty("url")]
    public required string Url { get; set; }

    /// <summary>
    ///     The size of the replay file in human-readable string format.
    /// </summary>
    [PhpProperty("size")]
    public required string Size { get; set; }

    /// <summary>
    ///     The name of the match.
    /// </summary>
    [PhpProperty("name")]
    public required string Name { get; set; }

    /// <summary>
    ///     The directory path of the replay.
    /// </summary>
    [PhpProperty("dir")]
    public required string Dir { get; set; }

    /// <summary>
    ///     The S3 bucket URL for the replay.
    /// </summary>
    [PhpProperty("s3_url")]
    public required string S3Url { get; set; }

    /// <summary>
    ///     The ID (0 or 1) of the team that won the match.
    /// </summary>
    [PhpProperty("winning_team")]
    public required string WinningTeam { get; set; }

    /// <summary>
    ///     The game mode identifier (e.g., "1" for Normal, "2" for Casual).
    /// </summary>
    [PhpProperty("gamemode")]
    public required string GameMode { get; set; }

    /// <summary>
    ///     The account ID of the Most Valuable Player.
    /// </summary>
    [PhpProperty("mvp")]
    public required string Mvp { get; set; }

    /// <summary>
    ///     The account ID of the player awarded "Annihilation" (5 kills).
    /// </summary>
    [PhpProperty("awd_mann")]
    public required string AwardAnnihilation { get; set; }

    /// <summary>
    ///     The account ID of the player awarded "Quad Kill" (4 kills).
    /// </summary>
    [PhpProperty("awd_mqk")]
    public required string AwardQuadKill { get; set; }

    /// <summary>
    ///     The account ID of the player awarded "Legendary Kill Streak" (15+ kills).
    /// </summary>
    [PhpProperty("awd_lgks")]
    public required string AwardLegendaryKillStreak { get; set; }

    /// <summary>
    ///     The account ID of the player awarded "Smackdown" (taunt kill).
    /// </summary>
    [PhpProperty("awd_msd")]
    public required string AwardSmackDown { get; set; }

    /// <summary>
    ///     The account ID of the player awarded "Multi Kill".
    /// </summary>
    [PhpProperty("awd_mkill")]
    public required string AwardMultiKill { get; set; }

    /// <summary>
    ///     The account ID of the player awarded "Most Assists".
    /// </summary>
    [PhpProperty("awd_masst")]
    public required string AwardMultiAssist { get; set; }

    /// <summary>
    ///     The account ID of the player awarded "Lowest Health Death" (surviving with low HP?). Or perhaps Most deaths?
    /// </summary>
    [PhpProperty("awd_ledth")]
    public required string AwardLowHealthDeath { get; set; }

    /// <summary>
    ///     The account ID of the player awarded "Most Building Damage".
    /// </summary>
    [PhpProperty("awd_mbdmg")]
    public required string AwardMaxBuildingDamage { get; set; }

    /// <summary>
    ///     The account ID of the player awarded "Most Wards Killed".
    /// </summary>
    [PhpProperty("awd_mwk")]
    public required string AwardMaxWardsKilled { get; set; }

    /// <summary>
    ///     The account ID of the player awarded "Most Hero Damage".
    /// </summary>
    [PhpProperty("awd_mhdd")]
    public required string AwardMaxHeroDamage { get; set; }

    /// <summary>
    ///     The account ID of the player awarded "Highest Creep Score".
    /// </summary>
    [PhpProperty("awd_hcs")]
    public required string AwardHighestCreepScore { get; set; }
}

public class MatchPlayerStats
{
    /// <summary>
    ///     The unique identifier for the match.
    /// </summary>
    [PhpProperty("match_id")]
    public required string MatchID { get; set; }

    /// <summary>
    ///     The player's account ID.
    /// </summary>
    [PhpProperty("account_id")]
    public required string AccountID { get; set; }

    /// <summary>
    ///     The player's clan ID, if applicable.
    /// </summary>
    [PhpProperty("clan_id")]
    public required string ClanID { get; set; }

    /// <summary>
    ///     The ID of the hero played.
    /// </summary>
    [PhpProperty("hero_id")]
    public required string HeroID { get; set; }

    /// <summary>
    ///     The visual position/slot of the player in the lobby/game.
    /// </summary>
    [PhpProperty("position")]
    public required string Position { get; set; }

    /// <summary>
    ///     The team ID (1 for Legion, 2 for Hellbourne).
    /// </summary>
    [PhpProperty("team")]
    public required string Team { get; set; }

    /// <summary>
    ///     The hero level reached at the end of the match.
    /// </summary>
    [PhpProperty("level")]
    public required string Level { get; set; }

    /// <summary>
    ///     "1" if the player won, "0" otherwise.
    /// </summary>
    [PhpProperty("wins")]
    public required string Wins { get; set; }

    /// <summary>
    ///     "1" if the player lost, "0" otherwise.
    /// </summary>
    [PhpProperty("losses")]
    public required string Losses { get; set; }

    /// <summary>
    ///     "1" if the outcome was a concession.
    /// </summary>
    [PhpProperty("concedes")]
    public required string Concedes { get; set; }

    /// <summary>
    ///     The number of times this player voted to concede.
    /// </summary>
    [PhpProperty("concedevotes")]
    public required string ConcedeVotes { get; set; }

    /// <summary>
    ///     The number of times the player bought back into the game.
    /// </summary>
    [PhpProperty("buybacks")]
    public required string Buybacks { get; set; }

    /// <summary>
    ///     "1" if the player disconnected/terminated connection.
    /// </summary>
    [PhpProperty("discos")]
    public required string Discos { get; set; }

    /// <summary>
    ///     "1" if the player was kicked.
    /// </summary>
    [PhpProperty("kicked")]
    public required string Kicked { get; set; }

    /// <summary>
    ///     The player's Public Skill Rating (PSR) before the match?
    /// </summary>
    [PhpProperty("pub_skill")]
    public required string PubSkill { get; set; }

    /// <summary>
    ///     The number of public matches played.
    /// </summary>
    [PhpProperty("pub_count")]
    public required string PubCount { get; set; }

    /// <summary>
    ///     The player's Matchmaking Rating (MMR) for solo queue.
    /// </summary>
    [PhpProperty("amm_solo_rating")]
    public required string AmmSoloRating { get; set; }

    /// <summary>
    ///     The number of solo matchmaking games played.
    /// </summary>
    [PhpProperty("amm_solo_count")]
    public required string AmmSoloCount { get; set; }

    /// <summary>
    ///     The player's Matchmaking Rating (MMR) for team queue.
    /// </summary>
    [PhpProperty("amm_team_rating")]
    public required string AmmTeamRating { get; set; }

    /// <summary>
    ///     The number of team matchmaking games played.
    /// </summary>
    [PhpProperty("amm_team_count")]
    public required string AmmTeamCount { get; set; }

    /// <summary>
    ///     The average score (GPM/XPM composite?) or an internal score metric.
    /// </summary>
    [PhpProperty("avg_score")]
    public required string AvgScore { get; set; }

    /// <summary>
    ///     Total number of enemy heroes killed.
    /// </summary>
    [PhpProperty("herokills")]
    public required string HeroKills { get; set; }

    /// <summary>
    ///     Total damage dealt to enemy heroes.
    /// </summary>
    [PhpProperty("herodmg")]
    public required string HeroDamage { get; set; }

    /// <summary>
    ///     Experience earned from killing heroes.
    /// </summary>
    [PhpProperty("heroexp")]
    public required string HeroExp { get; set; }

    /// <summary>
    ///     Gold earned from killing heroes.
    /// </summary>
    [PhpProperty("herokillsgold")]
    public required string HeroKillsGold { get; set; }

    /// <summary>
    ///     Number of assists.
    /// </summary>
    [PhpProperty("heroassists")]
    public required string HeroAssists { get; set; }

    /// <summary>
    ///     Total number of times the player died.
    /// </summary>
    [PhpProperty("deaths")]
    public required string Deaths { get; set; }

    /// <summary>
    ///     Total gold lost due to dying.
    /// </summary>
    [PhpProperty("goldlost2death")]
    public required string GoldLostToDeath { get; set; }

    /// <summary>
    ///     Total seconds spent dead.
    /// </summary>
    [PhpProperty("secs_dead")]
    public required string SecondsDead { get; set; }

    /// <summary>
    ///     Total team creep kills (assists on creeps?).
    /// </summary>
    [PhpProperty("teamcreepkills")]
    public required string TeamCreepKills { get; set; }

    /// <summary>
    ///     Damage dealt to team creeps (denies?).
    /// </summary>
    [PhpProperty("teamcreepdmg")]
    public required string TeamCreepDamage { get; set; }

    /// <summary>
    ///     Experience from team creeps.
    /// </summary>
    [PhpProperty("teamcreepexp")]
    public required string TeamCreepExp { get; set; }

    /// <summary>
    ///     Gold from team creeps.
    /// </summary>
    [PhpProperty("teamcreepgold")]
    public required string TeamCreepGold { get; set; }

    /// <summary>
    ///     Number of neutral creeps killed.
    /// </summary>
    [PhpProperty("neutralcreepkills")]
    public required string NeutralCreepKills { get; set; }

    /// <summary>
    ///     Damage dealt to neutral creeps.
    /// </summary>
    [PhpProperty("neutralcreepdmg")]
    public required string NeutralCreepDamage { get; set; }

    /// <summary>
    ///     Experience earned from neutral creeps.
    /// </summary>
    [PhpProperty("neutralcreepexp")]
    public required string NeutralCreepExp { get; set; }

    /// <summary>
    ///     Gold earned from neutral creeps.
    /// </summary>
    [PhpProperty("neutralcreepgold")]
    public required string NeutralCreepGold { get; set; }

    /// <summary>
    ///     Total damage dealt to structures (towers, racks, shrine).
    /// </summary>
    [PhpProperty("bdmg")]
    public required string BuildingDamage { get; set; }

    /// <summary>
    ///     Experience earned from destroying buildings.
    /// </summary>
    [PhpProperty("bdmgexp")]
    public required string BuildingDamageExp { get; set; }

    /// <summary>
    ///     Number of buildings razed/destroyed.
    /// </summary>
    [PhpProperty("razed")]
    public required string Razed { get; set; }

    /// <summary>
    ///     Gold earned from destroying buildings.
    /// </summary>
    [PhpProperty("bgold")]
    public required string BuildingGold { get; set; }

    /// <summary>
    ///     Number of creeps denied.
    /// </summary>
    [PhpProperty("denies")]
    public required string Denies { get; set; }

    /// <summary>
    ///     Amount of experience denied to the enemy.
    /// </summary>
    [PhpProperty("exp_denied")]
    public required string ExpDenied { get; set; }

    /// <summary>
    ///     Total gold earned (GPM related).
    /// </summary>
    [PhpProperty("gold")]
    public required string Gold { get; set; }

    /// <summary>
    ///     Total gold spent on items and buybacks.
    /// </summary>
    [PhpProperty("gold_spent")]
    public required string GoldSpent { get; set; }

    /// <summary>
    ///     Total experience earned (XPM related).
    /// </summary>
    [PhpProperty("exp")]
    public required string Exp { get; set; }

    /// <summary>
    ///     Number of actions performed (APM proxy).
    /// </summary>
    [PhpProperty("actions")]
    public required string Actions { get; set; }

    /// <summary>
    ///     Duration of the match for this player in seconds.
    /// </summary>
    [PhpProperty("secs")]
    public required string Seconds { get; set; }

    /// <summary>
    ///     Number of consumables used.
    /// </summary>
    [PhpProperty("consumables")]
    public required string Consumables { get; set; }

    /// <summary>
    ///     Number of wards placed.
    /// </summary>
    [PhpProperty("wards")]
    public required string Wards { get; set; }

    /// <summary>
    ///     Time spent earning experience (combat time).
    /// </summary>
    [PhpProperty("time_earning_exp")]
    public required string TimeEarningExp { get; set; }

    /// <summary>
    ///     "1" if the player achieved "Bloodlust" (First Blood).
    /// </summary>
    [PhpProperty("bloodlust")]
    public required string Bloodlust { get; set; }

    /// <summary>
    ///     Number of "Double Kill" streaks.
    /// </summary>
    [PhpProperty("doublekill")]
    public required string DoubleKill { get; set; }

    /// <summary>
    ///     Number of "Triple Kill" streaks.
    /// </summary>
    [PhpProperty("triplekill")]
    public required string TripleKill { get; set; }

    /// <summary>
    ///     Number of "Quad Kill" streaks.
    /// </summary>
    [PhpProperty("quadkill")]
    public required string QuadKill { get; set; }

    /// <summary>
    ///     Number of "Annihilation" (Penta Kill) streaks.
    /// </summary>
    [PhpProperty("annihilation")]
    public required string Annihilation { get; set; }

    /// <summary>
    ///     Number of 3-kill streaks (Serial Killer).
    /// </summary>
    [PhpProperty("ks3")]
    public required string KillStreak3 { get; set; }

    /// <summary>
    ///     Number of 4-kill streaks (Ultimate Warrior).
    /// </summary>
    [PhpProperty("ks4")]
    public required string KillStreak4 { get; set; }

    /// <summary>
    ///     Number of 5-kill streaks (Legendary).
    /// </summary>
    [PhpProperty("ks5")]
    public required string KillStreak5 { get; set; }

    /// <summary>
    ///     Number of 6-kill streaks (Onslaught).
    /// </summary>
    [PhpProperty("ks6")]
    public required string KillStreak6 { get; set; }

    /// <summary>
    ///     Number of 7-kill streaks (Savage Sick).
    /// </summary>
    [PhpProperty("ks7")]
    public required string KillStreak7 { get; set; }

    /// <summary>
    ///     Number of 8-kill streaks (Dominating).
    /// </summary>
    [PhpProperty("ks8")]
    public required string KillStreak8 { get; set; }

    /// <summary>
    ///     Number of 9-kill streaks (Champion of Newerth).
    /// </summary>
    [PhpProperty("ks9")]
    public required string KillStreak9 { get; set; }

    /// <summary>
    ///     Number of 10-kill streaks (Bloodbath).
    /// </summary>
    [PhpProperty("ks10")]
    public required string KillStreak10 { get; set; }

    /// <summary>
    ///     Number of 15-kill streaks (Immortal).
    /// </summary>
    [PhpProperty("ks15")]
    public required string KillStreak15 { get; set; }

    /// <summary>
    ///     Number of Smackdowns performed (killing taunted enemy).
    /// </summary>
    [PhpProperty("smackdown")]
    public required string SmackDown { get; set; }

    /// <summary>
    ///     Number of Humiliations suffered (being killed while taunting?).
    /// </summary>
    [PhpProperty("humiliation")]
    public required string Humiliation { get; set; }

    /// <summary>
    ///     Count of specific nemesis kills.
    /// </summary>
    [PhpProperty("nemesis")]
    public required string Nemesis { get; set; }

    /// <summary>
    ///     Count of retribution kills.
    /// </summary>
    [PhpProperty("retribution")]
    public required string Retribution { get; set; }

    /// <summary>
    ///     "1" if a token was used for this match?
    /// </summary>
    [PhpProperty("used_token")]
    public required string UsedToken { get; set; }

    /// <summary>
    ///     The client version or name used.
    /// </summary>
    [PhpProperty("cli_name")]
    public required string ClientName { get; set; }

    /// <summary>
    ///     Clan tag of the player.
    /// </summary>
    [PhpProperty("tag")]
    public required string Tag { get; set; }

    /// <summary>
    ///     Current nickname of the player.
    /// </summary>
    [PhpProperty("nickname")]
    public required string Nickname { get; set; }

    /// <summary>
    ///     The name of the alternative avatar used for the hero.
    /// </summary>
    [PhpProperty("alt_avatar_name")]
    public required string AltAvatarName { get; set; }

    /// <summary>
    ///     Campaign or seasonal progression info for this player.
    /// </summary>
    [PhpProperty("campaign_info")]
    public required MatchPlayerCampaignInfo CampaignInfo { get; set; }
}

public class MatchPlayerCampaignInfo
{
    /// <summary>
    ///     The unique identifier for the match.
    /// </summary>
    [PhpProperty("match_id")]
    public required string MatchID { get; set; }

    /// <summary>
    ///     The player's account ID.
    /// </summary>
    [PhpProperty("account_id")]
    public required string AccountID { get; set; }

    /// <summary>
    ///     "1" if the match was casual mode.
    /// </summary>
    [PhpProperty("is_casual")]
    public required string IsCasual { get; set; }

    /// <summary>
    ///     MMR before the match.
    /// </summary>
    [PhpProperty("mmr_before")]
    public required string MmrBefore { get; set; }

    /// <summary>
    ///     MMR after the match.
    /// </summary>
    [PhpProperty("mmr_after")]
    public required string MmrAfter { get; set; }

    /// <summary>
    ///     Rank medal before the match.
    /// </summary>
    [PhpProperty("medal_before")]
    public required string MedalBefore { get; set; }

    /// <summary>
    ///     Rank medal after the match.
    /// </summary>
    [PhpProperty("medal_after")]
    public required string MedalAfter { get; set; }

    /// <summary>
    ///     The current season identifier.
    /// </summary>
    [PhpProperty("season")]
    public required string Season { get; set; }

    /// <summary>
    ///     Number of placement matches played.
    /// </summary>
    [PhpProperty("placement_matches")]
    public int PlacementMatches { get; set; }

    /// <summary>
    ///     Number of wins during placement.
    /// </summary>
    [PhpProperty("placement_wins")]
    public required string PlacementWins { get; set; }
}

public class MatchInventory
{
    /// <summary>
    ///     The player's account ID.
    /// </summary>
    [PhpProperty("account_id")]
    public required string AccountID { get; set; }

    /// <summary>
    ///     The unique identifier for the match.
    /// </summary>
    [PhpProperty("match_id")]
    public required string MatchID { get; set; }

    /// <summary>
    ///     Item in slot 1 (Top Left).
    /// </summary>
    [PhpProperty("slot_1")]
    public required string Slot1 { get; set; }

    /// <summary>
    ///     Item in slot 2 (Top Center).
    /// </summary>
    [PhpProperty("slot_2")]
    public required string Slot2 { get; set; }

    /// <summary>
    ///     Item in slot 3 (Top Right).
    /// </summary>
    [PhpProperty("slot_3")]
    public required object Slot3 { get; set; }

    /// <summary>
    ///     Item in slot 4 (Bottom Left).
    /// </summary>
    [PhpProperty("slot_4")]
    public required string Slot4 { get; set; }

    /// <summary>
    ///     Item in slot 5 (Bottom Center).
    /// </summary>
    [PhpProperty("slot_5")]
    public required string Slot5 { get; set; }

    /// <summary>
    ///     Item in slot 6 (Bottom Right).
    /// </summary>
    [PhpProperty("slot_6")]
    public required string Slot6 { get; set; }
}

public class ConReward
{
    /// <summary>
    ///     Level before the match/reward.
    /// </summary>
    [PhpProperty("old_lvl")]
    public int OldLevel { get; set; }

    /// <summary>
    ///     Current level after the match.
    /// </summary>
    [PhpProperty("curr_lvl")]
    public int CurrentLevel { get; set; }

    /// <summary>
    ///     Next level goal.
    /// </summary>
    [PhpProperty("next_lvl")]
    public int NextLevel { get; set; }

    /// <summary>
    ///     Rank required for something?
    /// </summary>
    [PhpProperty("require_rank")]
    public int RequireRank { get; set; }

    /// <summary>
    ///     Matches needed to play to unlock something.
    /// </summary>
    [PhpProperty("need_more_play")]
    public int NeedMorePlay { get; set; }

    /// <summary>
    ///     Experience percentage towards next level before match.
    /// </summary>
    [PhpProperty("percentage_before")]
    public required string PercentageBefore { get; set; }

    /// <summary>
    ///     Experience percentage towards next level after match.
    /// </summary>
    [PhpProperty("percentage")]
    public required string Percentage { get; set; }
}

public class MatchMastery
{
    /// <summary>
    ///     Client name/version.
    /// </summary>
    [PhpProperty("cli_name")]
    public required string ClientName { get; set; }

    /// <summary>
    ///     Base mastery experience.
    /// </summary>
    [PhpProperty("mastery_exp_original")]
    public int MasteryExpOriginal { get; set; }

    /// <summary>
    ///     Mastery experience earned from the match.
    /// </summary>
    [PhpProperty("mastery_exp_match")]
    public int MasteryExpMatch { get; set; }

    /// <summary>
    ///     Bonus mastery experience earned.
    /// </summary>
    [PhpProperty("mastery_exp_bonus")]
    public int MasteryExpBonus { get; set; }

    /// <summary>
    ///     Experience from boosts.
    /// </summary>
    [PhpProperty("mastery_exp_boost")]
    public int MasteryExpBoost { get; set; }

    /// <summary>
    ///     Experience from super boosts.
    /// </summary>
    [PhpProperty("mastery_exp_super_boost")]
    public int MasteryExpSuperBoost { get; set; }

    /// <summary>
    ///     Experience related to hero count.
    /// </summary>
    [PhpProperty("mastery_exp_heroes_count")]
    public int MasteryExpHeroesCount { get; set; }

    /// <summary>
    ///     Add-on experience for heroes.
    /// </summary>
    [PhpProperty("mastery_exp_heroes_addon")]
    public int MasteryExpHeroesAddon { get; set; }

    /// <summary>
    ///     Experience applied to boost?
    /// </summary>
    [PhpProperty("mastery_exp_to_boost")]
    public int MasteryExpToBoost { get; set; }

    /// <summary>
    ///     Event-specific mastery experience.
    /// </summary>
    [PhpProperty("mastery_exp_event")]
    public int MasteryExpEvent { get; set; }

    /// <summary>
    ///     Can mastery be boosted?
    /// </summary>
    [PhpProperty("mastery_canboost")]
    public bool MasteryCanBoost { get; set; }

    /// <summary>
    ///     Can mastery be super boosted?
    /// </summary>
    [PhpProperty("mastery_super_canboost")]
    public bool MasterySuperCanBoost { get; set; }

    /// <summary>
    ///     Product ID for the mastery boost.
    /// </summary>
    [PhpProperty("mastery_boost_product_id")]
    public int MasteryBoostProductID { get; set; }

    /// <summary>
    ///     Product ID for the super mastery boost.
    /// </summary>
    [PhpProperty("mastery_super_boost_product_id")]
    public int MasterySuperBoostProductID { get; set; }

    /// <summary>
    ///     Number of mastery boosts applied.
    /// </summary>
    [PhpProperty("mastery_boostnum")]
    public int MasteryBoostNum { get; set; }

    /// <summary>
    ///     Number of super mastery boosts applied.
    /// </summary>
    [PhpProperty("mastery_super_boostnum")]
    public int MasterySuperBoostNum { get; set; }
}

public class SeasonSystem
{
    /// <summary>
    ///     Diamonds dropped/earned?
    /// </summary>
    [PhpProperty("drop_diamonds")]
    public int DropDiamonds { get; set; }

    /// <summary>
    ///     Current diamond balance.
    /// </summary>
    [PhpProperty("cur_diamonds")]
    public int CurDiamonds { get; set; }

    /// <summary>
    ///     Pricing for boxes/chests?
    /// </summary>
    [PhpProperty("box_price")]
    public required object[] BoxPrice { get; set; }
}

public class MatchSummary
{
    /// <summary>
    ///     The unique identifier for the match.
    /// </summary>
    [PhpProperty("match_id")]
    public required int MatchID { get; set; }

    /// <summary>
    ///     The server ID where the match was hosted.
    /// </summary>
    [PhpProperty("server_id")]
    public required int ServerID { get; set; }

    /// <summary>
    ///     The map on which the match was played (e.g. "caldavar", "midwars", "grimms_crossing").
    /// </summary>
    [PhpProperty("map")]
    public required string Map { get; set; }

    /// <summary>
    ///     The version of the map used in the match.
    /// </summary>
    [PhpProperty("map_version")]
    public required string MapVersion { get; set; }

    /// <summary>
    ///     The duration of the match in seconds.
    /// </summary>
    [PhpProperty("time_played")]
    public required int TimePlayed { get; set; }

    /// <summary>
    ///     The host where the match replay file is stored.
    /// </summary>
    [PhpProperty("file_host")]
    public string? FileHost { get; set; }

    /// <summary>
    ///     The size of the match replay file in bytes.
    /// </summary>
    [PhpProperty("file_size")]
    public int? FileSize { get; set; }

    /// <summary>
    ///     The filename of the match replay file.
    /// </summary>
    [PhpProperty("file_name")]
    public string? FileName { get; set; }

    /// <summary>
    ///     The connection state or match state code.
    /// </summary>
    [PhpProperty("c_state")]
    public int? ConnectionState { get; set; }

    /// <summary>
    ///     The game client version used for the match.
    /// </summary>
    [PhpProperty("version")]
    public required string Version { get; set; }

    /// <summary>
    ///     The average Player Skill Rating (PSR) of all players in the match.
    /// </summary>
    [PhpProperty("avgpsr")]
    public required int AveragePSR { get; set; }

    /// <summary>
    ///     The match date, originally formatted as "M/D/YYYY" (e.g. "3/15/2024").
    /// </summary>
    [PhpProperty("date")]
    public required string Date { get; set; }

    /// <summary>
    ///     The match time, originally formatted in 12-hour format with AM/PM (e.g. "2:30:45 PM").
    /// </summary>
    [PhpProperty("time")]
    public required string Time { get; set; }

    /// <summary>
    ///     The match name or custom server name.
    /// </summary>
    [PhpProperty("mname")]
    public string? MatchName { get; set; }

    /// <summary>
    ///     The match class/type (e.g. public match, tournament match, custom match).
    ///     <code>
    ///         0 -> Public Match
    ///         1 -> Tournament Match
    ///         2 -> Custom Match
    ///         3 -> Campaign Match
    ///     </code>
    /// </summary>
    [PhpProperty("class")]
    public required int Class { get; set; }

    /// <summary>
    ///     Whether the match was private (1) or public (0).
    /// </summary>
    [PhpProperty("private")]
    public required int Private { get; set; }

    /// <summary>
    ///     Normal Mode flag (1 = enabled, 0 = disabled).
    /// </summary>
    [PhpProperty("nm")]
    public required int NormalMode { get; set; }

    /// <summary>
    ///     Single Draft Mode flag (1 = enabled, 0 = disabled).
    /// </summary>
    [PhpProperty("sd")]
    public required int SingleDraft { get; set; }

    /// <summary>
    ///     Random Draft Mode flag (1 = enabled, 0 = disabled).
    /// </summary>
    [PhpProperty("rd")]
    public required int RandomDraft { get; set; }

    /// <summary>
    ///     Death Match Mode flag (1 = enabled, 0 = disabled).
    /// </summary>
    [PhpProperty("dm")]
    public required int DeathMatch { get; set; }

    /// <summary>
    ///     Banning Draft Mode flag (1 = enabled, 0 = disabled).
    /// </summary>
    [PhpProperty("bd")]
    public required int BanningDraft { get; set; }

    /// <summary>
    ///     Banning Pick Mode flag (1 = enabled, 0 = disabled).
    /// </summary>
    [PhpProperty("bp")]
    public required int BanningPick { get; set; }

    /// <summary>
    ///     All Random Mode flag (1 = enabled, 0 = disabled).
    /// </summary>
    [PhpProperty("ar")]
    public required int AllRandom { get; set; }

    /// <summary>
    ///     Captains Draft Mode flag (1 = enabled, 0 = disabled).
    /// </summary>
    [PhpProperty("cd")]
    public required int CaptainsDraft { get; set; }

    /// <summary>
    ///     Captains Mode flag (1 = enabled, 0 = disabled).
    /// </summary>
    [PhpProperty("cm")]
    public required int CaptainsMode { get; set; }

    /// <summary>
    ///     Lock Pick Mode flag (1 = enabled, 0 = disabled).
    /// </summary>
    [PhpProperty("lp")]
    public required int LockPick { get; set; }

    /// <summary>
    ///     Blind Ban Mode flag (1 = enabled, 0 = disabled).
    /// </summary>
    [PhpProperty("bb")]
    public required int BlindBan { get; set; }

    /// <summary>
    ///     Balanced Mode flag (1 = enabled, 0 = disabled).
    /// </summary>
    [PhpProperty("bm")]
    public required int BalancedMode { get; set; }

    /// <summary>
    ///     Kros Mode or special game mode indicator.
    ///     <code>
    ///         0 -> Standard match
    ///         1 -> Reserved
    ///         2 -> Solo Diff Mode (1v1)
    ///         3 -> Solo Same Mode (1v1)
    ///         4 -> Hero Ban Mode
    ///         5 -> MidWars Beta Mode
    ///     </code>
    /// </summary>
    [PhpProperty("km")]
    public required int KrosMode { get; set; }

    /// <summary>
    ///     Whether the match was a league/ranked match (1) or casual (0).
    /// </summary>
    [PhpProperty("league")]
    public required int League { get; set; }

    /// <summary>
    ///     The maximum number of players allowed in the match (typically 2, 4, 6, 8, or 10).
    /// </summary>
    [PhpProperty("max_players")]
    public required int MaxPlayers { get; set; }

    /// <summary>
    ///     Deprecated skill-based server filter that was used for matchmaking.
    ///     <code>
    ///         0 -> Noobs Only
    ///         1 -> Noobs Allowed
    ///         2 -> Pro
    ///     </code>
    ///     This feature is no longer active and the field has no functional purpose.
    /// </summary>
    [PhpProperty("tier")]
    public required int Tier { get; set; }

    /// <summary>
    ///     No Repick option flag (1 = repicking disabled, 0 = repicking allowed).
    /// </summary>
    [PhpProperty("no_repick")]
    public required int NoRepick { get; set; }

    /// <summary>
    ///     No Agility Heroes option flag (1 = agility heroes banned, 0 = allowed).
    /// </summary>
    [PhpProperty("no_agi")]
    public required int NoAgility { get; set; }

    /// <summary>
    ///     Drop Items On Death option flag (1 = enabled, 0 = disabled).
    /// </summary>
    [PhpProperty("drp_itm")]
    public required int DropItems { get; set; }

    /// <summary>
    ///     No Respawn Timer option flag (1 = picking timer disabled, 0 = timer enabled).
    /// </summary>
    [PhpProperty("no_timer")]
    public required int NoRespawnTimer { get; set; }

    /// <summary>
    ///     Reverse Hero Selection option flag (1 = enabled, 0 = disabled).
    /// </summary>
    [PhpProperty("rev_hs")]
    public required int ReverseHeroSelection { get; set; }

    /// <summary>
    ///     No Swap option flag (1 = hero swapping disabled, 0 = swapping allowed).
    /// </summary>
    [PhpProperty("no_swap")]
    public required int NoSwap { get; set; }

    /// <summary>
    ///     No Intelligence Heroes option flag (1 = intelligence heroes banned, 0 = allowed).
    /// </summary>
    [PhpProperty("no_int")]
    public required int NoIntelligence { get; set; }

    /// <summary>
    ///     Alternate Picking option flag (1 = enabled, 0 = disabled).
    /// </summary>
    [PhpProperty("alt_pick")]
    public required int AlternatePicking { get; set; }

    /// <summary>
    ///     Ban Phase option flag (1 = ban phase enabled, 0 = disabled).
    /// </summary>
    [PhpProperty("veto")]
    public required int BanPhase { get; set; }

    /// <summary>
    ///     Shuffle Abilities option flag (1 = abilities shuffled/randomised, 0 = normal abilities).
    ///     Used in Rift Wars and other Kros Mode variants.
    /// </summary>
    [PhpProperty("shuf")]
    public required int ShuffleAbilities { get; set; }

    /// <summary>
    ///     No Strength Heroes option flag (1 = strength heroes banned, 0 = allowed).
    /// </summary>
    [PhpProperty("no_str")]
    public required int NoStrength { get; set; }

    /// <summary>
    ///     No Power-Ups option flag (1 = power-ups/runes disabled, 0 = enabled).
    /// </summary>
    [PhpProperty("no_pups")]
    public required int NoPowerUps { get; set; }

    /// <summary>
    ///     Duplicate Heroes option flag (1 = duplicate heroes allowed, 0 = each hero unique).
    /// </summary>
    [PhpProperty("dup_h")]
    public required int DuplicateHeroes { get; set; }

    /// <summary>
    ///     All Pick Mode option flag (1 = enabled, 0 = disabled).
    /// </summary>
    [PhpProperty("ap")]
    public required int AllPick { get; set; }

    /// <summary>
    ///     Balanced Random Mode option flag (1 = enabled, 0 = disabled).
    /// </summary>
    [PhpProperty("br")]
    public required int BalancedRandom { get; set; }

    /// <summary>
    ///     Easy Mode option flag (1 = easy mode enabled, 0 = normal difficulty).
    /// </summary>
    [PhpProperty("em")]
    public required int EasyMode { get; set; }

    /// <summary>
    ///     Casual Mode option flag (1 = casual mode enabled, 0 = normal mode).
    /// </summary>
    [PhpProperty("cas")]
    public required int CasualMode { get; set; }

    /// <summary>
    ///     Reverse Selection option flag (1 = enabled, 0 = disabled).
    /// </summary>
    [PhpProperty("rs")]
    public required int ReverseSelection { get; set; }

    /// <summary>
    ///     No Leaver option flag (1 = no leaver penalty applied, 0 = leaver penalties enabled).
    /// </summary>
    [PhpProperty("nl")]
    public required int NoLeaver { get; set; }

    /// <summary>
    ///     Official Match flag (1 = official tournament match, 0 = unofficial).
    /// </summary>
    [PhpProperty("officl")]
    public required int Official { get; set; }

    /// <summary>
    ///     No Statistics option flag (1 = match stats not recorded, 0 = stats recorded).
    /// </summary>
    [PhpProperty("no_stats")]
    public required int NoStatistics { get; set; }

    /// <summary>
    ///     Auto Balance option flag (1 = teams automatically balanced, 0 = manual teams).
    /// </summary>
    [PhpProperty("ab")]
    public required int AutoBalance { get; set; }

    /// <summary>
    ///     Hardcore Mode option flag (1 = hardcore difficulty enabled, 0 = normal).
    /// </summary>
    [PhpProperty("hardcore")]
    public required int Hardcore { get; set; }

    /// <summary>
    ///     Development Heroes option flag (1 = development/unreleased heroes allowed, 0 = only released heroes).
    /// </summary>
    [PhpProperty("dev_heroes")]
    public required int DevelopmentHeroes { get; set; }

    /// <summary>
    ///     Verified Only option flag (1 = only verified accounts allowed, 0 = all accounts allowed).
    /// </summary>
    [PhpProperty("verified_only")]
    public required int VerifiedOnly { get; set; }

    /// <summary>
    ///     Gated option flag (1 = gated/restricted match, 0 = open match).
    /// </summary>
    [PhpProperty("gated")]
    public required int Gated { get; set; }

    /// <summary>
    ///     Rapid Fire Mode option flag (1 = rapid fire mode enabled, 0 = normal ability cooldowns).
    /// </summary>
    [PhpProperty("rapidfire")]
    public int RapidFire { get; set; }

    /// <summary>
    ///     The UNIX timestamp (in seconds) when the match started.
    /// </summary>
    [PhpProperty("timestamp")]
    public required int Timestamp { get; set; }

    /// <summary>
    ///     The URL for the match replay file.
    /// </summary>
    [PhpProperty("url")]
    public required string URL { get; set; }

    /// <summary>
    ///     The size of the match replay file (human-readable format or bytes as string).
    /// </summary>
    [PhpProperty("size")]
    public required string Size { get; set; }

    /// <summary>
    ///     The name or title of the replay file.
    /// </summary>
    [PhpProperty("name")]
    public required string Name { get; set; }

    /// <summary>
    ///     The directory path where the replay file is stored.
    /// </summary>
    [PhpProperty("dir")]
    public required string Directory { get; set; }

    /// <summary>
    ///     The S3 download URL for the match replay file.
    /// </summary>
    [PhpProperty("s3_url")]
    public required string S3URL { get; set; }

    /// <summary>
    ///     The winning team ("1" for Legion, "2" for Hellbourne).
    ///     Determined by analysing player statistics from the match.
    /// </summary>
    [PhpProperty("winning_team")]
    public required string WinningTeam { get; set; }

    /// <summary>
    ///     The game mode code derived from match options.
    ///     <code>
    ///         "ap"  -> All Pick (Normal Mode)
    ///         "sd"  -> Single Draft
    ///         "rd"  -> Random Draft
    ///         "bd"  -> Banning Draft
    ///         "bp"  -> Banning Pick
    ///         "cd"  -> Captains Draft
    ///         "cm"  -> Captains Mode
    ///         "br"  -> Balanced Random
    ///         "cp"  -> Campaign Mode
    ///         "sm"  -> Solo Diff Mode (1v1)
    ///         "ss"  -> Solo Same Mode (1v1)
    ///         "hb"  -> Hero Ban Mode
    ///         "mwb" -> MidWars Beta Mode
    ///     </code>
    /// </summary>
    [PhpProperty("gamemode")]
    public required string GameMode { get; set; }

    /// <summary>
    ///     The account ID of the Most Valuable Player (MVP) in the match.
    /// </summary>
    [PhpProperty("mvp")]
    public required string MVP { get; set; }

    /// <summary>
    ///     The account ID of the player who earned the "Most Annihilations" award.
    /// </summary>
    [PhpProperty("awd_mann")]
    public required string AwardMostAnnihilations { get; set; }

    /// <summary>
    ///     The account ID of the player who earned the "Most Quad Kills" award.
    /// </summary>
    [PhpProperty("awd_mqk")]
    public required string AwardMostQuadKills { get; set; }

    /// <summary>
    ///     The account ID of the player who earned the "Longest Killing Spree" award.
    /// </summary>
    [PhpProperty("awd_lgks")]
    public required string AwardLongestKillingSpree { get; set; }

    /// <summary>
    ///     The account ID of the player who earned the "Most Smackdowns" award.
    /// </summary>
    [PhpProperty("awd_msd")]
    public required string AwardMostSmackdowns { get; set; }

    /// <summary>
    ///     The account ID of the player who earned the "Most Kills" award.
    /// </summary>
    [PhpProperty("awd_mkill")]
    public required string AwardMostKills { get; set; }

    /// <summary>
    ///     The account ID of the player who earned the "Most Assists" award.
    /// </summary>
    [PhpProperty("awd_masst")]
    public required string AwardMostAssists { get; set; }

    /// <summary>
    ///     The account ID of the player who earned the "Least Deaths" award.
    /// </summary>
    [PhpProperty("awd_ledth")]
    public required string AwardLeastDeaths { get; set; }

    /// <summary>
    ///     The account ID of the player who earned the "Most Building Damage" award.
    /// </summary>
    [PhpProperty("awd_mbdmg")]
    public required string AwardMostBuildingDamage { get; set; }

    /// <summary>
    ///     The account ID of the player who earned the "Most Wards" award.
    /// </summary>
    [PhpProperty("awd_mwk")]
    public required string AwardMostWards { get; set; }

    /// <summary>
    ///     The account ID of the player who earned the "Most Hero Damage Dealt" award.
    /// </summary>
    [PhpProperty("awd_mhdd")]
    public required string AwardMostHeroDamageDealt { get; set; }

    /// <summary>
    ///     The account ID of the player who earned the "Highest Creep Score" award.
    /// </summary>
    [PhpProperty("awd_hcs")]
    public required string AwardHighestCreepScore { get; set; }
}

public class MatchMastery(string heroIdentifier, int currentMasteryExperience, int matchMasteryExperience, int bonusExperience)
{
    // TODO: Set Missing Properties Once Database Entities Are Available

    //public class MatchMastery(MasteryRewards rewards)
    //{
    //    MasteryExperienceBoostProductCount = rewards.MasteryBoostsOwned;
    //    MasteryExperienceSuperBoostProductCount = rewards.MasterySuperBoostsOwned;
    //    MasteryExperienceHeroesCount = rewards.MasteryMaxLevelHeroesCount;
    //}

    /// <summary>
    ///     The identifier of the hero, in the format Hero_{Snake_Case_Name}.
    /// </summary>
    [PhpProperty("cli_name")]
    public required string HeroIdentifier { get; init; } = heroIdentifier;

    /// <summary>
    ///     The hero's original mastery experience before the match.
    ///     This is the current mastery level progress persisted to the database.
    /// </summary>
    [PhpProperty("mastery_exp_original")]
    public required int CurrentMasteryExperience { get; init; } = currentMasteryExperience;

    /// <summary>
    ///     The base mastery experience earned during the match.
    ///     Calculated from match duration, map, match type, and win/loss status.
    ///     Does not include bonuses or boosts.
    /// </summary>
    [PhpProperty("mastery_exp_match")]
    public required int MatchMasteryExperience { get; init; } = matchMasteryExperience;

    /// <summary>
    ///     Additional mastery experience bonus from map-specific multipliers.
    ///     Applied as a percentage multiplier to the base experience.
    /// </summary>
    [PhpProperty("mastery_exp_bonus")]
    public required int MasteryExperienceBonus { get; init; } = 0;

    /// <summary>
    ///     The additional mastery experience gained from applying a regular mastery boost consumable.
    ///     Set to zero initially when match results are calculated.
    ///     Only populated with a non-zero value after the player applies a mastery boost product.
    /// </summary>
    [PhpProperty("mastery_exp_boost")]
    public required int MasteryExperienceBoost { get; init; } = 0;

    /// <summary>
    ///     The additional mastery experience gained from applying a super mastery boost consumable.
    ///     Set to zero initially when match results are calculated.
    ///     Only populated with a non-zero value after the player applies a super mastery boost product.
    /// </summary>
    [PhpProperty("mastery_exp_super_boost")]
    public required int MasteryExperienceSuperBoost { get; init; } = 0;

    /// <summary>
    ///     The number of heroes the account has reached maximum mastery level with.
    ///     Used to calculate the "max_heroes_addon" bonus multiplier.
    /// </summary>
    [PhpProperty("mastery_exp_heroes_count")]
    public required int MasteryExperienceMaximumLevelHeroesCount { get; init; }

    /// <summary>
    ///     Bonus mastery experience awarded based on the number of max-level heroes owned.
    ///     Maps to "mastery_maxlevel_addon" in "match_stats_v2.lua".
    /// </summary>
    [PhpProperty("mastery_exp_heroes_addon")]
    public required int MasteryExperienceHeroesBonus { get; init; } = bonusExperience;

    /// <summary>
    ///     The potential experience that can be gained by using a regular mastery boost.
    ///     Displayed when hovering over the mastery boost button in the UI.
    /// </summary>
    [PhpProperty("mastery_exp_to_boost")]
    public required int MasteryExperienceToBoost { get; init; } = (matchMasteryExperience + bonusExperience) * 2;

    /// <summary>
    ///     Special event bonus mastery experience granted during promotional periods.
    ///     Typically zero unless an admin-configured mastery experience event is active.
    /// </summary>
    [PhpProperty("mastery_exp_event")]
    public required int MasteryExperienceEventBonus { get; init; } = 0;

    /// <summary>
    ///     Setting this value to FALSE disables using or purchasing regular mastery boosts.
    ///     Some use cases for FALSE would be: 1) the hero has reached the maximum mastery level, 2) a mastery experience boost has already been used, 3) the map/mode combination is not eligible for accumulating mastery experience.
    /// </summary>
    [PhpProperty("mastery_canboost")]
    public required bool MasteryExperienceCanBoost { get; set; } = true;

    /// <summary>
    ///     Setting this value to FALSE disables using or purchasing super mastery boosts.
    ///     Some use cases for FALSE would be: 1) the hero has reached the maximum mastery level, 2) a mastery experience boost has already been used, 3) the map/mode combination is not eligible for accumulating mastery experience.
    /// </summary>
    [PhpProperty("mastery_super_canboost")]
    public required bool MasteryExperienceCanSuperBoost { get; set; } = true;

    /// <summary>
    ///     The product ID for regular mastery boost purchases (typically 3609 for "m.Mastery Boost").
    ///     Used when the player clicks to purchase a mastery boost from the match rewards screen.
    /// </summary>
    [PhpProperty("mastery_boost_product_id")]
    public required int MasteryExperienceBoostProductIdentifier { get; init; } = 3609; // m.Mastery Boost

    /// <summary>
    ///     The product ID for super mastery boost purchases (typically 4605 for "m.Super boost").
    ///     Referenced but not directly purchasable from the standard match rewards UI.
    /// </summary>
    [PhpProperty("mastery_super_boost_product_id")]
    public required int MasteryExperienceSuperBoostProductIdentifier { get; init; } = 4605; // m.Super boost

    /// <summary>
    ///     The number of regular mastery boost products the player currently owns.
    ///     Retrieved from the account's owned upgrades/products list.
    /// </summary>
    [PhpProperty("mastery_boostnum")]
    public required int MasteryExperienceBoostProductCount { get; init; }

    /// <summary>
    ///     The number of super mastery boost products the player currently owns.
    ///     Retrieved from the account's owned upgrades/products list.
    /// </summary>
    [PhpProperty("mastery_super_boostnum")]
    public required int MasteryExperienceSuperBoostProductCount { get; init; }
}

public class PlayerStatistics
{
    /// <summary>
    ///     The unique identifier for the match.
    /// </summary>
    [PhpProperty("match_id")]
    public required int MatchID { get; set; }

    /// <summary>
    ///     The player's account ID.
    /// </summary>
    [PhpProperty("account_id")]
    public required int AccountID { get; set; }

    /// <summary>
    ///     The account name (nickname) of the player.
    /// </summary>
    [PhpProperty("nickname")]
    public required string AccountName { get; set; }

    /// <summary>
    ///     The clan ID of the player's clan, or "0" if the player is not in a clan.
    /// </summary>
    [PhpProperty("clan_id")]
    public required string ClanID { get; set; }

    /// <summary>
    ///     The unique identifier of the hero played in the match.
    /// </summary>
    [PhpProperty("hero_id")]
    public required string HeroID { get; set; }

    /// <summary>
    ///     The lobby position of the player (0-9), indicating their slot in the pre-match lobby.
    /// </summary>
    [PhpProperty("position")]
    public required string Position { get; set; }

    /// <summary>
    ///     The team the player was on ("1" for Legion, "2" for Hellbourne).
    /// </summary>
    [PhpProperty("team")]
    public required string Team { get; set; }

    /// <summary>
    ///     The final hero level reached by the player in the match (1-25).
    /// </summary>
    [PhpProperty("level")]
    public required string Level { get; set; }

    /// <summary>
    ///     The number of wins on the player's account before this match.
    /// </summary>
    [PhpProperty("wins")]
    public required string Wins { get; set; }

    /// <summary>
    ///     The number of losses on the player's account before this match.
    /// </summary>
    [PhpProperty("losses")]
    public required string Losses { get; set; }

    /// <summary>
    ///     The number of conceded matches on the player's account before this match.
    /// </summary>
    [PhpProperty("concedes")]
    public required string Concedes { get; set; }

    /// <summary>
    ///     The number of concede votes the player cast during the match.
    /// </summary>
    [PhpProperty("concedevotes")]
    public required string ConcedeVotes { get; set; }

    /// <summary>
    ///     The number of times the player bought back into the match after dying.
    /// </summary>
    [PhpProperty("buybacks")]
    public required string Buybacks { get; set; }

    /// <summary>
    ///     The number of disconnections on the player's account before this match.
    /// </summary>
    [PhpProperty("discos")]
    public required string Disconnections { get; set; }

    /// <summary>
    ///     The number of times the player was kicked from matches on their account before this match.
    /// </summary>
    [PhpProperty("kicked")]
    public required string Kicked { get; set; }

    /// <summary>
    ///     The player's Public Skill Rating (PSR) before this match.
    /// </summary>
    [PhpProperty("pub_skill")]
    public required string PublicSkill { get; set; }

    /// <summary>
    ///     The number of public matches played on the player's account before this match.
    /// </summary>
    [PhpProperty("pub_count")]
    public required string PublicCount { get; set; }

    /// <summary>
    ///     The player's Automatic Matchmaking (AMM) solo rating before this match.
    /// </summary>
    [PhpProperty("amm_solo_rating")]
    public required string AMMSoloRating { get; set; }

    /// <summary>
    ///     The number of AMM solo matches played on the player's account before this match.
    /// </summary>
    [PhpProperty("amm_solo_count")]
    public required string AMMSoloCount { get; set; }

    /// <summary>
    ///     The player's Automatic Matchmaking (AMM) team rating before this match.
    /// </summary>
    [PhpProperty("amm_team_rating")]
    public required string AMMTeamRating { get; set; }

    /// <summary>
    ///     The number of AMM team matches played on the player's account before this match.
    /// </summary>
    [PhpProperty("amm_team_count")]
    public required string AMMTeamCount { get; set; }

    /// <summary>
    ///     The player's average score across all matches before this match.
    /// </summary>
    [PhpProperty("avg_score")]
    public required string AverageScore { get; set; }

    /// <summary>
    ///     The number of enemy hero kills achieved by the player in the match.
    /// </summary>
    [PhpProperty("herokills")]
    public required string HeroKills { get; set; }

    /// <summary>
    ///     The total damage dealt to enemy heroes by the player in the match.
    /// </summary>
    [PhpProperty("herodmg")]
    public required string HeroDamage { get; set; }

    /// <summary>
    ///     The total experience gained from killing or assisting in killing enemy heroes.
    /// </summary>
    [PhpProperty("heroexp")]
    public required string HeroExperience { get; set; }

    /// <summary>
    ///     The total gold earned from killing or assisting in killing enemy heroes.
    /// </summary>
    [PhpProperty("herokillsgold")]
    public required string HeroKillsGold { get; set; }

    /// <summary>
    ///     The number of assists (participating in hero kills without landing the final blow) achieved by the player.
    /// </summary>
    [PhpProperty("heroassists")]
    public required string HeroAssists { get; set; }

    /// <summary>
    ///     The number of times the player died in the match.
    /// </summary>
    [PhpProperty("deaths")]
    public required string Deaths { get; set; }

    /// <summary>
    ///     The total gold lost by the player due to deaths in the match.
    /// </summary>
    [PhpProperty("goldlost2death")]
    public required string GoldLostToDeath { get; set; }

    /// <summary>
    ///     The total time in seconds the player spent dead (waiting to respawn) during the match.
    /// </summary>
    [PhpProperty("secs_dead")]
    public required string SecondsDead { get; set; }

    /// <summary>
    ///     The number of friendly team creeps killed by the player (last-hitting own creeps for gold/experience).
    /// </summary>
    [PhpProperty("teamcreepkills")]
    public required string TeamCreepKills { get; set; }

    /// <summary>
    ///     The total damage dealt to friendly team creeps by the player.
    /// </summary>
    [PhpProperty("teamcreepdmg")]
    public required string TeamCreepDamage { get; set; }

    /// <summary>
    ///     The total experience gained from killing friendly team creeps.
    /// </summary>
    [PhpProperty("teamcreepexp")]
    public required string TeamCreepExperience { get; set; }

    /// <summary>
    ///     The total gold earned from killing friendly team creeps.
    /// </summary>
    [PhpProperty("teamcreepgold")]
    public required string TeamCreepGold { get; set; }

    /// <summary>
    ///     The number of neutral creeps killed by the player (jungle creeps).
    /// </summary>
    [PhpProperty("neutralcreepkills")]
    public required string NeutralCreepKills { get; set; }

    /// <summary>
    ///     The total damage dealt to neutral creeps by the player.
    /// </summary>
    [PhpProperty("neutralcreepdmg")]
    public required string NeutralCreepDamage { get; set; }

    /// <summary>
    ///     The total experience gained from killing neutral creeps.
    /// </summary>
    [PhpProperty("neutralcreepexp")]
    public required string NeutralCreepExperience { get; set; }

    /// <summary>
    ///     The total gold earned from killing neutral creeps.
    /// </summary>
    [PhpProperty("neutralcreepgold")]
    public required string NeutralCreepGold { get; set; }

    /// <summary>
    ///     The total damage dealt to enemy buildings (towers, barracks, base structures) by the player.
    /// </summary>
    [PhpProperty("bdmg")]
    public required string BuildingDamage { get; set; }

    /// <summary>
    ///     The total experience gained from damaging or destroying enemy buildings.
    /// </summary>
    [PhpProperty("bdmgexp")]
    public required string BuildingExperience { get; set; }

    /// <summary>
    ///     The number of enemy buildings (towers, barracks) destroyed by the player.
    /// </summary>
    [PhpProperty("razed")]
    public required string BuildingsRazed { get; set; }

    /// <summary>
    ///     The total gold earned from damaging or destroying enemy buildings.
    /// </summary>
    [PhpProperty("bgold")]
    public required string BuildingGold { get; set; }

    /// <summary>
    ///     The number of enemy creeps denied by the player (last-hitting enemy creeps to prevent opponents from gaining gold/experience).
    /// </summary>
    [PhpProperty("denies")]
    public required string Denies { get; set; }

    /// <summary>
    ///     The total experience denied to opponents through denying enemy creeps.
    /// </summary>
    [PhpProperty("exp_denied")]
    public required string ExperienceDenied { get; set; }

    /// <summary>
    ///     The total gold accumulated by the player at the end of the match.
    /// </summary>
    [PhpProperty("gold")]
    public required string Gold { get; set; }

    /// <summary>
    ///     The total gold spent by the player on items during the match.
    /// </summary>
    [PhpProperty("gold_spent")]
    public required string GoldSpent { get; set; }

    /// <summary>
    ///     The total experience gained by the player during the match.
    /// </summary>
    [PhpProperty("exp")]
    public required string Experience { get; set; }

    /// <summary>
    ///     The total number of actions performed by the player during the match (clicks, commands, ability usage, etc.).
    /// </summary>
    [PhpProperty("actions")]
    public required string Actions { get; set; }

    /// <summary>
    ///     The total time in seconds the player was actively playing in the match.
    /// </summary>
    [PhpProperty("secs")]
    public required string Seconds { get; set; }

    /// <summary>
    ///     The number of consumable items (potions, wards, teleport scrolls, etc.) purchased by the player.
    /// </summary>
    [PhpProperty("consumables")]
    public required string Consumables { get; set; }

    /// <summary>
    ///     The number of observer or sentry wards placed by the player during the match.
    /// </summary>
    [PhpProperty("wards")]
    public required string Wards { get; set; }

    /// <summary>
    ///     The total time in seconds the player spent within experience range of dying enemy units.
    /// </summary>
    [PhpProperty("time_earning_exp")]
    public required string TimeEarningExperience { get; set; }

    /// <summary>
    ///     The number of First Blood awards earned by the player (1 or 0).
    /// </summary>
    [PhpProperty("bloodlust")]
    public required string FirstBlood { get; set; }

    /// <summary>
    ///     The number of Double Kill awards earned by the player (killing 2 heroes in quick succession).
    /// </summary>
    [PhpProperty("doublekill")]
    public required string DoubleKill { get; set; }

    /// <summary>
    ///     The number of Triple Kill awards earned by the player (killing 3 heroes in quick succession).
    /// </summary>
    [PhpProperty("triplekill")]
    public required string TripleKill { get; set; }

    /// <summary>
    ///     The number of Quad Kill awards earned by the player (killing 4 heroes in quick succession).
    /// </summary>
    [PhpProperty("quadkill")]
    public required string QuadKill { get; set; }

    /// <summary>
    ///     The number of Annihilation awards earned by the player (killing all 5 enemy heroes in quick succession).
    /// </summary>
    [PhpProperty("annihilation")]
    public required string Annihilation { get; set; }

    /// <summary>
    ///     The number of 3-kill streaks achieved by the player (killing 3 heroes without dying).
    /// </summary>
    [PhpProperty("ks3")]
    public required string KillStreak3 { get; set; }

    /// <summary>
    ///     The number of 4-kill streaks achieved by the player (killing 4 heroes without dying).
    /// </summary>
    [PhpProperty("ks4")]
    public required string KillStreak4 { get; set; }

    /// <summary>
    ///     The number of 5-kill streaks achieved by the player (killing 5 heroes without dying).
    /// </summary>
    [PhpProperty("ks5")]
    public required string KillStreak5 { get; set; }

    /// <summary>
    ///     The number of 6-kill streaks achieved by the player (killing 6 heroes without dying).
    /// </summary>
    [PhpProperty("ks6")]
    public required string KillStreak6 { get; set; }

    /// <summary>
    ///     The number of 7-kill streaks achieved by the player (killing 7 heroes without dying).
    /// </summary>
    [PhpProperty("ks7")]
    public required string KillStreak7 { get; set; }

    /// <summary>
    ///     The number of 8-kill streaks achieved by the player (killing 8 heroes without dying).
    /// </summary>
    [PhpProperty("ks8")]
    public required string KillStreak8 { get; set; }

    /// <summary>
    ///     The number of 9-kill streaks achieved by the player (killing 9 heroes without dying).
    /// </summary>
    [PhpProperty("ks9")]
    public required string KillStreak9 { get; set; }

    /// <summary>
    ///     The number of 10-kill streaks achieved by the player (killing 10 heroes without dying).
    /// </summary>
    [PhpProperty("ks10")]
    public required string KillStreak10 { get; set; }

    /// <summary>
    ///     The number of 15-kill streaks achieved by the player (killing 15 heroes without dying).
    /// </summary>
    [PhpProperty("ks15")]
    public required string KillStreak15 { get; set; }

    /// <summary>
    ///     The number of Smackdown awards earned by the player (ending an enemy's kill streak).
    /// </summary>
    [PhpProperty("smackdown")]
    public required string Smackdown { get; set; }

    /// <summary>
    ///     The number of Humiliation awards earned by the player (killing an enemy hero who is significantly higher level).
    /// </summary>
    [PhpProperty("humiliation")]
    public required string Humiliation { get; set; }

    /// <summary>
    ///     The number of Nemesis awards earned by the player (being killed repeatedly by the same enemy hero).
    /// </summary>
    [PhpProperty("nemesis")]
    public required string Nemesis { get; set; }

    /// <summary>
    ///     The number of Retribution awards earned by the player (killing an enemy hero who has killed you repeatedly).
    /// </summary>
    [PhpProperty("retribution")]
    public required string Retribution { get; set; }

    /// <summary>
    ///     Whether the player used a token (game access token or dice token) during the match ("1" if used, "0" otherwise).
    /// </summary>
    [PhpProperty("used_token")]
    public required string UsedToken { get; set; }

    /// <summary>
    ///     The hero identifier in the format Hero_{Snake_Case_Name} (e.g. "Hero_Andromeda", "Hero_Legionnaire").
    /// </summary>
    [PhpProperty("cli_name")]
    public required string HeroIdentifier { get; set; }

    /// <summary>
    ///     The clan tag of the player's clan, or empty string if the player is not in a clan.
    /// </summary>
    [PhpProperty("tag")]
    public required string ClanTag { get; set; }

    /// <summary>
    ///     The alternative avatar name used by the player during the match, or empty string if using the default hero skin.
    /// </summary>
    [PhpProperty("alt_avatar_name")]
    public required string AlternativeAvatarName { get; set; }

    /// <summary>
    ///     Seasonal campaign progression information for the player in the match.
    /// </summary>
    [PhpProperty("campaign_info")]
    public required SeasonProgress SeasonProgress { get; set; }
}

public class SeasonProgress
{
    /// <summary>
    ///     The player's account ID.
    /// </summary>
    [PhpProperty("account_id")]
    public required int AccountID { get; set; }

    /// <summary>
    ///     The unique identifier for the match.
    /// </summary>
    [PhpProperty("match_id")]
    public required int MatchID { get; set; }

    /// <summary>
    ///     Whether the match was a casual ranked match ("1") or competitive ranked match ("0").
    /// </summary>
    [PhpProperty("is_casual")]
    public required string IsCasual { get; set; }

    /// <summary>
    ///     The player's Matchmaking Rating (MMR) before the match.
    /// </summary>
    [PhpProperty("mmr_before")]
    public required string MMRBefore { get; set; }

    /// <summary>
    ///     The player's Matchmaking Rating (MMR) after the match.
    /// </summary>
    [PhpProperty("mmr_after")]
    public required string MMRAfter { get; set; }

    /// <summary>
    ///     The player's medal rank before the match.
    ///     <code>
    ///         00      -> Unranked
    ///         01-05   -> Bronze   (V, IV, III, II, I)
    ///         06-10   -> Silver   (V, IV, III, II, I)
    ///         11-15   -> Gold     (V, IV, III, II, I)
    ///         16-20   -> Diamond  (V, IV, III, II, I)
    ///         21      -> Immortal
    ///     </code>
    /// </summary>
    [PhpProperty("medal_before")]
    public required string MedalBefore { get; set; }

    /// <summary>
    ///     The player's medal rank after the match.
    ///     Uses the same medal ranking system as "medal_before".
    /// </summary>
    [PhpProperty("medal_after")]
    public required string MedalAfter { get; set; }

    /// <summary>
    ///     The seasonal campaign identifier.
    /// </summary>
    [PhpProperty("season")]
    public required string Season { get; set; }

    /// <summary>
    ///     The number of placement matches the player has completed in the current season.
    ///     Players must complete placement matches before receiving their seasonal medal rank.
    /// </summary>
    [PhpProperty("placement_matches")]
    public required int PlacementMatches { get; set; }

    /// <summary>
    ///     The number of placement matches won by the player in the current season.
    /// </summary>
    [PhpProperty("placement_wins")]
    public required string PlacementWins { get; set; }

    /// <summary>
    ///     The player's current ranking position on the Immortal leaderboard.
    ///     Only populated for Immortal rank players (medal 21) with a ranking between 1 and 100.
    ///     Not present in the response for players below Immortal rank or outside the top 100.
    /// </summary>
    [PhpProperty("ranking")]
    public string? Ranking { get; set; }
}

public class PlayerInventory
{
    /// <summary>
    ///     The player's account ID.
    /// </summary>
    [PhpProperty("account_id")]
    public required int AccountID { get; set; }

    /// <summary>
    ///     The unique identifier for the match.
    /// </summary>
    [PhpProperty("match_id")]
    public required int MatchID { get; set; }

    /// <summary>
    ///     Item in slot 1 (Top Left).
    /// </summary>
    [PhpProperty("slot_1")]
    public required string Slot1 { get; set; }

    /// <summary>
    ///     Item in slot 2 (Top Center).
    /// </summary>
    [PhpProperty("slot_2")]
    public required string Slot2 { get; set; }

    /// <summary>
    ///     Item in slot 3 (Top Right).
    /// </summary>
    [PhpProperty("slot_3")]
    public required string Slot3 { get; set; }

    /// <summary>
    ///     Item in slot 4 (Bottom Left).
    /// </summary>
    [PhpProperty("slot_4")]
    public required string Slot4 { get; set; }

    /// <summary>
    ///     Item in slot 5 (Bottom Center).
    /// </summary>
    [PhpProperty("slot_5")]
    public required string Slot5 { get; set; }

    /// <summary>
    ///     Item in slot 6 (Bottom Right).
    /// </summary>
    [PhpProperty("slot_6")]
    public required string Slot6 { get; set; }
}

public class SeasonSystem
{
    /// <summary>
    ///     Number of diamonds earned/dropped from the match.
    ///     Calculated based on drop probability.
    /// </summary>
    [PhpProperty("drop_diamonds")]
    public int DropDiamonds { get; set; } = 0;

    /// <summary>
    ///     Current total diamonds the account has accumulated this season.
    /// </summary>
    [PhpProperty("cur_diamonds")]
    public int TotalDiamonds { get; set; } = 0;

    /// <summary>
    ///     Seasonal shop loot box prices and information.
    /// </summary>
    [PhpProperty("box_price")]
    public Dictionary<int, int> BoxPrice { get; set; } = [];
}

public class CampaignReward
{
    /// <summary>
    ///     Champions Of Newerth reward level before the match.
    ///     Set to "-2" if no previous match data exists.
    /// </summary>
    [PhpProperty("old_lvl")]
    public int PreviousCampaignLevel { get; set; } = 5;

    /// <summary>
    ///     Current Champions Of Newerth reward level after the match.
    ///     Maximum level is "6".
    /// </summary>
    [PhpProperty("curr_lvl")]
    public int CurrentCampaignLevel { get; set; } = 6;

    /// <summary>
    ///     Next Champions Of Newerth reward level to unlock.
    ///     Set to "0" when maximum level ("6") has been reached.
    /// </summary>
    [PhpProperty("next_lvl")]
    public int NextLevel { get; set; } = 0;

    /// <summary>
    ///     Minimum medal rank required to unlock the next Champions Of Newerth reward level.
    ///     <code>
    ///         Level 1 -> Medal 01 (Bronze V)
    ///         Level 2 -> Medal 06 (Silver V)
    ///         Level 3 -> Medal 11 (Gold V)
    ///         Level 4 -> Medal 15 (Diamond V)
    ///         Level 5 -> Medal 18 (Diamond II)
    ///         Level 6 -> Medal 20 (Immortal)
    ///     </code>
    ///     Set to "0" if the rank requirement is already met or if maximum level has been reached.
    /// </summary>
    [PhpProperty("require_rank")]
    public int RequireRank { get; set; } = 0;

    /// <summary>
    ///     Number of additional matches needed to accumulate enough reward points to reach the next Champions Of Newerth level.
    ///     Each level requires "12" reward points, earned from winning matches.
    ///     Set to "0" when maximum level has been reached.
    /// </summary>
    [PhpProperty("need_more_play")]
    public int NeedMorePlay { get; set; } = 0;

    /// <summary>
    ///     Progress percentage towards the next Champions Of Newerth reward level before the match.
    ///     Calculated as "reward_points" divided by 12, formatted as a decimal string (e.g. "0.75" for 75%).
    /// </summary>
    [PhpProperty("percentage_before")]
    public string PercentageBefore { get; set; } = "0.92";

    /// <summary>
    ///     Progress percentage towards the next Champions Of Newerth reward level after the match.
    ///     Calculated as "reward_points" divided by 12, formatted as a decimal string (e.g. "1.00" for 100%).
    /// </summary>
    [PhpProperty("percentage")]
    public string Percentage { get; set; } = "1.00";
}
