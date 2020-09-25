using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TestAssignment.Services;
using Xamarin.Forms;


namespace TestAssignment.ViewModels
{
    public class TaxRateViewModel : INotifyPropertyChanged
    {
        public TaxRateViewModel()
        {
            this.OrderSubTotal = 100;
            this.OrderCity = "SANTA MONICA";
            this.GetPriceCommand = new Command(this.ExecuteGetPrice);
        }
        public Command GetPriceCommand { get; set; }


        private async void ExecuteGetPrice(object obj)
        {
            ITaxService taxService = DependencyService.Get<ITaxService>();
            var TaxModel = await taxService.GetRate(this.OrderCity);
            
            double dTaxTotal = this.OrderSubTotal * Convert.ToDouble(TaxModel.rate.combined_rate);
            this.OrderTotal = this.OrderSubTotal + dTaxTotal;

        }


        #region Model Props

        private double orderSubTotal;
        public double OrderSubTotal
        {
            get { return orderSubTotal; }
            set { SetProperty(ref orderSubTotal, value); }
        }
        private double orderTotal;
        public double OrderTotal
        {
            get { return orderTotal; }
            set { SetProperty(ref orderTotal, value); }
        }

        private string city;
        public string City
        {
            get { return city; }
            set { SetProperty(ref city, value); }
        }
        private string orderCity;
        public string OrderCity
        {
            get { return orderCity; }
            set { SetProperty(ref orderCity, value); }
        }

        private string city_rate;
        public string City_rate
        {
            get { return city_rate; }
            set { SetProperty(ref city_rate, value); }
        }
        private string combined_district_rate;
        public string Combined_district_rate
        {
            get { return combined_district_rate; }
            set { SetProperty(ref combined_district_rate, value); }
        }
        private string combined_rate;
        public string Combined_rate
        {
            get { return combined_rate; }
            set { SetProperty(ref combined_rate, value); }
        }
        private string country;
        public string Country
        {
            get { return country; }
            set { SetProperty(ref country, value); }
        }
        private string country_rate;
        public string Country_rate
        {
            get { return country_rate; }
            set { SetProperty(ref country_rate, value); }
        }
        private string county;
        public string County
        {
            get { return county; }
            set { SetProperty(ref county, value); }
        }
        private string county_rate;
        public string County_rate
        {
            get { return county_rate; }
            set { SetProperty(ref county_rate, value); }
        }
        private bool freight_taxable;
        public bool Freight_taxable
        {
            get { return freight_taxable; }
            set { SetProperty(ref freight_taxable, value); }
        }
        private string state;
        public string State
        {
            get { return state; }
            set { SetProperty(ref state, value); }
        }
        private string state_rate;
        public string State_rate
        {
            get { return state_rate; }
            set { SetProperty(ref state_rate, value); }
        }
        private string zip;
        public string Zip
        {
            get { return zip; }
            set { SetProperty(ref zip, value); }
        }

        #endregion

        #region INotifyPropertyChanged
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
