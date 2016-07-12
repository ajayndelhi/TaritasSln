using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.CollectionClasses
{
    /// <summary>
    /// In memory data that is to be shown as pages
    /// </summary>
    public class InMemoryData : IData
    {
        public InMemoryData(IEnumerable<DataClass> dataCollection)
        {
            if (dataCollection == null)
            {
                throw new ArgumentNullException("dataCollection");
            }

            this._dataCollection = dataCollection;
        }

        public long GetItemCount()
        {
            return _dataCollection.LongCount();
        }


        public IEnumerable<DataClass> GetData(long rowsToSkip, int rowsToGet)
        {
            if (rowsToSkip < 0)
            {
                throw new ArgumentException(Resources.InvalidRowsSkipCount);
            }

            if (rowsToGet < 1)
            {
                throw new ArgumentException(Resources.InvalidRowsToGetCount);
            }

            // for simplicity and prototype here, let's use LINQ and convert long to int
            int itemsPast = (int)((rowsToSkip > int.MaxValue) ? int.MaxValue : rowsToSkip);

            return _dataCollection.Skip(itemsPast).Take(rowsToGet);
        }


        private IEnumerable<DataClass> _dataCollection;
    }
}
