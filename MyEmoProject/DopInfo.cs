using System;
using System.Collections.Generic;

namespace MyEmoProject;

public partial class DopInfo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
