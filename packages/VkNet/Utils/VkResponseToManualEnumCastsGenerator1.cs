﻿// Autogenerated at 06.01.2016 20:17:36
// DO NOT EDIT THIS FILE CAUSE ALL CHANGES WILL BE DELETED AUTOMATICALLY
using VkNet.Enums;
namespace VkNet.Utils
{
    partial class VkResponse
    {
		public static implicit operator AddFriendStatus(VkResponse response)
		{
			if (response == null)
				return AddFriendStatus.Unknown;
			return Utilities.EnumFrom<AddFriendStatus>(response);
		}

		public static implicit operator Attitude(VkResponse response)
		{
			if (response == null)
				return Attitude.Unknown;
			return Utilities.EnumFrom<Attitude>(response);
		}

		public static implicit operator BanReason(VkResponse response)
		{
			if (response == null)
				return BanReason.Other;
			return Utilities.EnumFrom<BanReason>(response);
		}

		public static implicit operator BirthdayVisibility(VkResponse response)
		{
			if (response == null)
				return BirthdayVisibility.Invisible;
			return Utilities.EnumFrom<BirthdayVisibility>(response);
		}

		public static implicit operator DeleteFriendStatus(VkResponse response)
		{
			if (response == null)
				return DeleteFriendStatus.Unknown;
			return Utilities.EnumFrom<DeleteFriendStatus>(response);
		}

		public static implicit operator FriendStatus(VkResponse response)
		{
			if (response == null)
				return FriendStatus.NotFriend;
			return Utilities.EnumFrom<FriendStatus>(response);
		}

		public static implicit operator GiftPrivacy(VkResponse response)
		{
			if (response == null)
				return GiftPrivacy.NameHideMessageUser;
			return Utilities.EnumFrom<GiftPrivacy>(response);
		}

		public static implicit operator LeaderboardTypes(VkResponse response)
		{
			if (response == null)
				return LeaderboardTypes.NotSupported;
			return Utilities.EnumFrom<LeaderboardTypes>(response);
		}

		public static implicit operator LifeMain(VkResponse response)
		{
			if (response == null)
				return LifeMain.Unknown;
			return Utilities.EnumFrom<LifeMain>(response);
		}

		public static implicit operator MainSection(VkResponse response)
		{
			if (response == null)
				return MainSection.NoSection;
			return Utilities.EnumFrom<MainSection>(response);
		}

		public static implicit operator PeopleMain(VkResponse response)
		{
			if (response == null)
				return PeopleMain.Unknown;
			return Utilities.EnumFrom<PeopleMain>(response);
		}

		public static implicit operator PoliticalPreferences(VkResponse response)
		{
			if (response == null)
				return PoliticalPreferences.Unknown;
			return Utilities.EnumFrom<PoliticalPreferences>(response);
		}

		public static implicit operator ProductAvailability(VkResponse response)
		{
			if (response == null)
				return ProductAvailability.Unavailable;
			return Utilities.EnumFrom<ProductAvailability>(response);
		}

		public static implicit operator ProductSort(VkResponse response)
		{
			if (response == null)
				return ProductSort.UserSort;
			return Utilities.EnumFrom<ProductSort>(response);
		}

		public static implicit operator RelationType(VkResponse response)
		{
			if (response == null)
				return RelationType.Unknown;
			return Utilities.EnumFrom<RelationType>(response);
		}

		public static implicit operator ReportReason(VkResponse response)
		{
			if (response == null)
				return ReportReason.Spam;
			return Utilities.EnumFrom<ReportReason>(response);
		}

		public static implicit operator Sex(VkResponse response)
		{
			if (response == null)
				return Sex.Unknown;
			return Utilities.EnumFrom<Sex>(response);
		}


	}
}