using System.Web;
using cenCommon;
namespace cenDTO
{
    public class UserSessionHelper
    {
        public static void SetSession(UserSession session)
        {
            System.Web.HttpContext.Current.Session["Login"] = session;
        }
        public static UserSession GetSession()
        {
            var session = HttpContext.Current.Session["Login"];
            if (cenCommon.cenCommon.IsNull(session))
                return null;
            else
                return session as UserSession;
        }
    }
}
