using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinFirebase.Model.ViewModel
{
    class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://ultimate-fitness-trial-default-rtdb.firebaseio.com/");
        public async Task<List<Person>> GetAllPersons()
        {
            return (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Select(item => new Person
              {
                  Fname = item.Object.Fname,
                  Lname = item.Object.Lname,
                  Email = item.Object.Email,
                  Weight = item.Object.Weight,
                  Height = item.Object.Height,                  
              }).ToList();
        }

        public async Task AddPerson(double height, double weight, string fname, string lname, string email)
        {
            await firebase
              .Child("Cli_1")
              .PostAsync(new Person() {Fname = fname, Lname = lname, Email = email, Weight = weight, Height = height,);
        }

        /*public async Task<Person> GetPerson(int personId)
        {
            var allPersons = await GetAllPersons();
            await firebase
              .Child("Persons")
              .OnceAsync<Person>();
            return allPersons.Where(a => a.PersonId == personId).FirstOrDefault();
        }

        public async Task UpdatePerson(int personId, string name)
        {
            var toUpdatePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();

            await firebase
              .Child("Persons")
              .Child(toUpdatePerson.Key)
              .PutAsync(new Person() { PersonId = personId, Name = name });
        }

        public async Task DeletePerson(int personId)
        {
            var toDeletePerson = (await firebase
              .Child("Persons")
              .OnceAsync<Person>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();
            await firebase.Child("Persons").Child(toDeletePerson.Key).DeleteAsync();
        } */
    }
}
