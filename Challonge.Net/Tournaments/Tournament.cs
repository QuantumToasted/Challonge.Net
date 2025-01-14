﻿using Challonge.Json;
using Challonge.Participants;
using Challonge.Tournaments.Json;
using System;
using System.Text.Json.Serialization;

namespace Challonge.Tournaments
{
    internal class TournamentData
    {
        [JsonPropertyName("tournament")]
        public Tournament Tournament { get; set; }
    }

    public struct Tournament
    {
        /// <summary>
        /// Allow match attachment uploads
        /// </summary>
        [JsonPropertyName("accept_attachments")]
        public bool AcceptAttachments { get; set; }

        /// <summary>
        /// Whether or not verified Challonge users are allowed to report their own matches
        /// </summary>
        [JsonPropertyName("allow_participant_match_reporting")]
        public bool AllowParticipantMatchReporting { get; set; }

        /// <summary>
        /// Whether or not anonymous votes/predictions are enabled
        /// </summary>
        [JsonPropertyName("anonymous_voting")]
        public bool AnonymousVoting { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }   // I'm not sure what type this should be parsed to

        [JsonPropertyName("check_in_duration")]
        public int? CheckInDuration { get; set; }

        [JsonPropertyName("completed_at")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTimeOffset? CompletedAt { get; set; }

        [JsonPropertyName("created_at")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// Whether or not the tournament was created by an api call
        /// </summary>
        [JsonPropertyName("created_by_api")]
        public bool CreatedByApi { get; set; }

        [JsonPropertyName("credit_capped")]
        public bool CreditCapped { get; set; }

        /// <summary>
        /// Description/instructions displayed above the bracket
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The unique identifier of the game that your tournament is played on
        /// </summary>
        [JsonPropertyName("game_id")]
        public int? GameId { get; set; }

        [JsonPropertyName("group_stages_enabled")]
        public bool GroupStagesEnabled { get; set; }

        /// <summary>
        /// Hide the forum tab on your Challonge page
        /// </summary>
        [JsonPropertyName("hide_forum")]
        public bool HideForum { get; set; }

        [JsonPropertyName("hide_seeds")]
        public bool HideSeeds { get; set; }

        /// <summary>
        /// Whether or not to include a match between the semifinals losers. (only works with single elimination brackets)
        /// </summary>
        [JsonPropertyName("hold_third_place_match")]
        public bool HoldThirdPlaceMatch { get; set; }

        /// <summary>
        /// Your tournament's unique identifier
        /// </summary>
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("max_predictions_per_user")]
        public int MaxPredictionsPerUser { get; set; }

        /// <summary>
        /// Your tournament's name/title (max: 60 characters)
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Email registered Challonge participants when matches open up for them
        /// </summary>
        [JsonPropertyName("notify_users_when_matches_open")]
        public bool NotifyUsersWhenMatchesOpen { get; set; }

        /// <summary>
        /// Email registered Challonge participants the results when this tournament ends
        /// </summary>
        [JsonPropertyName("notify_users_when_the_tournament_ends")]
        public bool NotifyUsersWhenTournamentEnds { get; set; }

        /// <summary>
        /// Whether or not challonge hosts a signup page
        /// </summary>
        [JsonPropertyName("open_signup")]
        public bool OpenSignup { get; set; }

        [JsonPropertyName("participants_count")]
        public int ParticipantsCount { get; set; }

        [JsonPropertyName("prediction_method")]
        public TournamentPredictionMethod PredictionMethod { get; set; }

        [JsonPropertyName("predictions_opened_at")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTimeOffset? PredictionsOpenedAt { get; set; }

        /// <summary>
        /// Hide this tournament from the public browsable index and your profile
        /// </summary>
        [JsonPropertyName("private")]
        public bool IsPrivate { get; set; }

        [JsonPropertyName("progress_meter")]
        public int ProgressMeter { get; set; }

        [JsonPropertyName("pts_for_bye")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
        public float PointsForBye { get; set; }

        [JsonPropertyName("pts_for_game_tie")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
        public float PointsForGameTie { get; set; }

        [JsonPropertyName("pts_for_game_win")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
        public float PointsForGameWin { get; set; }

        [JsonPropertyName("pts_for_match_tie")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
        public float PointsForMatchTie { get; set; }

        [JsonPropertyName("pts_for_match_win")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
        public float PointsForMatchWin { get; set; }

        /// <summary>
        /// When set to true, you can report the winner without the scores
        /// </summary>
        [JsonPropertyName("quick_advance")]
        public bool QuickAdvance { get; set; }

        [JsonPropertyName("ranked_by")]
        public string RankedBy { get; set; }     // not sure (enum maybe)

        [JsonPropertyName("require_score_agreement")]
        public bool RequireScoreAgreement { get; set; }

        [JsonPropertyName("rr_pts_for_game_tie")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
        public float RoundRobinPointsForGameTie { get; set; }

        [JsonPropertyName("rr_pts_for_game_win")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
        public float RoundRobinPointsForGameWin { get; set; }

        [JsonPropertyName("rr_pts_for_match_tie")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
        public float RoundRobinPointsForMatchTie { get; set; }

        [JsonPropertyName("rr_pts_for_match_win")]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString)]
        public float RoundRobinPointsForMatchWin { get; set; }

        [JsonPropertyName("sequential_pairings")]
        public bool SequentialPairing { get; set; }

        /// <summary>
        /// Label each round above the bracket (only works with single and double elimination brackets)
        /// </summary>
        [JsonPropertyName("show_rounds")]
        public bool ShowRounds { get; set; }

        /// <summary>
        /// Max number of participants in your tournament
        /// </summary>
        /// <remarks>
        /// Once this number is reached, participant will be added to a waiting list. You can check if a
        /// participant is in the waiting list using <see cref="Participant.OnWaitingList"/>
        /// </remarks>
        [JsonPropertyName("signup_cap")]
        public int? SignupCap { get; set; }

        [JsonPropertyName("start_at")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTimeOffset? StartAt { get; set; }

        [JsonPropertyName("started_at")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTimeOffset? StartedAt { get; set; }

        [JsonPropertyName("started_checking_in_at")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTimeOffset? StartedCheckingInAt { get; set; }

        [JsonPropertyName("state")]
        [JsonConverter(typeof(TournamentStateJsonConverter))]
        public TournamentState State { get; set; }

        /// <summary>
        /// Number of rounds to be played. Only works for swiss type tournaments.
        /// </summary>
        [JsonPropertyName("swiss_rounds")]
        public int SwissRounds { get; set; }

        [JsonPropertyName("teams")]
        public bool? Teams { get; set; }

        [JsonPropertyName("tie_breaks")]
        public string[] TieBreaks { get; set; }  // stack or queue of enums or something like that

        [JsonPropertyName("tournament_type")]
        [JsonConverter(typeof(TournamentTypeJsonConverter))]
        public TournamentType TournamentType { get; set; }

        [JsonPropertyName("updated_at")]
        [JsonConverter(typeof(JsonDateTimeConverter))]
        public DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// Your tournament's url (challonge.com/url)
        /// letters, numbers, and undescores only
        /// </summary>
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("description_source")]
        public string DescriptionSource { get; set; }

        /// <summary>
        /// Your tournament's subdomain (subdomain.challonge.com/url)
        /// letters, numbers, and undescores only
        /// </summary>
        [JsonPropertyName("subdomain")]
        public string Subdomain { get; set; }

        [JsonPropertyName("full_challonge_url")]
        public string FullChallongeUrl { get; set; }

        [JsonPropertyName("live_image_url")]
        public string LiveImageUrl { get; set; }

        [JsonPropertyName("sign_up_url")]
        public string SignupUrl { get; set; }

        [JsonPropertyName("review_before_finalizing")]
        public bool ReviewBeforeFinalizing { get; set; }

        [JsonPropertyName("accepting_predictions")]
        public bool AcceptingPredictions { get; set; }

        [JsonPropertyName("participants_locked")]
        public bool ParticipantsLocked { get; set; }

        /// <summary>
        /// The name of the game your tournament is played on
        /// </summary>
        [JsonPropertyName("game_name")]
        public string GameName { get; set; }

        [JsonPropertyName("participants_swappable")]
        public bool ParticipantsSwappable { get; set; }

        [JsonPropertyName("team_convertable")]
        public bool TeamConvertable { get; set; }

        [JsonPropertyName("group_stages_were_started")]
        public bool GroupStageWereStarted { get; set; }
    }

    public enum TournamentType
    {
        Invalid,
        SingleElimination,
        DoubleElimination,
        RoundRobin,
        Swiss
    }

    public enum TournamentState
    {
        Invalid,
        /// <summary>
        /// The check-in process has started
        /// </summary>
        CheckingIn,
        /// <summary>
        /// The check-in process is completed
        /// </summary>
        CheckedIn,
        /// <summary>
        /// The tournament has not started yet
        /// </summary>
        Pending,
        /// <summary>
        /// The tournament has started
        /// </summary>
        Underway,
        Completed
    }

    public enum TournamentPredictionMethod
    {
        Invalid,
        Exponential = 1,
        Linear = 2
    }
}
