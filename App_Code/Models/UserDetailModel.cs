using System.Linq;

namespace Models
{
    public class UserDetailModel
    {
        public UserInformation GetUserInformation(string GUID)
        {
            GarageEntities6 db = new GarageEntities6();
            var info = (from x in db.UserInformations
						where x.GUID == GUID
                        select x).FirstOrDefault();
            return info;
        }

        public void InsertUserDetail(UserInformation info)
        {
            GarageEntities6 db = new GarageEntities6();
            db.UserInformations.Add(info);
            db.SaveChanges();
        }
    }
}