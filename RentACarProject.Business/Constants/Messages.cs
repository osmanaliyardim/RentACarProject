using RentACarProject.Core.Entity.Concrete;

namespace RentACarProject.Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç başarıyla eklendi!";
        public static string CarDeleted = "Araç başarıyla silindi!";
        public static string CarUpdated = "Araç başarıyla güncellendi!";
        public static string CarsListed = "Araçlar başarıyla listelendi!";
        public static string CarListed = "Araç başarıyla listelendi!";

        public static string AuthorizationDenied = "Bu operasyon için yetkiniz yok!";

        public static string UserOperationClaimAdded = "Kullanıcı operasyon yetkisi başarıyla eklendi!";
        public static string UserOperationClaimUpdated = "Kullanıcı operasyon yetkisi başarıyla güncellendi!";
        public static string UserOperationClaimDeleted = "Kullanıcı operasyon yetkisi başarıyla silindi!";

        public static string FindeksAdded = "Findeks skoru başarıyla eklendi!";
        public static string FindeksUpdated = "Findeks skoru başarıyla güncellendi!";
        public static string FindeksDeleted = "Findeks skoru başarıyla silindi!";
        public static string FindeksNotFound = "Findeks skoru bulunamadı!";
        public static string FindeksNotEnoughForCar = "Findeks skoru araç için yeterli değil!";

        public static string UserAdded = "Kullanıcı başarıyla eklendi!";
        public static string UserUpdated = "Kullanıcı başarıyla güncellendi!";
        public static string UserDeleted = "Kullanıcı başarıyla silindi!";
        public static string UserDetailsUpdated = "Kullanıcı detayları başarıyla güncellendi";

        public static string WrongPassword = "Şifre hatalı!";
        public static string AccessTokenCreated = "Access token yaratıldı!";
        public static string UnAuthorized = "Erişim yetkisi reddedildi!";
        public static string Authorized = "Erişim yetkisi verildi!";
        public static string UserNotFound = "Kullanıcı bulunamadı!";
        public static string LoginSuccessfull = "Sisteme giriş başarılı!";
        public static string RegisterSuccessfull = "Yeni kullanıcı başarıyla kaydedildi!";
        public static string UserAlreadyExists = "Böyle bir kullanıcı zaten mevcut!";

        public static string OperationClaimAdded = "Operasyon yetkisi eklendi!";
        public static string OperationClaimUpdated = "Operasyon yetkisi güncellendi!";
        public static string OperationClaimDeleted = "Operasyon yetkisi silindi!";

        public static string BrandAdded = "Marka başarıyla eklendi!";
        public static string BrandUpdated = "Marka başarıyla güncellendi!";
        public static string BrandDeleted = "Marka başarıyla silindi!";

        public static string CarImageCountWrong = "Araç resim sayısı maksimuma ulaştı (5)";
        public static string CarImageAdded = "Araç resmi başarıyla eklendi!";
        public static string CarImageUpdated = "Araç resmi başarıyla güncellendi!";
        public static string CarImageDeleted = "Araç resmi başarıyla silindi!";

        public static string ColorAdded = "Renk başarıyla eklendi!";
        public static string ColorUpdated = "Renk başarıyla güncellendi!";
        public static string ColorDeleted = "Renk başarıyla silindi!";

        public static string CreditCardAdded = "Kredi kartı başarıyla eklendi!";
        public static string CreditCardDeleted = "Kredi kartı başarıyla silindi!";

        public static string PaymentFailed = "Ödeme işlemi başarısız oldu!";
        public static string PaymentSuccessfull = "Ödeme işlemi başarıyla tamamlandı!";

        public static string RentalAdded = "Kiralama ekleme başarılı!";
        public static string RentalUpdated = "Kiralama güncellemesi başarılı!";
        public static string RentalDeleted = "Kiralama silme başarılı!";
        public static string RentalUndeliveredCar = "Araç henüz teslim edilmeye uygun değil!";
        public static string RentalNotAvailable = "Kiralama hazır değil!";
    }
}
