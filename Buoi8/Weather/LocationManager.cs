using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.UI.Popups;

namespace Weather
{
    class LocationManager
    {
        public async static Task<Geoposition> GetGeoposition()
        {
            var accessStatus = await Geolocator.RequestAccessAsync();
            if (accessStatus != GeolocationAccessStatus.Allowed)
            {
                var message = new MessageDialog("Not Allowed");
                await message.ShowAsync();
            }
            var geolocator = new Geolocator() { DesiredAccuracyInMeters = 0 };
            return await geolocator.GetGeopositionAsync();
        }
    }
}
