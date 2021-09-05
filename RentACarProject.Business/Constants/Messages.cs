using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RentACarProject.Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç başarıyla eklendi!";
        public static string CarDeleted = "Araç başarıyla silindi!";
        public static string CarUpdated = "Araç başarıyla güncellendi!";
        public static string CarsListed = "Araçlar listelendi!";
        public static string CarListed = "Araç listelendi!";

        public static string AuthorizationDenied = "Bu operasyon için yetkiniz yok!";
    }
}
