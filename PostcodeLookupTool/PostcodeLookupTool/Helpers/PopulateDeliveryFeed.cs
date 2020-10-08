using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace PostcodeLookupTool.Helpers
{
    public class PopulateDeliveryFeed
    {
        public List<KeyValuePair<string, string>> GetFeed()
        {
            //Putting a try/catch in place for further implementation, maybe feed in from a JSON pull.
            try
            {
                List<KeyValuePair<string, string>> _list = new List<KeyValuePair<string, string>>();

                Dictionary<string, string> _dictionary = new Dictionary<string, string>()
                {
                    { "AB9", "Delivery from Warehouse" },
                    { "AB9 1AP", "No Deliveries" },
                    { "AB8", "Delivery from Warehouse" },
                    { "AB11", "Delivery from Warehouse" },
                    { "AB1", "Van Delivery, Collect from Alpha Bravo" },
                    { "AB2", "Van Delivery, Collect from Alpha Bravo" },
                    { "AB10", "Van Delivery" },
                    { "AB13", "Delivery from Alpha Bravo, Collect from Alpha Bravo" },
                    { "AB14", "Delivery from Alpha Bravo, Collect from Alpha Bravo" },
                    { "AB15", "Collect from Alpha Bravo" },
                    { "CD", "No Deliveries" },
                    { "CD10", "Collect from Kitchen" },
                    { "CD10 3", "Collect from Kitchen, Delivery  from Caulder Dawn" },
                    { "EF", "No Deliveries" },
                    { "Everywhere else", "Delivery by Courier" }
                };

                foreach (KeyValuePair<string, string> kvp in _dictionary)
                {
                    _list.Add(kvp);
                }

                return _list;
            }
            catch (Exception ex)
            {
                //This event name will need to be registered beforehand.
                EventLog.WriteEntry("PopulateDeliveryFeed", ex.StackTrace.ToString());

                throw ex;
            }
        }
    }
}
