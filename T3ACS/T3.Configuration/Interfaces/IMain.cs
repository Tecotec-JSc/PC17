using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace T3.Configuration
{
    public interface IMain
    {
        void RunProcedureId(int id);
        void EditProcedureId(int id);
        void CreateProcedure();
        void ClearFormMain();       
    }
}
