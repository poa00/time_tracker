﻿using System;
using System.Collections.Generic;

namespace Ficksworkshop.TimeTrackerAPI
{
    public delegate void ProjectsChangedEventHandler(object sender, object e);

    /// <summary>
    /// Represents the view of project times data that is exposed externally. The purpose of these
    /// interfaces is to allow chaning out the core data storage without affecting clients of the API.
    /// </summary>
    public interface IProjectTimesData
    {
        #region Projects

        /// <summary>
        /// Gets a listing of all projects.
        /// </summary>
        IEnumerable<IProject> Projects { get; }


        /// <summary>
        /// Creates a new project instance.
        /// </summary>
        /// <returns>The new project instance.</returns>
        IProject CreateProject();

        /// <summary>
        /// Deletes a project instance.
        /// </summary>
        /// <param name="project">The project to delete.</param>
        void DeleteProject(IProject project);

        event ProjectsChangedEventHandler ProjectsChanged;

        #endregion

        #region Times

        /// <summary>
        /// Gets a listing of all times.
        /// </summary>
        IEnumerable<IProjectTime> Times { get; }

        /// <summary>
        /// Create a new time, associated with the specified project.
        /// </summary>
        /// <param name="project">The project to assign the time to.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time, or null to not assign an end time.</param>
        /// <returns></returns>
        IProjectTime CreateTime(IProject project, DateTime startTime, DateTime? endTime);

        #endregion
    }

    public enum ProjectStatus
    {
        Open,
        Closed,
    }

    public interface IProject
    {
        string Name { get; set; }

        string UniqueId { get; set; }

        ProjectStatus Status { get; set; }
    }

    public interface IProjectTime
    {
        DateTime Start { get; set; }

        DateTime? End { get; set; }

        IProject Project { get; }
    }
}