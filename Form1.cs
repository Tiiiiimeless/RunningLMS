using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "请选择要打开的Excel文件(.xlsx/.xls)";  // 对话框标题
                openFileDialog.InitialDirectory = "C:\\Users";  // 初始目录
                openFileDialog.Filter = "Excel File|*.xlsx;*.xls";  // 筛选xlsx和xls文件格式
                openFileDialog.FilterIndex = 0;  // 设置默认筛选器为第一个
                openFileDialog.RestoreDirectory = false;  // 是否记住上次打开的目录
                openFileDialog.Multiselect = false; // 是否多选
                openFileDialog.CheckFileExists = true;  //是否检查文件是否存在
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;  // 获取选择的文件路径
                    var fileName = openFileDialog.SafeFileName;  // 获取选择的文件名
                    MessageBox.Show("您选择的文件路径是: " + filePath);  // 显示选择的文件路径
                    try
                    {
                        var students = ReadExcel(filePath);
                        string jsonFileName = Path.GetFileNameWithoutExtension(fileName) + DateTime.Now.ToString("_yyyy-MM-dd_HHmmss") + ".json";
                        SaveStudentsToJson(students, jsonFileName);
                        string jsonFilePath = Path.GetFullPath(jsonFileName);
                        MessageBox.Show($"json存放路径：{jsonFilePath}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"处理文件时发生错误:{ex.ToString()}");
                    }

                }
            }
        }


        // ==================== 核心逻辑 ====================

        // 从 Excel 读取数据（支持 .xls 和 .xlsx）
        private List<StudentInfo> ReadExcel(string filePath)
        {
            IWorkbook workbook;
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                if (filePath.EndsWith(".xlsx"))
                    workbook = new XSSFWorkbook(fs);
                else
                    workbook = new HSSFWorkbook(fs);
            }

            var sheet = workbook.GetSheetAt(0);
            var headerRow = sheet.GetRow(0);

            var headers = new List<string>();

            if(workbook == null)
            {
                throw new Exception("空文件");
            }

            if (headerRow == null)
            {
                throw new Exception("Excel文件必须包含标题行，且标题行不能为空。");
            }

            for (int i = 0; i < headerRow.LastCellNum; i++)
            {
                headers.Add(item: headerRow.GetCell(i)?.ToString()?.Trim() ?? $"Column{i}");
            }

            int colClass = headers.IndexOf("班级");
            int colName = headers.IndexOf("姓名");
            int colStudentId = headers.IndexOf("学号");

            if (colClass == -1 || colName == -1 || colStudentId == -1)
                throw new Exception("标题行必须包含“班级”、“姓名”、“学号”三列。");

            var students = new List<StudentInfo>();

            for (int rowIdx = 1; rowIdx <= sheet.LastRowNum; rowIdx++)
            {
                var row = sheet.GetRow(rowIdx);
                if (row == null) continue;

                // 跳过空行
                if (row.Cells.All(c => c.CellType == CellType.Blank))
                    continue;

                var student = new StudentInfo
                {
                    班级 = row.GetCell(colClass)?.ToString() ?? "",
                    姓名 = row.GetCell(colName)?.ToString() ?? "",
                    学号 = row.GetCell(colStudentId)?.ToString() ?? ""
                };
                students.Add(student);
            }
            
            return students;
        }

        // 保存为 JSON 到程序所在目录下的 JsonOutput 文件夹
        private void SaveStudentsToJson(List<StudentInfo> students, string fileName)
        {
            string folder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "JsonOutput");
            Directory.CreateDirectory(folder);
            string filePath = Path.Combine(folder, fileName);
            string json = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(filePath, json, System.Text.Encoding.UTF8);
        }
    }
}
