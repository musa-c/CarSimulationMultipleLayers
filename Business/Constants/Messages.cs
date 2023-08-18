using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public class Messages
    {
        public static readonly string Added = "eklendi";
        public static readonly string Deleted = "silindi";
        public static readonly string Updated = "Güncellendi";
        public static readonly string CarDetailsListed = "listelendi";
        public static readonly string MainenanceTime = "Sistem bakımda";
        public static readonly string AuthorizationDenied = "Yetkiniz yok";
        public static readonly string UserAlreadyExists = "Kullanıcı mevcut.";
        public static readonly string UserNotFound = "Kullancı bulunamadı.";
        public static readonly string PasswordError = "Parola hatası.";
        public static readonly string SuccessfulLogin = "Başarılı giriş.";
        public static readonly string UserRegistered = "Kayıt oldu.";
        public static readonly string AccessTokenCreated = "Token oluşturuldu.";
        public static readonly string ImageLimitExceded = "Resim sınırı aşıldı.";
    }
}
