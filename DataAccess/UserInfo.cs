using System;
using System.Collections.Generic;

namespace NET_Core_CRUD_API.DataAccess;

public partial class UserInfo
{
    public int UserInfoId { get; set; }

    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public string? UserImage { get; set; }

    public string UserLanguage { get; set; } = null!;

    public string UserHobby { get; set; } = null!;

    public DateOnly UserDob { get; set; }

    public string? UserFeedback { get; set; }
}
