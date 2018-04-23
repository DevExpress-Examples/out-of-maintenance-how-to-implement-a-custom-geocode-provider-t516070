using DevExpress.XtraMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomGeocodeProvider {
    public partial class Form1 : Form {
        InformationLayer Layer { get { return (InformationLayer)mapControl1.Layers[1]; } }
        public Form1() {
            InitializeComponent();
            Layer.DataProvider = new GeocodeDataProvider();
        }
    }
        public class GeocodeDataProvider : InformationDataProviderBase, IMouseClickRequestSender {
        public GeocodeDataProvider() {
            this.ProcessMouseEvents = true;
        }
        protected new GeocodeData Data { get { return (GeocodeData)base.Data; } }
        protected override IInformationData CreateData() {
            return new GeocodeData();
        }
        public void RequestByPoint(GeoPoint geoPoint, MapPoint screenPoint) {
            Data.CalculateAddress(geoPoint);
        }
    }
    public class GeocodeData : IInformationData {
        LocationInformation address = new LocationInformation();
        public LocationInformation Address { get { return address; } set { address = value; } }

        public event EventHandler<RequestCompletedEventArgs> OnDataResponse;
        RequestCompletedEventArgs CreateEventArgs() {
            MapItem item = new MapCallout() { Location = address.Location, Text = address.Address.FormattedAddress };
            return new RequestCompletedEventArgs(new MapItem[] { item }, null, false, null);
        }
        protected void RaiseChanged() {
            if (OnDataResponse != null)
                OnDataResponse(this, CreateEventArgs());
        }

        public void CalculateAddress(GeoPoint geoPoint) {
            //Implement your custom geocode logic here
            LocationInformation info = new LocationInformation();
            info.Address = new Address("Address from your service here " + Environment.NewLine + "Coordinates: " + geoPoint.ToString());
            info.Location = new GeoPoint(geoPoint.Latitude, geoPoint.Longitude);
            Address = info;
            //
            RaiseChanged();
        }
    }
    public class Address : AddressBase {
        public Address(string address) {
            this.FormattedAddress = address;
        }
    }
}
