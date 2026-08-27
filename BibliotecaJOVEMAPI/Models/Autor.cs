using System;
using System.Collections.Generic;

namespace BibliotecaJOVEMAPI.Models;

public partial class Autor
{
    public int AutorId { get; set; }

    public string Nome { get; set; } = null!;

    public string? Nacionalidade { get; set; }

    public virtual ICollection<Livro> Livros { get; set; } = new List<Livro>();
}
