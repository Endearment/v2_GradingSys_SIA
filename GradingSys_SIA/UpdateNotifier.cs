using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingSys_SIA
{
    public static class UpdateNotifier
    {
        public static event Action OnGradeDataUpdated;

        public static void RaiseGradeDataUpdated()
        {
            OnGradeDataUpdated?.Invoke();
        }
    }
}
