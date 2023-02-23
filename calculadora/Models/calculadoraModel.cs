using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculadora
{

    public class calculadora1
    {
        public int ID_NMOPERACAO { get; set; }     
        public DateTime HOR_OP { get; set; }
        public decimal RESULT { get; set; }
        public char OPERACAO { get; set; }
        public decimal VALOR_1 { get; set; }   
        public decimal VALOR_2 { get; set; }
    }
    
}

