using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。

namespace EF.Entity;

public class Userinfo : Entity
{
    [Required, StringLength(16)]
    public string Account { get; set; }
    [Required, StringLength(50)]
    public string Password { get; set; }
    [Required, StringLength(8)]
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}