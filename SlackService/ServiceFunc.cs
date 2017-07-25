using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SlackService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class ServiceFunc : IServiceFunc
    {
        SlackwareEntities db = new SlackwareEntities();

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public bool AddEntry(tblEntry entry)
        {
            try
            {
                tblEntry tEntry = new tblEntry();
                tEntry = entry;
                db.tblEntries.Add(tEntry);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<tblEntry> SearchEntry(string title)
        {
            try
            {
                var entryList = (from a in db.tblEntries
                                 where a.Title.Contains(title)
                                 select a).ToList();
                return entryList;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool UpdateEntry(tblEntry entry)
        {
            try
            {
                var entryQuery = (from a in db.tblEntries
                                  where a.Id == entry.Id
                                  select a).FirstOrDefault();
                entryQuery = entry;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
