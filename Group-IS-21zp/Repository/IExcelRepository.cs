using Group_IS_21zp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_IS_21zp.Repository
{
    interface IExcelRepository
    {
        List<IExcelItem> GetItems();
        IExcelItem GetItemById(long id);
        //IExcelItem GetItemByLastName(string lastName);
        IExcelItem AddItem(IExcelItem item);
        bool RemoveItem(long id);
        bool UpdateItem(IExcelItem item);
    }
}
