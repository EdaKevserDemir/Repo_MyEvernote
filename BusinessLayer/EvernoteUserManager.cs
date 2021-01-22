using DataAccessLayer.EntityFramework;
using Entities;
using MyEvernote.Entities.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EvernoteUserManager
    {
        private Repository<EvernoteUser> repo_user = new Repository<EvernoteUser>();
        public BusinessLayerResult<EvernoteUser> RegisterUser(RegisterViewModal data)
        {
            //kullanıcı username kontrolü
            //kullanıcı eposta kontrolü
            //kayıt işlemi
            //aktivasyon epostası gönderimi

            EvernoteUser user = repo_user.Find(x => x.Username == data.Username || x.Email == data.Email);
            BusinessLayerResult<EvernoteUser> layerResult = new BusinessLayerResult<EvernoteUser>();
            if (user != null)
            {
                if (user.Username == data.Username)
                {
                    layerResult.Errors.Add("Kullanıcı Adı kayıtlı");
                }

                if (user.Email == data.Email)
                {
                    layerResult.Errors.Add("Eposta kayıtlı");
                }
            }
            else
            {
                int dbResult = repo_user.Insert(new EvernoteUser()
                {
                    Username = data.Username,
                    Email=data.Email,
                    Password=data.Password                

                });
                if(dbResult>1)
                {
                    layerResult.Result=repo_user.Find(x=>x.Email)
                }

            }

            return layerResult;
        }
    }
}