using Group_IS_21zp.Model;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Group_IS_21zp.Repository
{
    class StudentRepository : IExcelRepository
    {
        ExcelPackage pck;
        ExcelWorksheet ws;

        const int STUDENT_TAB = 1;
        const int ID_COL = 1;
        const int LAST_NAME_COL = 2;
        const int PATRONYMIC_COL = 4;
        const int FIRST_NAME_COL = 3;
        const int INITIAL_DATA_ROW = 2;

        public StudentRepository()
        {
            FileInfo newFile = new FileInfo("data.xlsx");

            pck = new ExcelPackage(newFile);
            ws = pck.Workbook.Worksheets[STUDENT_TAB];
            ws.View.ShowGridLines = false;
        }

        public IExcelItem GetItemById(long id)
        {
            return GetItems().Where( x => ((Student)x).Id == id).FirstOrDefault();

        }

        public IExcelItem GetItemByLastName(string lastName)
        {
            return GetItems().Where(x => ((Student)x).LastName == lastName).FirstOrDefault();
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
            Student modifiedStudent = (Student) item;
            for (int i = INITIAL_DATA_ROW; i <= ws.Dimension.End.Row; i++)
            {
                long curId = long.Parse(ws.Cells[i, ID_COL].Value.ToString());
                if (curId == modifiedStudent.Id)
                {
                    ws.Cells[i, FIRST_NAME_COL].Value = modifiedStudent.FirstName;
                    ws.Cells[i, LAST_NAME_COL].Value = modifiedStudent.LastName;
                    ws.Cells[i, PATRONYMIC_COL].Value = modifiedStudent.PatronymicName;
                    pck.Save();

                    Console.WriteLine($"Updated Student:\n ID {modifiedStudent.Id}" +
                        $"{modifiedStudent.FirstName} {modifiedStudent.PatronymicName} {modifiedStudent.LastName}\n");

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
                string firstName = ws.Cells[curRow, FIRST_NAME_COL].Value.ToString();
                string patronymicName = ws.Cells[curRow, PATRONYMIC_COL].Value.ToString();
                string lastName = ws.Cells[curRow, LAST_NAME_COL].Value.ToString();

                Student s = new Student(id, firstName, patronymicName, lastName);
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
            int newUserId = maxId + 1;
            ws.Cells[nextRow, ID_COL].Value = newUserId;
            ws.Cells[nextRow, FIRST_NAME_COL].Value = ((Student)item).FirstName;
            ws.Cells[nextRow, LAST_NAME_COL].Value = ((Student)item).LastName;
            ws.Cells[nextRow, PATRONYMIC_COL].Value = ((Student)item).PatronymicName;

            pck.Save();

            return new Student(newUserId, ((Student)item).FirstName, 
                ((Student)item).PatronymicName,
                ((Student)item).LastName);
        }
    }
}
