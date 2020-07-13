using APppSql.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APppSql.DataAccess
{
    class DatabaseHelperClass
    {
        public void CreateDatabase(string DB_PATH)
        {
            if (!CheckFileExists(DB_PATH).Result)
            {

                using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DB_PATH))
                {
                    conn.CreateTable<Contacts>();
                }
            }
        }
        private async Task<bool> CheckFileExists(string fileName)
        {
            try
            {
                var store = await Windows.Storage.ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public void Insert(Contacts objContacts)
        {

            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
            {
                conn.RunInTransaction(() =>
                {
                    conn.Insert(objContacts);
                });
            }
        }
        public Contacts ReadContacts(int Contactid)
        {

            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
            {

                var existingcontact = conn.Query<Contacts>("select* from Contacts whereId =" + Contactid).FirstOrDefault();
                return existingcontact;

            }
        }
        public ObservableCollection<Contacts> ReadAllContacts()
        {
            try
            {

                using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
                {

                    List<Contacts> myCollection = conn.Table<Contacts>().ToList<Contacts>();

                    ObservableCollection<Contacts> ContactssList = new ObservableCollection<Contacts>(myCollection);
                    return ContactssList;
                }
            }
            catch
            {
                return null;
            }

        }
        public void UpdateDetails(Contacts ObjContact)
        {

            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
            {

                var existingconact = conn.Query<Contacts>("select* from Contacts whereId =" + ObjContact.Id).FirstOrDefault();
                if (existingconact != null)
                {

                    conn.RunInTransaction(() =>
                    {
                        conn.Update(ObjContact);
                    });
                }

            }
        }
        public void DeleteAllContact()
        {

            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
            {

                conn.DropTable<Contacts>();
                conn.CreateTable<Contacts>();
                conn.Dispose();
                conn.Close();

            }
        }
        public void DeleteContact(int Id)
        {

            using (SQLite.Net.SQLiteConnection conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), App.DB_PATH))
            {


                var existingconact = conn.Query<Contacts>("select* from Contacts whereId =" + Id).FirstOrDefault();
                if (existingconact != null)
                {
                    conn.RunInTransaction(() =>
                    {
                        conn.Delete(existingconact);
                    });
                }
            }
        }
    }
}