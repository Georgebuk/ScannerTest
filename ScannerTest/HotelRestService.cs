using HotelClassLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ScannerTest
{
    public class HotelRestService
    {
        readonly string ServiceURL = "http://192.168.0.24:57162/api/";
        HttpClient Client;
        private static HotelRestService instance;

        public static HotelRestService Instance
        {
            get
            {
                if (instance == null)
                    instance = new HotelRestService();
                return instance;
            }
        }

        private HotelRestService()
        {
            Client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
        }

        public async Task<Hotel> getRoomsForHotel(int hotelID)
        {
            string getHotelURI = ServiceURL + "Hotel/" + hotelID;
            var uri = new Uri(getHotelURI);

            Hotel hotel = new Hotel();
            try
            {
                var response = await Client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    content = content.Replace(@"\", string.Empty);
                    content = content.Trim('"');
                    hotel = JsonConvert.DeserializeObject<Hotel>(content);
                }
            }
            catch (Exception ex)
            {

            }

            return hotel;
        }
    }
}
