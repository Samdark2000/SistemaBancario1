using BankManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Banco
{
    [Key]
    public string Nom { get; set; }

    public decimal Capital { get; set; }

    [Display(Name = "Numero de cliente")]
    public int NbrClients { get; set; }

    [Display(Name = "Numero de banco")]
    public int NbrComptes { get; set; }

    [Display(Name = "Nombre de crédits")]
    public int NbrCredits { get; set; }

    [Display(Name = "Somme totale déposée par tous les clients")]
    public decimal ArgentDepose { get; set; }

    [Display(Name = "Somme totale des crédits")]
    public decimal SommeCredits { get; set; }

    public ICollection<Cuenta> cuentas { get; set; }

}
