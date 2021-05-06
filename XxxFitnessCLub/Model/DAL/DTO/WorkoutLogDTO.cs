using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XxxFitnessCLub.Model.DAL;

namespace HHFirstDraft.DAL.DTO
{

    class WorkoutLogDTO : WorkoutLog
    {
        public WorkoutLogDTO() : base()
        {

        }
        public WorkoutLogDTO(WorkoutLog wl)
        {
            foreach (var propertyInfo in typeof(WorkoutLog).GetProperties())
            {
                propertyInfo.SetValue(this, propertyInfo.GetValue(wl));
            }
        }

        public string MemberName
        {
            get
            {
                return Member.Name;
            }
        }

        public string WorkoutName
        {
            get
            {
                return Workout.Name;
            }
        }

        public string WorkoutCategoryName
        {
            get
            {
                return Workout.WorkoutCategory.Name;
            }
        }

        public string ActivityLevelName
        {
            get
            {
                return Workout.ActivityLevel.Description;
            }
        }

        public bool IsWorkoutPreference
        {
            get
            {
                return Member.WorkoutPreferences
                    .Where(r => r.WorkoutCategoryID == Workout.WorkoutCategoryID)
                    .Count() > 0;
            }
        }

        public double WorkoutTotalCal
        {
            get
            {
                return WorkoutHours * Workout.Calories;
            }

        }
    }
}
