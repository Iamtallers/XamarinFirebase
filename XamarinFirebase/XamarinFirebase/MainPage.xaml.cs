using System;
using Xamarin.Forms;
using XamarinFirebase.Model.ViewModel;

namespace XamarinFirebase
{

    public partial class MainPage : ContentPage
    {
         FirebaseHelper firebaseHelper = new FirebaseHelper();
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            await firebaseHelper.AddPerson(Convert.ToDouble(txtHeight.Text), Convert.ToDouble(txtWeight.Text),txtFname.Text, txtLname.Text, txtEmail.Text);
            txtFname.Text = string.Empty;
            txtLname.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtWeight.Text = string.Empty;
            txtHeight.Text = string.Empty;
            await DisplayAlert("Success", "Person Added Successfully", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }

        /*private  void BtnRetrive_Clicked(object sender, EventArgs e)
        {
            /*var person = await firebaseHelper.GetPerson(Convert.ToInt32(txtId.Text));
            if (person != null)
            {
                txtId.Text = person.PersonId.ToString();
                txtName.Text = person.Name;
                await DisplayAlert("Success", "Person Retrive Successfully", "OK");

            }
            else
            {
                await DisplayAlert("Success", "No Person Available", "OK");
            } 
        }

        private  void BtnUpdate_Clicked(object sender, EventArgs e)
        {
           /* await firebaseHelper.UpdatePerson(Convert.ToInt32(txtId.Text), txtName.Text);
            txtId.Text = string.Empty;
            txtName.Text = string.Empty;
            await DisplayAlert("Success", "Person Updated Successfully", "OK");
            var allPersons = await firebaseHelper.GetAllPersons();
            lstPersons.ItemsSource = allPersons;
        }

        private  void BtnDelete_Clicked(object sender, EventArgs e)
        {
            /* await firebaseHelper.DeletePerson(Convert.ToInt32(txtId.Text));
             await DisplayAlert("Success", "Person Deleted Successfully", "OK");
             var allPersons = await firebaseHelper.GetAllPersons();
             lstPersons.ItemsSource = allPersons; 
            
        }
        */
    }
}
