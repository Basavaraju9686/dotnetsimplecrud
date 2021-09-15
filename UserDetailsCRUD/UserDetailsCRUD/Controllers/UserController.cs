using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserDetailsCRUD.Models;

namespace UserDetailsCRUD.Controllers
{
    public class UserController : ApiController
    {
        UserDBEntities db = new UserDBEntities();


        //add new user
        public string post(tblUserDetail adduser)
        {
            db.tblUserDetails.Add(adduser);
            db.SaveChanges();
            return "user added";


        }


        //view all user details
        public IEnumerable<tblUserDetail> get()
        {
            return db.tblUserDetails.ToList();
        }


        //view particular user details
        public tblUserDetail get(int id)
        {
            tblUserDetail oneData = db.tblUserDetails.Find(id);
            return oneData;
        }


        //update or edit paricular user details
        public string put(int id, tblUserDetail onedataaedit)
        {
            var editdata = db.tblUserDetails.Find(id);
            editdata.UserFirstName = onedataaedit.UserFirstName;
            editdata.UserLastName = onedataaedit.UserLastName;
            db.Entry(editdata).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return "updated successfully!!!";
        }


        //delete particular user
        public string delete(int id)
        {
            tblUserDetail deluser = db.tblUserDetails.Find(id);
            db.tblUserDetails.Remove(deluser);
            db.SaveChanges();
            return "deleted successfully";

        }




    }
}
