using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ServiceePubLibrary {

    [ServiceContract]
    public interface IServiceePubLibrary {

        [OperationContract]
        void RegisterUser (string xmlString);

        [OperationContract]
        bool Login (string xmlString);

        [OperationContract]
        UserContract GetUser (string xmlString);

        [OperationContract]
        void SetUserInfo (string xmlString);

        [OperationContract]
        string GetUserInfo (string xmlString);

        [OperationContract]
        string GetMostActiveDay();

        [OperationContract]
        string GetMostActiveMonth();

        [OperationContract]
        string GetMostActiveYear();

        [OperationContract]
        string GetChaptersTopFive();

        [OperationContract]
        string GetAllMonths();

        [OperationContract]
        string GetMostActiveDayByUser(string xmlString);

        [OperationContract]
        string GetMostActiveMonthByUser(string xmlString);

        [OperationContract]
        string GetMostActiveYearByUser(string xmlString);

        [OperationContract]
        string GetAllMonthsByUser(string xmlString);

        [OperationContract]
        string GetTop5EpubFav();

        [OperationContract]
        string GetTop5EpubBookmark();

        [OperationContract]
        string GetTop5EpubFavByUser(string xmlString);

        [OperationContract]
        string GetTop5EpubBookmarkByUser(string xmlString);

    }

    [DataContract]
    public class UserContract {
        private int idValue;
        private string usernameValue;
        private string emailValue;
        private DateTime birthDateValue;

        [DataMember]
        public int Id {
            get {
                return idValue;
            }
            set {
                idValue = value;
            }
        }

        [DataMember]
        public string Username {
            get {
                return usernameValue;
            }
            set {
                usernameValue = value;
            }
        }

        [DataMember]
        public string Email {
            get {
                return emailValue;
            }
            set {
                emailValue = value;
            }
        }

        [DataMember]
        public DateTime BirthDate {
            get {
                return birthDateValue;
            }
            set {
                birthDateValue = value;
            }
        }


    }

}
