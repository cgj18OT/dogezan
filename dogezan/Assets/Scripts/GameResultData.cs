using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace doge
{
	public struct PlayerData
	{
		public float SongenValue;
	};

	public enum EndReason
	{
		SongenIsZero,
		Killed,
	};

	static public class GameResultData
	{
		// 勝ち負け
		// Unknownのときは引き分け
		static public PlayerID Result { get; set; }

		static public EndReason Reason { get; set; }

		static public PlayerData P1;// { get; set; }
		static public PlayerData P2;// { get; set; }

		static GameResultData()
		{
			Result = PlayerID.Unknown;
		}
	}
}
