using BusinessLayer;
using DAL.MsSQL;
using Entities;
using Microsoft.IdentityModel.Protocols.WSFederation.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace WAPi.Controllers
{
    public class Test3Controller : ApiController
    {
        Repository<User> repo_user = new Repository<User>();
        List<User> lste = new List<User>();        //public IEnumerable<User> Get()
        //{
        //    lste = repo_user.List();
        //    return lste;
        //}

        //[ResponseType(typeof(Organization))]
        //[System.Web.Mvc.HttpPost]
        //[System.Web.Http.ActionName("deneme")]
        public IEnumerable<User> GetUsers()
        {
            lste = repo_user.List();
            return lste;
        }
        public IEnumerable<User> GetUsers(int id)
        {
            lste = repo_user.List(x => x.ID == id).ToList();
            return lste;
        }
    }
}
