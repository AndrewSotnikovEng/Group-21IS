using Group_IS_21zp.Model;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Group_IS_21zp.Repository
{
    class SubjectRepository : IExcelRepository
    {
        ExcelPackage pck;
        ExcelWorksheet ws;

        const int SUBJECT_TAB = 3;
        const int ID_COL = 1;
        const int NAME_COL = 2;
        const int INITIAL_DATA_ROW = 2;

        public SubjectRepository()
        {
            FileInfo newFile = new FileInfo("data.xlsx");

            pck = new ExcelPackage(newFile);
            ws = pck.Workbook.Worksheets[SUBJECT_TAB];
            ws.View.ShowGridLines = false;
        }

        public IExcelItem GetItemById(long id)
        {
            return GetItems().Where( x => ((Subject)x).Id == id).FirstOrDefault();

        }

        public IExcelItem GetItemByName(string name)
        {
            return GetItems().Where(x => ((Subject)x).Name == name).FirstOrDefault();
        }

        public bool RemoveItem(long id)
        {
            for (int i = INITIAL_DATA_ROW; i <= ws.Dimension.End.Row; i++)
            {
                long curId = long.Parse(ws.Cells[i, ID_COL].Value.ToString());
                if (curId == id)
                {
                    id = curId;
                    ws.DeleteRow(i, i, true);
                    pck.Save();

                    return true;
                }
            }
            return false;
        }

        public bool UpdateItem(IExcelItem item)
        {
            Subject modifiedSubject = (Subject) item;
            for (int i = INITIAL_DATA_ROW; i <= ws.Dimension.End.Row; i++)
            {
                long curId = long.Parse(ws.Cells[i, ID_COL].Value.ToString());
                if (curId == modifiedSubject.Id)
                {
                    ws.Cells[i, ID_COL].Value = modifiedSubject.Id;
                    ws.Cells[i, NAME_COL].Value = modifiedSubject.Name;
                    pck.Save();

                    Console.WriteLine($"Updated Student:\n ID {modifiedSubject.Id} {modifiedSubject.Name}");

                    return true;
                }
            }
            return false;
        }

        public List<IExcelItem> GetItems()
        {
            List<IExcelItem> items = new List<IExcelItem>();
            for (int curRow = INITIAL_DATA_ROW; curRow <= ws.Dimension.End.Row; curRow++)
            {
                long id = long.Parse(ws.Cells[curRow, ID_COL].Value.ToString());
                string name = ws.Cells[curRow, NAME_COL].Value.ToString();

                Subject s = new Subject(id, name);
                items.Add(s);

            }
            return items;
        }

        public IExcelItem AddItem(IExcelItem item)
        {
            int maxId = 0;
            for (int i = INITIAL_DATA_ROW; i <= ws.Dimension.End.Row; i++)
            {
                long curId = long.Parse(ws.Cells[i, ID_COL].Value.ToString());
                if (curId > maxId)
                {
                    maxId = (int)curId;
                }
            }

            int nextRow = ws.Dimension.End.Row + 1;
            int newSubjectId = maxId + 1;
            ws.Cells[nextRow, ID_COL].Value = newSubjectId;
            ws.Cells[nextRow, NAME_COL].Value = ((Subject)item).Name;

            pck.Save();

            return new Subject(newSubjectId, ((Subject)item).Name);
        }
    }
}
