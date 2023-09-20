using System;
using System.Collections.Generic;

namespace MyEmoProject;

public partial class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public int GenderId { get; set; }

    public virtual ICollection<DopInfo> DopInfos { get; set; } = new List<DopInfo>();
}
