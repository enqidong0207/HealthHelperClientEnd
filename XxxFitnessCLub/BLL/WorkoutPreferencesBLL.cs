﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub.DAL;
using XxxFitnessCLub.DAL.DAO;

namespace XxxFitnessCLub.BLL
{
    
    class WorkoutPreferencesBLL
    {
        //恩旗
        WorkoutPreferencesDAO dao = new WorkoutPreferencesDAO();

        //恩旗
        public bool AddPreferences(List<WorkoutPreference> wplist)
        {
            return dao.AddPreferences(wplist);
        }
    }
}
