using BusinessLayer.Results;
using Common.Helpers;
using DAL.MsSQL;
using Entities;
using Entities.ErrorMessages;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace BusinessLayer
{
    public class UserManager
    {
        Repository<User> repo_user = new Repository<User>();
        Repository<User_PSW> repo_user_wp = new Repository<User_PSW>();
        LayerResults<User> UserBack = new LayerResults<User>();
        LayerResultList<User> liste = new LayerResultList<User>();
        public LayerResults<User> Register(RegisterVModel model)
        {
            Repository<User_PSW> NEUSPA = new Repository<User_PSW>();
            User R_User = new User();
            bool MailControl;
            bool UserKontrol;
            if (model!=null)
            {
                //burada true dönerseler (kayıt yok)doğru kabul edilir.
                MailControl = repo_user.FindTF(x=>x.User_Name==model.User_Name);
                UserKontrol = repo_user.FindTF(x => x.Mail_Adress == model.Mail_Adress);
                if (MailControl==true&& UserKontrol == true)
                {
                    //User Ekle
                    User NU = new User();
                    NU.U_Name = model.U_Name;
                    NU.U_Surname = model.U_Surname;
                    NU.User_Name = model.User_Name;
                    NU.Mail_Adress = model.Mail_Adress;
                    NU.Reg_Date = DateTime.Now;
                    NU.Guid_ID = Guid.NewGuid();
                    NU.Admin = false;
                    NU.Active = false;
                    int result=repo_user.Insert(NU);
                    //Sifre Kaydet
                    User_PSW NUPSW = new User_PSW();
                    NUPSW.Mail_Adress = model.Mail_Adress;
                    NUPSW.User_Name = model.User_Name;
                    NUPSW.PSW = Crypto.HashPassword(model.PSW);
                    int result2=NEUSPA.Insert(NUPSW);                    
                    if (result>0&&result2>0)
                    {
                        //string body = "{0} isimli kullanici <a href='#'>buraya tıklayarak</a> onay işleminizi gerçeştirebilirsiniz.";

                        //MailHelper.SendMail(body,model.Mail_Adress,"Aktivasyon Maili",);
                        string body = ("{0} isimli kullanıcı sisteme kayıt oldunuz", NU.User_Name).ToString();

                        MailHelper.SendMail(body, NU.Mail_Adress, "Merhaba", true);
                        
                        
                        UserBack.Result = NU;
                        return UserBack;
                    }
                    else
                    {
                        UserBack.AddError(Messages.MailorUserNameIsNotUSed, "Mail adresi veya kullanıcı ismi sistemde kayıtlı.");
                        return UserBack;
                    }
                    

                }
                else
                {
                    UserBack.AddError(Messages.MailorUserNameIsNotUSed, "Mail adresi veya kullanıcı ismi sistemde kayıtlı.");
                    return UserBack;
                }
            }
            else
            {
                UserBack.AddError(Messages.ProblemFromSystem, "Sistem geçici süre kapalıdır");
                return UserBack;
            }
        }

        public LayerResults<User> Login(LoginVModel model)
        {
            if (model!=null)
            {
                bool S1 = repo_user_wp.FindTF(x => x.User_Name == model.User_Name);
                bool S2 = repo_user.FindTF(x => x.User_Name == model.User_Name);
                if (S1==false&&S2==false)
                {
                    User_PSW x = new User_PSW();
                    x = repo_user_wp.Find(z => z.User_Name == model.User_Name);
                    if (x!=null)
                    {
                        bool s3 = Crypto.VerifyHashedPassword(x.PSW, model.PSW);
                        if (s3 == true)
                        {
                            User y = new User();
                            y = repo_user.Find(z => z.User_Name == model.User_Name);
                            UserBack.Result = y;
                            return UserBack;
                        }
                    }
                    else
                    {
                        UserBack.AddError(Messages.ProblemFromSystem, "Bilgileri Yanlış Girdiniz");
                        return UserBack;
                    }
                }
                else
                {
                    UserBack.AddError(Messages.UserIsNotFound, "Böyle bir kullanıcı yok");
                    return UserBack;
                }
            }
                        
            UserBack.AddError(Messages.ProblemFromSystem, "Sistemizde bir hata oluştu , en kısa zamanda dönüş yapacağız");                
            
            return UserBack;
        }

        public void SendGuid(int id,string mail,string Username)
        {
            User us = repo_user.Find(x => x.User_Name == Username && x.Mail_Adress == mail && x.ID == id);
            string body = ("{0} isimli kullanıcı sisteme kayıt oldunuz guid idniz {1}",us.User_Name,us.Guid_ID).ToString();

            MailHelper.SendMail(body, us.Mail_Adress, "Merhaba", true);
           
        }

        public LayerResults<User> GuidCheck(Guid ID)
        {
            UserBack.Result = repo_user.Find(x => x.Guid_ID == ID);
            if (UserBack.Result!=null)
            {
                if (UserBack.Result.Active==true)
                {
                    UserBack.AddError(Messages.ProblemFromSystem, "sistemsel bir problem var");
                    return UserBack;
                }
                UserBack.Result.Active = true;
                repo_user.Update(UserBack.Result);
            }
            else
            {
                UserBack.AddError(Messages.UserIsNotActive, "bir problem var");
            }

            return UserBack;
        }

        public LayerResultList<User> TestTools()
        {
            List<User> data = (from e in repo_user.List()
                               where e.Admin == false && e.Active == false
                               select e).ToList();

            List<User> data2 = repo_user.List().Where(e => e.Active == false && e.Admin == false).ToList();
            List<User> data3 = repo_user.List().Where(e => e.Active == false && e.Admin == false).OrderBy(e=>e.ID).ToList();
            List<User> data4 = repo_user.List().Where(e => e.Active == false && e.Admin == false).OrderByDescending(e => e.ID).ToList();
            //List<Article> lste = ARM.List().OrderByDescending(e => e.ID).Take(5).ToList();

            liste.Sonuc = data4;
            return liste;
        }
    }
}
