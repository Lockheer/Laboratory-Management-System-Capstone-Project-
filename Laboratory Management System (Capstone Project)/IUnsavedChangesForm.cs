using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_Management_System__Capstone_Project_
{
    public interface IUnsavedChangesForm
    {
        bool HasUnsavedChanges { get; }
        void ConfirmUnsavedChanges();
    }
}
