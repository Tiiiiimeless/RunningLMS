namespace WindowsFormsApp1
{
    public class StudentInfo
    {
        public string 班级 { get; set; }
        public string 姓名 { get; set; }
        public string 学号 { get; set; }

        // 多选框里显示的文本格式（班级 | 姓名 | 学号）
        public override string ToString()
        {
            return $"{班级} | {姓名} | {学号}";
        }
    }
}