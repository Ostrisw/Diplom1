//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dip
{
    using System;
    using System.Collections.Generic;
    
    public partial class Zakupka
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int KBK { get; set; }
        public int KVR { get; set; }
        public decimal Total_sum_rub { get; set; }
        public decimal Sum_rub { get; set; }
        public string Deshifrovka_rashodov { get; set; }
        public string Min_trebovaniya { get; set; }
        public string Kolvo_edinic { get; set; }
        public string Srok_zakupki { get; set; }
        public int God_zakupki { get; set; }
        public string Kafedra { get; set; }
    
        public virtual Kafedra Kafedra1 { get; set; }
        public virtual Kbk Kbk1 { get; set; }
        public virtual Kvr Kvr1 { get; set; }
        public virtual Sroc_zakupki Sroc_zakupki { get; set; }
    }
}
