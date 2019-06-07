﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Shared.Models
{
    [Serializable]
    public class PlayerModel
    {
        public string ConnectionID { get; set; }
        public string Area { get; set; }
        public bool Generic { get; set; }
        public string Guild { get; set; }
        public bool IsLeader { get; set; }
        public string Account { get; set; }
        public int OverallRank { get; set; }
        public bool IsSpectator { get; set; }
        public string GenericHost { get; set; }
        public List<string> InArea { get; set; }
        public bool SessionIdProvided { get; set; }
        public CharacterModel Character { get; set; }

        public List<NetWorthSnapshot> NetWorthSnapshots { get; set; }
        public ExtenedAreaInfoModel AreaInfo { get; set; }
        public List<ExtenedAreaInfoModel> PastAreas { get; set; }

        public PlayerModel()
        {
            InArea = new List<string>();
            Character = new CharacterModel();
            NetWorthSnapshots = new List<NetWorthSnapshot>();
            AreaInfo = new ExtenedAreaInfoModel();
            PastAreas = new List<ExtenedAreaInfoModel>();

        }
    }

    public class PlayerStorageModel
    {
        [BsonId]
        public string ConnectionID { get; set; }
        public string Area { get; set; }
        public bool Generic { get; set; }
        public string Guild { get; set; }
        public bool IsLeader { get; set; }
        public string Account { get; set; }
        public int OverallRank { get; set; }
        public bool IsSpectator { get; set; }
        public string GenericHost { get; set; }
        public List<string> InArea { get; set; }
        public bool SessionIdProvided { get; set; }
        public CharacterModel Character { get; set; }
        public ExtenedAreaInfoModel AreaInfo { get; set; }

        public string NetWorthSnapshots { get; set; }
        public string PastAreas { get; set; }
    }
}
