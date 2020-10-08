using PostcodeLookupTool.Helpers;
using PostcodeLookupTool.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PostcodeLookupTool
{
    public class PostcodeLookup : IPostcodeLookup
    {
        //Assign the Interface type (IPostcodeLookup) when creating the member variable; don't expose it (private) outside of this class and set it only once (readonly) within this constructor.
        private readonly IPostcodeLookup _postcodeLookup;

        protected PopulateDeliveryFeed populateDelivery = new PopulateDeliveryFeed();

        public PostcodeLookup()
        {
        }

        //Inject the Interface 1 of 2:
        public PostcodeLookup(IPostcodeLookup postcodeLookup)
        {
            //'this' keyword not necessarily needed here but on instances of local parameters holding identical naming then encapsuling the member's naming takes precedence.
            this._postcodeLookup = postcodeLookup;
        }

        //Inject the Interface 2 of 2 (not anonymous on this instance but using Lambda expression to set a body definition):
        //public PostcodeLookup(IPostcodeLookup postcodeLookup) => _postcodeLookup = postcodeLookup;

        public string[] GetValidDeliveryOptions(string postcode)
        {
            List<KeyValuePair<string, string>> lDelivery = new List<KeyValuePair<string, string>>();

            string[] sOutput = new string[] { "Everywhere else", "Delivery by Courier" };

            try
            {
                if (postcode != "")
                {
                    lDelivery = populateDelivery.GetFeed();

                    KeyValuePair<string, string> kvp = new KeyValuePair<string, string>();

                    string s = postcode;

                    while (kvp.Key == null)
                    {
                        try
                        {
                            kvp = lDelivery.Find(x => x.Key.EndsWith(s));

                            if (s.Length == 0)
                            {
                                return sOutput;
                            }
                            else
                            {
                                s = s.Remove(s.Length - 1);
                            }
                        }
                        catch (Exception ex)
                        {
                            //This event name will need to be registered beforehand.
                            EventLog.WriteEntry("postcode.Substring", ex.StackTrace.ToString());
                        }
                    }

                    sOutput = new string[] { kvp.Key, kvp.Value };
                }

                return sOutput;
            }
            catch (Exception ex)
            {
                //This event name will need to be registered beforehand.
                EventLog.WriteEntry("GetValidDeliveryOptions", ex.StackTrace.ToString());

                throw ex;
            }
        }
    }
}
