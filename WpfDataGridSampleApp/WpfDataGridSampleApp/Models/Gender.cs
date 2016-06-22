using System.ComponentModel.DataAnnotations;

namespace WpfDataGridSampleApp.Models
{
    public enum Gender
    {
        [Display(Name = "未選択")]
        None,
        [Display(Name = "男性")]
        Men,
        [Display(Name = "女性")]
        Women,
    }
}