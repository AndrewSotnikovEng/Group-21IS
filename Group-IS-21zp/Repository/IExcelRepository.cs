using Group_IS_21zp.Model;
using System.Collections.Generic;

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
