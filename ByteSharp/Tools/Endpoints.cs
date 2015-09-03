namespace ByteSharp.Tools
{
    public static class Endpoints
    {
        public static string Base = "https://api.byte.co/v1/";

        public static string ComputerBase = "http://computers.byte.co/";

        #region Auth

        public static string RequestCode = Base + "request-code";

        public static string Auth = Base + "auth";

        #endregion

        #region User

        public static string Status = Base + "status";

        public static string Account = Base + "account";

        public static string Deactivate = Base + "users/self/deactivate";

        public static string Reactivate = Base + "users/self/reactivate";

        #endregion

        #region Names

        public static string Names = Base + "names";

        public static string ValidateName = Base + "name/validate";

        #endregion

        #region Posts

        public static string PostById = Base + "posts/id/{0}&scheme={1}";

        public static string GroupPost = Base + "posts/id?scheme={0}";

        public static string PostByName = Base + "posts/name?scheme={0}";

        public static string PostSelf = Base + "posts/self?scheme={0}&cursor={1}";

        public static string PostLatest = Base + "posts/latest?scheme={0}&cursor={1}";

        public static string PostPopular = Base + "posts/popular?scheme={0}";

        public static string PostComment = Base + "posts/id/{0}/comments";

        public static string CreateByte = Base + "posts";

        public static string FilesSession = Base + "files/session";

        public static string UpdateDeletePost = Base + "posts/id/{0}";

        #endregion

        #region Stars

        public static string AddRemoveStar = Base + "posts/id/{0}/fav";

        public static string GetFavs = Base + "posts/favs";

        #endregion

        #region Flag

        public static string AddRemoveFlag = Base + "posts/id/{0}/flag";

        public static string GetFlags = Base + "posts/flagged";

        #endregion

        #region Activity

        public static string Messages = Base + "messages?cursor={0}";

        #endregion

        public static string Computer = ComputerBase + "computers";

        public static string UserFeed = Base + "user/feed";


        public static string Device = Base + "account/devices/{0}";

    }
}
